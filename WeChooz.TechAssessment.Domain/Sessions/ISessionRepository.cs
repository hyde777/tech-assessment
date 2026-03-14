namespace WeChooz.TechAssessment.Domain.Sessions;

public interface ISessionRepository
{
    Task<List<SessionReadModel>> GetAll(CancellationToken any);
}