namespace WeChooz.TechAssessment.Domain.Cours.CoursQuery;

public class CoursQueryHandler
{
    private readonly IReadRepository<CoursReadModel> _coursRepository;

    public CoursQueryHandler(IReadRepository<CoursReadModel> coursRepository)
    {
        _coursRepository = coursRepository;
    }

    public async Task<List<CoursQueryDto>> Handle(CoursQuery coursQuery, CancellationToken cancellationToken)
    {
        var coursReadModels = await _coursRepository.GetAll(cancellationToken);
        return coursReadModels.Select(x => new CoursQueryDto
        {
            Id =  x.Id,
            Nom = x.Nom,
            CourteDescription = x.CourteDescription,
            LongueDescription = x.LongueDescription,
            DureeEnJours = x.DureeEnJours,
            PopulationCible = x.PopulationCible,
            CapaciteMaximal = x.CapaciteMaximal,
            NomFormateur = x.Formateur.Nom,
            PrenomFormateur = x.Formateur.Prenom
        }).ToList();
    }
}