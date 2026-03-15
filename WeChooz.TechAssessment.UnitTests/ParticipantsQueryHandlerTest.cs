using FluentAssertions;
using NSubstitute;
using WeChooz.TechAssessment.Domain;
using WeChooz.TechAssessment.Domain.Participants;

namespace WeChooz.TechAssessment.UnitTests;

public class ParticipantsQueryHandlerTest
{
    private const int IdPersonne = 2;
    private const string Nom = "Nom";
    private const string Prenom = "Prenom";
    private const string Email = "email";
    private const string Entreprise = "entreprise";
    private const int IdParticipant = 3;

    [Fact]
    public async Task Should_return_les_participants()
    {
        var query = new ParticipantsQuery();
        IParticipantRepository participantRepository = Substitute.For<IParticipantRepository>();

        var participantReadModels = new List<ParticipantReadModel>
        {
            new()
            {
                Id = IdParticipant,
                Personne = new PersonneReadModel
                {
                    Id = IdPersonne,
                    Nom = Nom,
                    Prenom = Prenom
                },
                Email = Email,
                Entreprise = Entreprise
            }
        };
        participantRepository.GetAll(Arg.Any<CancellationToken>())
            .Returns(participantReadModels);
        var handler = new ParticipantsQueryHandler(participantRepository);

        var result = await handler.Handle(query, CancellationToken.None);

        result.Should().BeEquivalentTo(
        [
            new ParticipantDto()
            {
                Id = IdParticipant,
                IdPersonne = IdPersonne,
                Nom = Nom,
                Prenom = Prenom,
                Email = Email,
                Entreprise = Entreprise
            }
        ]);
    }
}