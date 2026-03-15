using WeChooz.TechAssessment.Domain.Sessions.CreeSessionCommand;
using WeChooz.TechAssessment.Domain.Sessions.SessionQuery;

namespace WeChooz.TechAssessment.Domain.Sessions;

public interface ISessionRepository
{
    Task<List<SessionReadModel>> GetAll(CancellationToken cancellationToken);
    Task<int> Add(CreeSessionModel creeSessionModel, CancellationToken cancellationToken);
}