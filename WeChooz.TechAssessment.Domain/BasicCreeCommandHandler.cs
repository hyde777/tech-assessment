using WeChooz.TechAssessment.Domain.Cours.CreeCoursCommand;

namespace WeChooz.TechAssessment.Domain;

public class BasicCreeCommandHandler<CreeCommand, CreeModel>
{
    private readonly ICreeRepository<CreeModel> _coursrepository;
    private readonly IMap<CreeCommand, CreeModel> _creeCoursMapper;

    public BasicCreeCommandHandler(ICreeRepository<CreeModel> coursrepository, IMap<CreeCommand, CreeModel> creeCoursMapper)
    {
        _coursrepository = coursrepository;
        _creeCoursMapper = creeCoursMapper;
    }

    public async Task<int> Handle(CreeCommand command, CancellationToken cancellationToken)
    {
        var coursCreateModel = _creeCoursMapper.MapFrom(command);
        var id = await _coursrepository.Add(coursCreateModel, cancellationToken);

        return id;
    }
}