using WeChooz.TechAssessment.Domain.Participants.ParticipantQuery;

namespace WeChooz.TechAssessment.Domain.Cours.CreeCoursCommand;

public class ParticipantDtoMapper : IMap<ParticipantReadModel,  ParticipantQueryDto>
{
    public ParticipantQueryDto MapFrom(ParticipantReadModel readModel) =>
        new ParticipantQueryDto
        {
            Id = readModel.Id,
            IdPersonne = readModel.Personne.Id,
            Nom = readModel.Personne.Nom,
            Prenom = readModel.Personne.Prenom,
            Email = readModel.Email,
            Entreprise = readModel.Entreprise
        };
}