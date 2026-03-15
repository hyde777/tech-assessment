namespace WeChooz.TechAssessment.Domain.Participants.ParticipantQuery;

public class ParticipantsQueryHandler
{
    private readonly IReadRepository<ParticipantReadModel> _participantRepository;

    public ParticipantsQueryHandler(IReadRepository<ParticipantReadModel> participantRepository)
    {
        _participantRepository = participantRepository;
    }

    public async Task<List<ParticipantDto>> Handle(ParticipantsQuery query, CancellationToken cancellationToken)
    {
        var participants = await _participantRepository.GetAll(cancellationToken);

        return participants.Select(x => new ParticipantDto
        {
            Id = x.Id,
            IdPersonne = x.Personne.Id,
            Nom = x.Personne.Nom,
            Prenom = x.Personne.Prenom,
            Email = x.Email,
            Entreprise = x.Entreprise
        }).ToList();
    }
}