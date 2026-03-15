using WeChooz.TechAssessment.UnitTests;

namespace WeChooz.TechAssessment.Domain.Participants;

public interface IParticipantRepository
{
    Task<List<ParticipantReadModel>> GetAll(CancellationToken cancellationToken);
    Task<int> Add(CreeParticipantModel creeParticipantModel, CancellationToken cancellationToken);
}