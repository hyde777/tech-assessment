namespace WeChooz.TechAssessment.UnitTests;

public class CoursReadModel
{
    public string Nom { get; set; }
    public PersonneReadModel Formateur { get; set; }
    public int CapaciteMaximal { get; set; }
    public PopulationCibleEnum PopulationCible { get; set; }
    public string CourteDescription { get; set; }
    public string LongueDescription { get; set; }
    public int Duree { get; set; }
}