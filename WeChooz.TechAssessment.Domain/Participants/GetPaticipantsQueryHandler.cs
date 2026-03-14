namespace WeChooz.TechAssessment.UnitTests;

public class GetPaticipantsQueryHandler
{
    private readonly IParticipantRepository _participantRepository;

    public GetPaticipantsQueryHandler(IParticipantRepository participantRepository)
    {
        _participantRepository = participantRepository;
    }

    public async Task<List<ParticipantDto>> Handle(GetParticipantsQuery query, CancellationToken none)
    {
        throw new NotImplementedException();
    }
}