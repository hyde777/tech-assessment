namespace WeChooz.TechAssessment.Domain.Cours;

public interface ICoursRepository
{
    Task<List<CoursReadModel>> GetAll(CancellationToken cancellationToken);
}