using WeChooz.TechAssessment.UnitTests;

namespace WeChooz.TechAssessment.Domain.Cours;

public interface ICoursRepository
{
    Task<List<CoursReadModel>> GetAll(CancellationToken cancellationToken);
    Task<int> Add(CoursCreateModel coursCreateModel, CancellationToken cancellationToken);
}