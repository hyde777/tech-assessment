namespace WeChooz.TechAssessment.Domain.Cours.CreeCoursCommand;

public interface IMap<From, To>
{
    To MapFrom(From readModel);
}