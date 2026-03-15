using WeChooz.TechAssessment.Domain.Cours.CoursQuery;

namespace WeChooz.TechAssessment.Domain.Cours.CreeCoursCommand;

public class CoursQueryDtoMapper : IMap<CoursReadModel,  CoursQueryDto>
{
    public CoursQueryDto MapFrom(CoursReadModel models) =>
        new()
        {
            Id =  models.Id,
            Nom = models.Nom,
            CourteDescription = models.CourteDescription,
            LongueDescription = models.LongueDescription,
            DureeEnJours = models.DureeEnJours,
            PopulationCible = models.PopulationCible,
            CapaciteMaximal = models.CapaciteMaximal,
            NomFormateur = models.Formateur.Nom,
            PrenomFormateur = models.Formateur.Prenom
        };
}