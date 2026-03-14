using WeChooz.TechAssessment.UnitTests;

namespace WeChooz.TechAssessment.Domain.Participants;

public class ParticipantReadModel
{
    public int Id { get; set; }
    public PersonneReadModel Personne { get; set; }
    public string Email { get; set; }
    public string Entreprise { get; set; }
}