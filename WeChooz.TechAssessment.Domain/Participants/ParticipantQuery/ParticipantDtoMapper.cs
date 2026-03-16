using WeChooz.TechAssessment.Domain.Participants.ParticipantQuery;

namespace WeChooz.TechAssessment.Domain.Cours.CreeCoursCommand;

public class ParticipantDtoMapper : IMap<ParticipantReadModel,  ParticipantDto>
{
    public ParticipantDto MapFrom(ParticipantReadModel readModel) =>
        new ParticipantDto
        {
            Id = readModel.Id,
            IdPersonne = readModel.Personne.Id,
            Nom = readModel.Personne.Nom,
            Prenom = readModel.Personne.Prenom,
            Email = readModel.Email,
            Entreprise = readModel.Entreprise
        };
}