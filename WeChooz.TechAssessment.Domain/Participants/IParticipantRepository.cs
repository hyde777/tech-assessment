namespace WeChooz.TechAssessment.Domain.Participants;

public interface IParticipantRepository
{
    Task<List<ParticipantReadModel>> GetAll(CancellationToken cancellationToken);
}