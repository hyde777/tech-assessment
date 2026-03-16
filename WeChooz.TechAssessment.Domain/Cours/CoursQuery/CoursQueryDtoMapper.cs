using WeChooz.TechAssessment.Domain.Cours.CoursQuery;

namespace WeChooz.TechAssessment.Domain.Cours.CreeCoursCommand;

public class CoursQueryDtoMapper : IMap<CoursReadModel,  CoursQueryDto>
{
    public CoursQueryDto MapFrom(CoursReadModel readModel) =>
        new()
        {
            Id =  readModel.Id,
            Nom = readModel.Nom,
            CourteDescription = readModel.CourteDescription,
            LongueDescription = readModel.LongueDescription,
            DureeEnJours = readModel.DureeEnJours,
            PopulationCible = readModel.PopulationCible,
            CapaciteMaximal = readModel.CapaciteMaximal,
            NomFormateur = readModel.Formateur.Nom,
            PrenomFormateur = readModel.Formateur.Prenom
        };
}