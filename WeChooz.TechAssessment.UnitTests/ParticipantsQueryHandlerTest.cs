using FluentAssertions;
using NSubstitute;
using WeChooz.TechAssessment.Domain;
using WeChooz.TechAssessment.Domain.Cours.CreeCoursCommand;
using WeChooz.TechAssessment.Domain.Participants.ParticipantQuery;

namespace WeChooz.TechAssessment.UnitTests;

public class ParticipantsQueryHandlerTest
{
    private readonly IReadRepository<ParticipantReadModel> _participantRepository = Substitute.For<IReadRepository<ParticipantReadModel>>();
    private readonly BasicQueryHandler<ParticipantsQuery, ParticipantReadModel, ParticipantQueryDto> _handler;

    public ParticipantsQueryHandlerTest()
    {
        _handler = new BasicQueryHandler<ParticipantsQuery, ParticipantReadModel, ParticipantQueryDto>(_participantRepository, new ParticipantDtoMapper());
    }

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
        _participantRepository.GetAll(Arg.Any<CancellationToken>())
            .Returns(participantReadModels);

        var result = await _handler.Handle(query, CancellationToken.None);

        result.Should().BeEquivalentTo(
        [
            new ParticipantQueryDto()
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