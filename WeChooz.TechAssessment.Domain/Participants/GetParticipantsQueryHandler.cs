using WeChooz.TechAssessment.UnitTests;

namespace WeChooz.TechAssessment.Domain.Participants;

public class GetParticipantsQueryHandler
{
    private readonly IParticipantRepository _participantRepository;

    public GetParticipantsQueryHandler(IParticipantRepository participantRepository)
    {
        _participantRepository = participantRepository;
    }

    public async Task<List<ParticipantDto>> Handle(GetParticipantsQuery query, CancellationToken cancellationToken)
    {
        var participants = await _participantRepository.GetAll(cancellationToken);

        return participants.Select(x => new ParticipantDto
        {
            Id = x.Id,
            Nom = x.Personne.Nom,
            Prenom = x.Personne.Prenom,
            Email = x.Email,
            Entreprise = x.Entreprise
        }).ToList();
    }
}