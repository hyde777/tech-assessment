using WeChooz.TechAssessment.Domain.Participants.CreeParticipantCommand;
using WeChooz.TechAssessment.Domain.Participants.ParticipantQuery;

namespace WeChooz.TechAssessment.Domain.Participants;

public interface IParticipantRepository
{
    Task<List<ParticipantReadModel>> GetAll(CancellationToken cancellationToken);
    Task<int> Add(CreeParticipantModel creeParticipantModel, CancellationToken cancellationToken);
}