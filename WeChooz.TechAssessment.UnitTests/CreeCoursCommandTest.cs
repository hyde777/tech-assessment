using FluentAssertions;
using NSubstitute;
using WeChooz.TechAssessment.Domain;
using WeChooz.TechAssessment.Domain.Cours;
using WeChooz.TechAssessment.Domain.Cours.CreeCoursCommand;

namespace WeChooz.TechAssessment.UnitTests;

public class CreeCoursCommandTest
{
    private ICoursRepository _coursrepository = Substitute.For<ICoursRepository>();
    private CreeCoursCommandHandler _handler;
    private const int IdCoursCreated = 4;
    private const string Nouveaucours = "NouveauCours";
    private const int CapaciteMaximal = 20;
    private const PopulationCibleEnum PopulationCibleEnum = Domain.PopulationCibleEnum.PresidentDeCse;
    private const string CourteDescription = "CourteDescription";

    public CreeCoursCommandTest()
    {
        _handler = new CreeCoursCommandHandler(_coursrepository);
    }

    [Fact]
    public async Task Should_Cree_un_cours_classique()
    {
        CreeCoursCommand command = new CreeCoursCommand()
        {
            Nom = Nouveaucours,
            CourteDescription = CourteDescription,
            PopulationCibleEnum = PopulationCibleEnum,
            CapaciteMaximal = CapaciteMaximal
        };

        CreeCoursModel model = new CreeCoursModel();
        _coursrepository.Add(Arg.Do<CreeCoursModel>(x => model = x), Arg.Any<CancellationToken>())
            .Returns(IdCoursCreated);

        var result = await _handler.Handle(command, CancellationToken.None);

        model.Should().BeEquivalentTo(new CreeCoursModel
        {
            Nom = Nouveaucours,
            CourteDescription = CourteDescription,
            PopulationCibleEnum = PopulationCibleEnum,
            CapaciteMaximal = CapaciteMaximal
        });
        result.Should().Be(IdCoursCreated);
    }
}