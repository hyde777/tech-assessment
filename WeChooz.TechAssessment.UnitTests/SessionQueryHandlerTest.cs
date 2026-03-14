using FluentAssertions;
using NSubstitute;

namespace WeChooz.TechAssessment.UnitTests;

public class SessionQueryHandlerTest
{
    [Fact]
    public async Task Should_return_les_sessions()
    {
        ISessionRepository sessionRepository = Substitute.For<ISessionRepository>();
        sessionRepository.GetAll(Arg.Any<CancellationToken>()).Returns(SessionReadModels());
        SessionQueryHandler handler = new SessionQueryHandler(sessionRepository);

        var handle = await handler.Handle(new SessionQuery(), CancellationToken.None);

        handle.Should().BeEquivalentTo(
        [
            new SessionReadDto
            {
                Id = 10,
                IdSession = 4,
                IdCours = 2,
                IdParticipants = [5,6,7],
                PopulationCible = PopulationCibleEnum.Elu,
                ModeDelivrance = ModeDelivrance.Presentiel,
                DateDebutSession = DateTime.Today
            }
        ]);
    }

    private static List<SessionReadModel> SessionReadModels()
    {
        return [
            new SessionReadModel
            {
                Id = 10,
                IdSession = 4,
                IdCours = 2,
                IdParticipants = [5,6,7],
                PopulationCible = PopulationCibleEnum.Elu,
                ModeDelivrance = ModeDelivrance.Presentiel,
                DateDebutSession = DateTime.Today
            }
        ];
    }
}

public enum ModeDelivrance
{
    Presentiel,
    Distanciel
}

public class SessionReadDto
{
    public int Id { get; set; }
    public int IdSession { get; set; }
    public int IdCours { get; set; }
    public List<int> IdParticipants { get; set; }
    public PopulationCibleEnum PopulationCible { get; set; }
    public ModeDelivrance ModeDelivrance { get; set; }
    public DateTime DateDebutSession { get; set; }
}

public class SessionQueryHandler
{
    private readonly ISessionRepository _sessionRepository;

    public SessionQueryHandler(ISessionRepository sessionRepository)
    {
        _sessionRepository = sessionRepository;
    }

    public Task<List<SessionReadDto>> Handle(SessionQuery sessionQuery, CancellationToken none)
    {
        throw new NotImplementedException();
    }
}

public interface ISessionRepository
{
    Task<List<SessionReadModel>> GetAll(CancellationToken any);
}

public class SessionQuery
{
}

public class SessionReadModel
{
    public int Id { get; set; }
    public int IdSession { get; set; }
    public int IdCours { get; set; }
    public List<int> IdParticipants { get; set; }
    public PopulationCibleEnum PopulationCible { get; set; }
    public ModeDelivrance ModeDelivrance { get; set; }
    public DateTime DateDebutSession { get; set; }
}