using WeChooz.TechAssessment.UnitTests;

namespace WeChooz.TechAssessment.Domain.Sessions;

public interface ISessionRepository
{
    Task<List<SessionReadModel>> GetAll(CancellationToken cancellationToken);
    Task<int> Add(SessionCreateModel sessionCreateModel, CancellationToken cancellationToken);
}