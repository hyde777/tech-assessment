using FluentAssertions;
using NSubstitute;
using WeChooz.TechAssessment.Domain;
using WeChooz.TechAssessment.Domain.Cours.CreeCoursCommand;
using WeChooz.TechAssessment.Domain.Participants.CreeParticipantCommand;

namespace WeChooz.TechAssessment.UnitTests;

public class CreeParticipantsCommandHandlerTest
{
    private const string Entreprise = "Entreprise";
    private const string Email = "email";
    private const string Prenom = "Prenom";
    private const string Nom = "Nom";
    private const int IdNewParticipant = 8;

    private readonly ICreeRepository<CreeParticipantModel> _participantRepository = Substitute.For<ICreeRepository<CreeParticipantModel>>();
    private readonly BasicCreeCommandHandler<CreeParticipantCommand, CreeParticipantModel> _handler;

    public CreeParticipantsCommandHandlerTest()
    {
        _handler = new BasicCreeCommandHandler<CreeParticipantCommand, CreeParticipantModel>(_participantRepository, new CreeParticipantMapper());
    }

    [Fact]
    public async Task Should_Cree_un_nouveau_participant()
    {
        CreeParticipantCommand command = new CreeParticipantCommand
        {
            Nom = Nom,
            Prenom = Prenom,
            Email = Email,
            Entreprise = Entreprise
        };
        var creeParticipantModel = new CreeParticipantModel();
        _participantRepository.Add(Arg.Do<CreeParticipantModel>(x => creeParticipantModel = x), CancellationToken.None)
            .Returns(IdNewParticipant);

        var result = await _handler.Handle(command, CancellationToken.None);

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