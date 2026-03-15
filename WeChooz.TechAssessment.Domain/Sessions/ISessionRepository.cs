using WeChooz.TechAssessment.Domain.Sessions.CreeSessionCommand;

namespace WeChooz.TechAssessment.Domain.Sessions;

public interface ISessionRepository
{
    Task<int> Add(CreeSessionModel creeSessionModel, CancellationToken cancellationToken);
}