using FluentAssertions;
using NSubstitute;
using WeChooz.TechAssessment.Domain;
using WeChooz.TechAssessment.Domain.Sessions;
using WeChooz.TechAssessment.Domain.Sessions.SessionQuery;

namespace WeChooz.TechAssessment.UnitTests;

public class SessionQueryHandlerTest
{
    private readonly ISessionRepository _sessionRepository = Substitute.For<ISessionRepository>();
    private SessionQueryHandler _handler;

    public SessionQueryHandlerTest()
    {
        _handler = new SessionQueryHandler(_sessionRepository);
    }

    [Fact]
    public async Task Should_return_les_sessions()
    {
        _sessionRepository.GetAll(Arg.Any<CancellationToken>()).Returns(SessionReadModels());

        var handle = await _handler.Handle(new SessionQuery(), CancellationToken.None);

        handle.Should().BeEquivalentTo(
        [
            new SessionDto
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