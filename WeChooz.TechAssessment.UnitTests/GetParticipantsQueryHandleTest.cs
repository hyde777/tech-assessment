using FluentAssertions;
using NSubstitute;

namespace WeChooz.TechAssessment.UnitTests;

public class GetParticipantsQueryHandleTest
{
    [Fact]
    public async Task Should_return_les_participants()
    {
        var query = new GetParticipantsQuery();
        IParticipantRepository participantRepository = Substitute.For<IParticipantRepository>();
        var participantReadModels = new List<ParticipantReadModel>
        {
            new()
            {
                Id = 3,
                Personne = new PersonneReadModel
                {
                    Id = 2,
                    Nom = "Nom",
                    Prenom = "Prenom"
                },
                Email = "email",
                Entreprise = "entreprise"
            }
        };
        participantRepository.GetAll(Arg.Any<CancellationToken>())
            .Returns(participantReadModels);
        var handler = new GetPaticipantsQueryHandler(participantRepository);

        var result = await handler.Handle(query, CancellationToken.None);

        result.Should().BeEquivalentTo(
        [
            new ParticipantDto()
            {
                Id = 3,
                Nom = "Nom",
                Prenom = "Prenom",
                Email = "email",
                Entreprise = "entreprise"
            }
        ]);
    }
}