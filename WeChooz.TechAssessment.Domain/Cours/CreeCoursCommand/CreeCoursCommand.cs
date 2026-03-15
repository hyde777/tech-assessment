namespace WeChooz.TechAssessment.Domain.Cours.CreeCoursCommand;

public class CreeCoursCommand
{
    public string Nom { get; set; }
    public string CourteDescription { get; set; }
    public PopulationCibleEnum PopulationCibleEnum { get; set; }
    public int CapaciteMaximal { get; set; }
}