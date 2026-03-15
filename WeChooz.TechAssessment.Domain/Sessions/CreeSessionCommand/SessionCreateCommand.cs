namespace WeChooz.TechAssessment.Domain.Sessions.CreeSessionCommand;

public class SessionCreateCommand
{
    public int IdCours { get; set; }
    public List<int> IdParticipants { get; set; }
    public ModeDelivrance ModeDelivrance { get; set; }
    public DateTime DateDebut { get; set; }
}