using FluentAssertions;
using NSubstitute;
using WeChooz.TechAssessment.Domain.Cours;

namespace WeChooz.TechAssessment.UnitTests;

public class GetCoursHandlerTest
{
    [Fact]
    public async Task Should_Handle_return_les_cours()
    {
        var coursRepository = Substitute.For<ICoursRepository>();
        var coursReadModels = new List<CoursReadModel>()
        {
            new CoursReadModel()
            {
                Nom = "NomCours",
                CourteDescription = "CourteDescription",
                LongueDescription = "LongueDescription",
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
        coursRepository.GetAll(Arg.Any<CancellationToken>()).Returns(coursReadModels);
        var handler = new GetCoursQueryHandler(coursRepository);
        var getCoursQuery = new GetCoursQuery();

        var result = await handler.Handle(getCoursQuery, CancellationToken.None);

        result.Should().BeEquivalentTo(
        [
            new CoursQueryDto
            {
                Nom = "NomCours",
                CourteDescription = "CourteDescription",
                LongueDescription = "LongueDescription",
                Duree = 2,
                PopulationCible = PopulationCibleEnum.Elu,
                CapaciteMaximal = 10,
                NomFormateur = "NomFormateur",
                PrenomFormateur = "PrenomFormateur"
            }
        ]);
    }
}