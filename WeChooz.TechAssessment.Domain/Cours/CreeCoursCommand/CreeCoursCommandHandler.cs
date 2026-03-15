namespace WeChooz.TechAssessment.Domain.Cours.CreeCoursCommand;

public class CreeCoursCommandHandler
{
    private readonly ICreeRepository<CreeCoursModel> _coursrepository;
    private readonly IMap<CreeCoursCommand, CreeCoursModel> _creeCoursMapper;

    public CreeCoursCommandHandler(ICreeRepository<CreeCoursModel> coursrepository, IMap<CreeCoursCommand, CreeCoursModel> creeCoursMapper)
    {
        _coursrepository = coursrepository;
        _creeCoursMapper = creeCoursMapper;
    }

    public async Task<int> Handle(CreeCoursCommand command, CancellationToken cancellationToken)
    {
        var coursCreateModel = _creeCoursMapper.MapFrom(command);
        var id = await _coursrepository.Add(coursCreateModel, cancellationToken);

        return id;
    }
}