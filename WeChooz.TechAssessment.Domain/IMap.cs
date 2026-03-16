namespace WeChooz.TechAssessment.Domain;

public interface IMap<From, To>
{
    To MapFrom(From readModel);
}