using FluentAssertions;
using NSubstitute;
using WeChooz.TechAssessment.Domain;
using WeChooz.TechAssessment.Domain.Sessions;

namespace WeChooz.TechAssessment.UnitTests;

public class CreeSessionCommandHandlerTest
{
    private const int IdSessionCree = 5;
    private const int IdCours = 7;

    [Fact]
    public async Task METHOD()
    {
        SessionCreateCommand command = new SessionCreateCommand
        {
            IdCours = IdCours,
            IdParticipants = [4, 5, 6],
            ModeDelivrance = ModeDelivrance.Distanciel,
            DateDebut = DateTime.Today
        };
        var sessionRepository = Substitute.For<ISessionRepository>();
        SessionCreateModel sessionCreateModel = new SessionCreateModel();
        sessionRepository.Add(Arg.Do<SessionCreateModel>(x => sessionCreateModel = x), Arg.Any<CancellationToken>())
            .Returns(IdSessionCree);
        SessionCreateCommandHandler handler = new SessionCreateCommandHandler(sessionRepository);

        var result = await handler.Handle(command, CancellationToken.None);

        result.Should().Be(IdSessionCree);
        sessionCreateModel.Should().BeEquivalentTo(new SessionCreateModel
        {
            IdCours = IdCours,
            IdParticipants = [4, 5, 6],
            ModeDelivrance = ModeDelivrance.Distanciel,
            DateDebut = DateTime.Today
        });
    }
}