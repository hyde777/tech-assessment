using FluentAssertions;
using NSubstitute;
using WeChooz.TechAssessment.Domain.Cours;

namespace WeChooz.TechAssessment.UnitTests;

public class GetCoursQueryHandlerTest
{
    private const string NomCours = "NomCours";
    private const string CourteDescription = "CourteDescription";
    private const string LongueDescription = "LongueDescription";
    private const int Duree = 2;
    private const PopulationCibleEnum PopulationCibleEnum = UnitTests.PopulationCibleEnum.Elu;
    private const int CapaciteMaximal = 10;
    private const string NomFormateur = "NomFormateur";
    private const string PrenomFormateur = "PrenomFormateur";
    private const int Id = 1;
    private readonly ICoursRepository? _coursRepository = Substitute.For<ICoursRepository>();
    private GetCoursQueryHandler _handler;

    public GetCoursQueryHandlerTest()
    {
        _handler = new GetCoursQueryHandler(_coursRepository);
    }

    [Fact]
    public async Task Should_Handle_return_les_cours()
    {
        var coursReadModels = CoursReadModels();
        _coursRepository.GetAll(Arg.Any<CancellationToken>()).Returns(coursReadModels);
        var getCoursQuery = new GetCoursQuery();

        var result = await _handler.Handle(getCoursQuery, CancellationToken.None);

        result.Should().BeEquivalentTo(
        [
            new CoursQueryDto
            {
                Id = Id,
                Nom = NomCours,
                CourteDescription = CourteDescription,
                LongueDescription = LongueDescription,
                Duree = Duree,
                PopulationCible = PopulationCibleEnum,
                CapaciteMaximal = CapaciteMaximal,
                NomFormateur = NomFormateur,
                PrenomFormateur = PrenomFormateur
            }
        ]);
    }

    private static List<CoursReadModel> CoursReadModels()
    {
        return new List<CoursReadModel>()
        {
            new CoursReadModel()
            {
                Id = Id,
                Nom = NomCours,
                CourteDescription = CourteDescription,
                LongueDescription = LongueDescription,
                Duree = Duree,
                PopulationCible = PopulationCibleEnum,
                CapaciteMaximal = CapaciteMaximal,
                Formateur = new PersonneReadModel
                {
                    Nom = NomFormateur,
                    Prenom = PrenomFormateur
                }
            }
        };
    }
}