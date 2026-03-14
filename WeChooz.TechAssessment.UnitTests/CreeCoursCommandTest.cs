using FluentAssertions;
using NSubstitute;
using WeChooz.TechAssessment.Domain.Cours;

namespace WeChooz.TechAssessment.UnitTests;

public class CreeCoursCommandTest
{
    private const int IdCoursCreated = 4;
    private const string Nouveaucours = "NouveauCours";
    private const int CapaciteMaximal = 20;
    private const PopulationCibleEnum PopulationCibleEnum = UnitTests.PopulationCibleEnum.PresidentDeCse;
    private const string CourteDescription = "CourteDescription";

    [Fact]
    public async Task METHOD()
    {
        CreeCoursCommand command = new CreeCoursCommand()
        {
            Nom = Nouveaucours,
            CourteDescription = CourteDescription,
            PopulationCibleEnum = PopulationCibleEnum,
            CapaciteMaximal = CapaciteMaximal
        };
        ICoursRepository coursrepository = Substitute.For<ICoursRepository>();
        CoursCreateModel createModel = new CoursCreateModel();
        coursrepository.Add(Arg.Do<CoursCreateModel>(x => createModel = x))
            .Returns(IdCoursCreated);
        var handler = new CreeCoursCommandHandler(coursrepository);

        var result = await handler.Handle(command, CancellationToken.None);

        createModel.Should().BeEquivalentTo(new CoursCreateModel
        {
            Nom = Nouveaucours,
            CourteDescription = CourteDescription,
            PopulationCibleEnum = PopulationCibleEnum,
            CapaciteMaximal = CapaciteMaximal
        });
        result.Should().Be(IdCoursCreated);
    }
}

public class CreeCoursCommandHandler
{
    public CreeCoursCommandHandler(ICoursRepository coursrepository)
    {
        throw new NotImplementedException();
    }

    public Task<int> Handle(CreeCoursCommand command, CancellationToken none)
    {
        throw new NotImplementedException();
    }
}

public class CreeCoursCommand
{
    public string Nom { get; set; }
    public string CourteDescription { get; set; }
    public PopulationCibleEnum PopulationCibleEnum { get; set; }
    public int CapaciteMaximal { get; set; }
}