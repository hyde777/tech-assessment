namespace WeChooz.TechAssessment.Domain.Participants.ParticipantQuery;

public class ParticipantQueryDto
{
    public int Id { get; set; }
    public string Nom { get; set; }
    public string Prenom { get; set; }
    public string Email { get; set; }
    public string Entreprise { get; set; }
    public int IdPersonne { get; set; }
}