using FluentAssertions;
using NSubstitute;

namespace WeChooz.TechAssessment.UnitTests;

public class UnitTest1
{
    [Fact]
    public async Task Should_Handle_return_les_cours()
    {
        var coursRepository = Substitute.For<ICoursRepository>();
        var coursReadModels = new List<CoursReadModel>()
        {
            new CoursReadModel()
            {
                Nom = "",
                CourteDescription = "",
                LongueDescription = "",
                Duree = 2,
                PopulationCible = PopulationCibleEnum.Elu,
                CapaciteMaximal = 10,
                Formateur = new PersonneReadModel
                {
                    Nom = "NomFormateur",
                    Prenom = "PrenomFormateur"
                }
            }
        };
        coursRepository.GetAll().Returns(coursReadModels);
        var handler = new GetCoursQueryHandler(coursRepository);
        var getCoursQuery = new GetCoursQuery();

        var result = await handler.Handle(getCoursQuery);

        result.Should().BeEquivalentTo(
        [
            new CoursQueryDto
            {
                Nom = "",
                CourteDescription = "",
                LongueDescription = "",
                Duree = 2,
                PopulationCible = PopulationCibleEnum.Elu,
                CapaciteMaximal = 10,
                NomFormateur = "NomFormateur",
                PrenomFormateur = "PrenomFormateur"
            }
        ]);
    }
}

public class PersonneReadModel
{
    public string Nom { get; set; }
    public string Prenom { get; set; }
}

public enum PopulationCibleEnum
{
    Elu,
    PresidentDeCse
}

public class CoursQueryDto
{
    public string Nom { get; set; }
    public string CourteDescription { get; set; }
    public string LongueDescription { get; set; }
    public int Duree { get; set; }
    public PopulationCibleEnum PopulationCible { get; set; }
    public int CapaciteMaximal { get; set; }
    public string NomFormateur { get; set; }
    public string PrenomFormateur { get; set; }
}

public class GetCoursQuery
{
}

public class GetCoursQueryHandler
{
    public GetCoursQueryHandler(ICoursRepository coursRepository)
    {
        throw new NotImplementedException();
    }

    public Task<List<CoursQueryDto>> Handle(GetCoursQuery getCoursQuery)
    {
        throw new NotImplementedException();
    }
}

public interface ICoursRepository
{
    List<CoursReadModel> GetAll();
}

public class CoursReadModel
{
    public string Nom { get; set; }
    public PersonneReadModel Formateur { get; set; }
    public int CapaciteMaximal { get; set; }
    public PopulationCibleEnum PopulationCible { get; set; }
    public string CourteDescription { get; set; }
    public string LongueDescription { get; set; }
    public int Duree { get; set; }
}