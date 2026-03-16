namespace WeChooz.TechAssessment.Domain.Sessions.CreeSessionCommand;

public class CreeSessionMapper : IMap<CreeSessionCommand,  CreeSessionModel>
{
    public CreeSessionModel MapFrom(CreeSessionCommand command) =>
        new()
        {
            IdCours = command.IdCours,
            IdParticipants = command.IdParticipants,
            ModeDelivrance = command.ModeDelivrance,
            DateDebut = command.DateDebut,
        };
}