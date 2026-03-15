namespace WeChooz.TechAssessment.Domain.Cours.CreeCoursCommand;

public class CreeCoursCommandHandler
{
    private readonly ICreeRepository<CreeCoursModel> _coursrepository;

    public CreeCoursCommandHandler(ICreeRepository<CreeCoursModel> coursrepository)
    {
        _coursrepository = coursrepository;
    }

    public async Task<int> Handle(CreeCoursCommand command, CancellationToken cancellationToken)
    {
        var coursCreateModel = new CreeCoursMapper().MapFrom(command);
        var id = await _coursrepository.Add(coursCreateModel, cancellationToken);

        return id;
    }
}