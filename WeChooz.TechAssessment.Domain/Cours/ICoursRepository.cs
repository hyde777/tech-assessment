using WeChooz.TechAssessment.Domain.Cours.CoursQuery;
using WeChooz.TechAssessment.Domain.Cours.CreeCoursCommand;

namespace WeChooz.TechAssessment.Domain.Cours;

public interface ICoursRepository
{
    Task<List<CoursReadModel>> GetAll(CancellationToken cancellationToken);
    Task<int> Add(CreeCoursModel creeCoursModel, CancellationToken cancellationToken);
}