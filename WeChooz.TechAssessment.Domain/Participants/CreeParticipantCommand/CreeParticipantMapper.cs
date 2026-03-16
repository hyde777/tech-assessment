using WeChooz.TechAssessment.Domain.Cours.CreeCoursCommand;

namespace WeChooz.TechAssessment.Domain.Participants.CreeParticipantCommand;

public class CreeParticipantMapper : IMap<CreeParticipantCommand,  CreeParticipantModel>
{
    public CreeParticipantModel MapFrom(CreeParticipantCommand command) =>
        new()
        {
            Email = command.Email,
            Entreprise = command.Entreprise,
            Nom =  command.Nom,
            Prenom = command.Prenom
        };

}