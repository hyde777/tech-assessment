namespace WeChooz.TechAssessment.Domain.Cours.CreeCoursCommand;

public class CreeCoursMapper : IMap<CreeCoursCommand,  CreeCoursModel>
{
    public CreeCoursModel MapFrom(CreeCoursCommand command) =>
        new()
        {
            CourteDescription = command.CourteDescription,
            CapaciteMaximal = command.CapaciteMaximal,
            Nom = command.Nom,
            PopulationCibleEnum = command.PopulationCibleEnum
        };
}