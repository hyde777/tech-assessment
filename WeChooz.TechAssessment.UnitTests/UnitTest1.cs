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