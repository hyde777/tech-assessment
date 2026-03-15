namespace WeChooz.TechAssessment.Domain.Cours.CreeCoursCommand;

public class CoursCreateModel
{
    public string Nom { get; set; }
    public string CourteDescription { get; set; }
    public PopulationCibleEnum PopulationCibleEnum { get; set; }
    public int CapaciteMaximal { get; set; }
}