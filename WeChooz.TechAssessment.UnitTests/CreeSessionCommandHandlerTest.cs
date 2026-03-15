using FluentAssertions;
using NSubstitute;
using WeChooz.TechAssessment.Domain;
using WeChooz.TechAssessment.Domain.Sessions;
using WeChooz.TechAssessment.Domain.Sessions.CreeSessionCommand;

namespace WeChooz.TechAssessment.UnitTests;

public class CreeSessionCommandHandlerTest
{
    private readonly List<int> _idParticipants = [4, 5, 6];
    private readonly ISessionRepository _sessionRepository = Substitute.For<ISessionRepository>();
    private readonly SessionCreateCommandHandler _handler;
    private const int IdSessionCree = 5;
    private const int IdCours = 7;

    public CreeSessionCommandHandlerTest()
    {
        _handler = new SessionCreateCommandHandler(_sessionRepository);
    }

    [Fact]
    public async Task Should_Cree_une_session()
    {
        SessionCreateCommand command = new SessionCreateCommand
        {
            IdCours = IdCours,
            IdParticipants = _idParticipants,
            ModeDelivrance = ModeDelivrance.Distanciel,
            DateDebut = DateTime.Today
        };
        SessionCreateModel sessionCreateModel = new SessionCreateModel();
        _sessionRepository.Add(Arg.Do<SessionCreateModel>(x => sessionCreateModel = x), Arg.Any<CancellationToken>())
            .Returns(IdSessionCree);

        var result = await _handler.Handle(command, CancellationToken.None);

        result.Should().Be(IdSessionCree);
        sessionCreateModel.Should().BeEquivalentTo(new SessionCreateModel
        {
            IdCours = IdCours,
            IdParticipants = _idParticipants,
            ModeDelivrance = ModeDelivrance.Distanciel,
            DateDebut = DateTime.Today
        });
    }
}