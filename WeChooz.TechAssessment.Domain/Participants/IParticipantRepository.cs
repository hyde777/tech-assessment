namespace WeChooz.TechAssessment.UnitTests;

public interface IParticipantRepository
{
    Task<List<ParticipantReadModel>> GetAll(CancellationToken cancellationToken);
}