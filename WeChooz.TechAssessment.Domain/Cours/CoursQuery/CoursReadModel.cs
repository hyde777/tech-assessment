namespace WeChooz.TechAssessment.Domain.Cours.CoursQuery;

public class CoursReadModel
{
    public int Id { get; set; }
    public string Nom { get; set; }
    public PersonneReadModel Formateur { get; set; }
    public int CapaciteMaximal { get; set; }
    public PopulationCibleEnum PopulationCible { get; set; }
    public string CourteDescription { get; set; }
    public string LongueDescription { get; set; }
    public int DureeEnJours { get; set; }
}