namespace WeChooz.TechAssessment.Domain.Sessions.SessionQuery;

public class SessionDto
{
    public int Id { get; set; }
    public int IdSession { get; set; }
    public int IdCours { get; set; }
    public List<int> IdParticipants { get; set; }
    public PopulationCibleEnum PopulationCible { get; set; }
    public ModeDelivrance ModeDelivrance { get; set; }
    public DateTime DateDebutSession { get; set; }
}