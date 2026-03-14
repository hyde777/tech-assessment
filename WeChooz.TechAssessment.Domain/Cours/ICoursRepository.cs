namespace WeChooz.TechAssessment.Domain.Cours;

public interface ICoursRepository
{
    List<CoursReadModel> GetAll();
}