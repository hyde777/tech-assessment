namespace WeChooz.TechAssessment.Domain.Sessions.SessionQuery;

public class SessionQueryHandler
{
    private readonly IReadRepository<SessionReadModel> _sessionRepository;

    public SessionQueryHandler(IReadRepository<SessionReadModel> sessionRepository)
    {
        _sessionRepository = sessionRepository;
    }

    public async Task<List<SessionDto>> Handle(SessionQuery query, CancellationToken cancellationToken)
    {
        var sessions = await _sessionRepository.GetAll(cancellationToken);
        return sessions.Select(x => new SessionDto
        {
            Id = x.Id,
            DateDebutSession = x.DateDebutSession,
            IdCours = x.IdCours,
            IdParticipants = x.IdParticipants,
            IdSession = x.IdSession,
            ModeDelivrance = x.ModeDelivrance,
            PopulationCible = x.PopulationCible
        }).ToList();
    }
}