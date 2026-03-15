using WeChooz.TechAssessment.Domain.Cours.CreeCoursCommand;

namespace WeChooz.TechAssessment.Domain;

public class BasicQueryHandler<Query, ReadModel, QueryDto>
{
    private readonly IReadRepository<ReadModel> _coursRepository;
    private readonly IMap<ReadModel, QueryDto> _coursQueryDtoMapper;

    public BasicQueryHandler(IReadRepository<ReadModel> coursRepository, IMap<ReadModel,  QueryDto> coursQueryDtoMapper)
    {
        _coursRepository = coursRepository;
        _coursQueryDtoMapper = coursQueryDtoMapper;
    }

    public async Task<List<QueryDto>> Handle(Query coursQuery, CancellationToken cancellationToken)
    {
        var coursReadModels = await _coursRepository.GetAll(cancellationToken);
        return coursReadModels.Select(x => _coursQueryDtoMapper.MapFrom(x)).ToList();
    }
}