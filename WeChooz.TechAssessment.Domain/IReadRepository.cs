namespace WeChooz.TechAssessment.Domain;

public interface IReadRepository<ReadModel>
{
    Task<List<ReadModel>> GetAll(CancellationToken cancellationToken);
}