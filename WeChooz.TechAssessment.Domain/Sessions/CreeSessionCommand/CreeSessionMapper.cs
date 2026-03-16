using WeChooz.TechAssessment.Domain.Cours.CreeCoursCommand;
using WeChooz.TechAssessment.Domain.Sessions.CreeSessionCommand;

namespace WeChooz.TechAssessment.Domain.Participants.CreeParticipantCommand;

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