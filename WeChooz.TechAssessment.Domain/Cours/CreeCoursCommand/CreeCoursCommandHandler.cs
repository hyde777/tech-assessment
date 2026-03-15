namespace WeChooz.TechAssessment.Domain.Cours.CreeCoursCommand;

public class CreeCoursCommandHandler
{
    private readonly ICoursRepository _coursrepository;

    public CreeCoursCommandHandler(ICoursRepository coursrepository)
    {
        _coursrepository = coursrepository;
    }

    public async Task<int> Handle(CreeCoursCommand command, CancellationToken cancellationToken)
    {
        var coursCreateModel = new CoursCreateModel
        {
            CourteDescription = command.CourteDescription,
            CapaciteMaximal = command.CapaciteMaximal,
            Nom = command.Nom,
            PopulationCibleEnum = command.PopulationCibleEnum
        };
        var id = await _coursrepository.Add(coursCreateModel, cancellationToken);

        return id;
    }
}