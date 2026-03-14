using WeChooz.TechAssessment.UnitTests;

namespace WeChooz.TechAssessment.Domain.Cours;

public class CoursQueryDto
{
    public int Id { get; set; }
    public string Nom { get; set; }
    public string CourteDescription { get; set; }
    public string LongueDescription { get; set; }
    public int DureeEnJours { get; set; }
    public PopulationCibleEnum PopulationCible { get; set; }
    public int CapaciteMaximal { get; set; }
    public string NomFormateur { get; set; }
    public string PrenomFormateur { get; set; }
}