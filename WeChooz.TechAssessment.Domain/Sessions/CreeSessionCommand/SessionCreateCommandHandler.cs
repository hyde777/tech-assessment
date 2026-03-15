using WeChooz.TechAssessment.Domain.Sessions;

namespace WeChooz.TechAssessment.UnitTests;

public class SessionCreateCommandHandler
{
    private readonly ISessionRepository _sessionRepository;

    public SessionCreateCommandHandler(ISessionRepository sessionRepository)
    {
        _sessionRepository = sessionRepository;
    }

    public async Task<int> Handle(SessionCreateCommand command, CancellationToken cancellationToken)
    {
        var idSession = await _sessionRepository.Add(new SessionCreateModel
        {
            IdCours = command.IdCours,
            IdParticipants = command.IdParticipants,
            ModeDelivrance = command.ModeDelivrance,
            DateDebut = command.DateDebut,
        }, cancellationToken);

        return idSession;
    }
}