using WeChooz.TechAssessment.Domain.Participants;

namespace WeChooz.TechAssessment.UnitTests;

public class CreeParticipantCommandHandler
{
    private readonly IParticipantRepository _participantRepository;

    public CreeParticipantCommandHandler(IParticipantRepository participantRepository)
    {
        _participantRepository = participantRepository;
    }

    public async Task<int> Handle(CreeParticipantCommand command, CancellationToken cancellationToken)
    {
        var newParticipantId = await _participantRepository.Add(new CreeParticipantModel
        {
            Email = command.Email,
            Entreprise = command.Entreprise,
            Nom =  command.Nom,
            Prenom = command.Prenom
        }, cancellationToken);

        return newParticipantId;
    }
}