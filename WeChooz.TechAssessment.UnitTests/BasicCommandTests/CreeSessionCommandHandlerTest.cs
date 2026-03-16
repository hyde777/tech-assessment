using FluentAssertions;
using NSubstitute;
using WeChooz.TechAssessment.Domain;
using WeChooz.TechAssessment.Domain.Sessions.CreeSessionCommand;

namespace WeChooz.TechAssessment.UnitTests.BasicCommandTests;

public class CreeSessionCommandHandlerTest
{
    private readonly List<int> _idParticipants = [4, 5, 6];
    private readonly ICreeRepository<CreeSessionModel> _sessionRepository = Substitute.For<ICreeRepository<CreeSessionModel>>();
    private readonly BasicCreeCommandHandler<CreeSessionCommand, CreeSessionModel> _handler;
    private const int IdSessionCree = 5;
    private const int IdCours = 7;

    public CreeSessionCommandHandlerTest()
    {
        _handler = new BasicCreeCommandHandler<CreeSessionCommand, CreeSessionModel>(_sessionRepository, new CreeSessionMapper());
    }

    [Fact]
    public async Task Should_Cree_une_session()
    {
        CreeSessionCommand command = new CreeSessionCommand
        {
            IdCours = IdCours,
            IdParticipants = _idParticipants,
            ModeDelivrance = ModeDelivrance.Distanciel,
            DateDebut = DateTime.Today
        };
        CreeSessionModel creeSessionModel = new CreeSessionModel();
        _sessionRepository.Add(Arg.Do<CreeSessionModel>(x => creeSessionModel = x), Arg.Any<CancellationToken>())
            .Returns(IdSessionCree);

        var result = await _handler.Handle(command, CancellationToken.None);

        result.Should().Be(IdSessionCree);
        creeSessionModel.Should().BeEquivalentTo(new CreeSessionModel
        {
            IdCours = IdCours,
            IdParticipants = _idParticipants,
            ModeDelivrance = ModeDelivrance.Distanciel,
            DateDebut = DateTime.Today
        });
    }
}