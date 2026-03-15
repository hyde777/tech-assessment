namespace WeChooz.TechAssessment.Domain.Sessions.CreeSessionCommand;

public class CreeSessionCommandHandler
{
    private readonly ICreeRepository<CreeSessionModel> _sessionRepository;

    public CreeSessionCommandHandler(ICreeRepository<CreeSessionModel> sessionRepository)
    {
        _sessionRepository = sessionRepository;
    }

    public async Task<int> Handle(CreeSessionCommand command, CancellationToken cancellationToken)
    {
        var idSession = await _sessionRepository.Add(new CreeSessionModel
        {
            IdCours = command.IdCours,
            IdParticipants = command.IdParticipants,
            ModeDelivrance = command.ModeDelivrance,
            DateDebut = command.DateDebut,
        }, cancellationToken);

        return idSession;
    }
}