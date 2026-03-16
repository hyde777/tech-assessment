using WeChooz.TechAssessment.Domain.Cours.CreeCoursCommand;

namespace WeChooz.TechAssessment.Domain.Sessions.SessionQuery;

public class SessionDtoMapper : IMap<SessionReadModel,  SessionQueryDto>
{
    public SessionQueryDto MapFrom(SessionReadModel readModel) =>
        new()
        {
            Id = readModel.Id,
            DateDebutSession = readModel.DateDebutSession,
            IdCours = readModel.IdCours,
            IdParticipants = readModel.IdParticipants,
            IdSession = readModel.IdSession,
            ModeDelivrance = readModel.ModeDelivrance,
            PopulationCible = readModel.PopulationCible
        };
}