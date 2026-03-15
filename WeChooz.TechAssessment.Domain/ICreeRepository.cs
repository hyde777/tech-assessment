namespace WeChooz.TechAssessment.Domain;

public interface ICreeRepository<CreeModel>
{
    Task<int> Add(CreeModel creeParticipantModel, CancellationToken cancellationToken);
}