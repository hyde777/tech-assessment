namespace WeChooz.TechAssessment.Domain.Cours.CreeCoursCommand;

public class CreeCoursMapper : IMap<CreeCoursCommand,  CreeCoursModel>
{
    public CreeCoursModel MapFrom(CreeCoursCommand readModel) =>
        new()
        {
            CourteDescription = readModel.CourteDescription,
            CapaciteMaximal = readModel.CapaciteMaximal,
            Nom = readModel.Nom,
            PopulationCibleEnum = readModel.PopulationCibleEnum
        };
}