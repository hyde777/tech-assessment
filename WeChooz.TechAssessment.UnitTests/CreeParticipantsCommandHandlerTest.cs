using FluentAssertions;
using NSubstitute;
using WeChooz.TechAssessment.Domain.Participants;

namespace WeChooz.TechAssessment.UnitTests;

public class CreeParticipantsCommandHandlerTest
{
    private const string Entreprise = "Entreprise";
    private const string Email = "email";
    private const string Prenom = "Prenom";
    private const string Nom = "Nom";

    private const int IdNewParticipant = 8;

    [Fact]
    public void METHOD()
    {
        CreeParticipantCommand command = new CreeParticipantCommand();
        var participantRepository = Substitute.For<IParticipantRepository>();
        var creeParticipantModel = new CreeParticipantModel();
        participantRepository.Add(Arg.Do<CreeParticipantModel>(x => creeParticipantModel = x), CancellationToken.None);
        var handler = new CreeParticipantCommandHandler(participantRepository);

        var result = handler.Handle(command, CancellationToken.None);

        result.Should().Be(IdNewParticipant);
        creeParticipantModel.Should().BeEquivalentTo(new CreeParticipantModel
        {
            Nom = Nom,
            Prenom = Prenom,
            Email = Email,
            Entreprise = Entreprise
        });
    }
}