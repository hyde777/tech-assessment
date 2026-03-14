namespace WeChooz.TechAssessment.Domain.Cours;

public class GetCoursQueryHandler
{
    private readonly ICoursRepository _coursRepository;

    public GetCoursQueryHandler(ICoursRepository coursRepository)
    {
        _coursRepository = coursRepository;
    }

    public async Task<List<CoursQueryDto>> Handle(GetCoursQuery getCoursQuery, CancellationToken cancellationToken)
    {
        var coursReadModels = await _coursRepository.GetAll(cancellationToken);
        return coursReadModels.Select(x => new CoursQueryDto
        {
            Nom = x.Nom,
            CourteDescription = x.CourteDescription,
            LongueDescription = x.LongueDescription,
            Duree = x.Duree,
            PopulationCible = x.PopulationCible,
            CapaciteMaximal = x.CapaciteMaximal,
            NomFormateur = x.Formateur.Nom,
            PrenomFormateur = x.Formateur.Prenom
        }).ToList();
    }
}