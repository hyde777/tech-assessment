using WeChooz.TechAssessment.Domain.Cours.CreeCoursCommand;

namespace WeChooz.TechAssessment.Domain.Cours.CoursQuery;

public class CoursQueryHandler
{
    private readonly IReadRepository<CoursReadModel> _coursRepository;
    private readonly IMap<CoursReadModel, CoursQueryDto> _coursQueryDtoMapper;

    public CoursQueryHandler(IReadRepository<CoursReadModel> coursRepository, IMap<CoursReadModel,  CoursQueryDto> coursQueryDtoMapper)
    {
        _coursRepository = coursRepository;
        _coursQueryDtoMapper = coursQueryDtoMapper;
    }

    public async Task<List<CoursQueryDto>> Handle(CoursQuery coursQuery, CancellationToken cancellationToken)
    {
        var coursReadModels = await _coursRepository.GetAll(cancellationToken);
        return coursReadModels.Select(x => _coursQueryDtoMapper.MapFrom(x)).ToList();
    }
}