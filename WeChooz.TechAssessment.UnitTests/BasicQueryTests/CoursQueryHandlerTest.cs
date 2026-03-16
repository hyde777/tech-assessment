using FluentAssertions;
using NSubstitute;
using WeChooz.TechAssessment.Domain;
using WeChooz.TechAssessment.Domain.Cours.CoursQuery;

namespace WeChooz.TechAssessment.UnitTests.BasicQueryTests;

public class CoursQueryHandlerTest
{
    private const string NomCours = "NomCours";
    private const string CourteDescription = "CourteDescription";
    private const string LongueDescription = "LongueDescription";
    private const int Duree = 2;
    private const PopulationCibleEnum PopulationCibleEnum = Domain.PopulationCibleEnum.Elu;
    private const int CapaciteMaximal = 10;
    private const string NomFormateur = "NomFormateur";
    private const string PrenomFormateur = "PrenomFormateur";
    private const int Id = 1;
    private readonly IReadRepository<CoursReadModel> _coursRepository = Substitute.For<IReadRepository<CoursReadModel>>();
    private readonly BasicQueryHandler<CoursQuery, CoursReadModel, CoursQueryDto> _handler;

    public CoursQueryHandlerTest()
    {
        _handler = new BasicQueryHandler<CoursQuery, CoursReadModel, CoursQueryDto>(_coursRepository, new CoursQueryDtoMapper());
    }

    [Fact]
    public async Task Should_Handle_return_les_cours()
    {
        var coursReadModels = CoursReadModels();
        _coursRepository.GetAll(Arg.Any<CancellationToken>()).Returns(coursReadModels);
        var getCoursQuery = new CoursQuery();

        var result = await _handler.Handle(getCoursQuery, CancellationToken.None);

        result.Should().BeEquivalentTo(
        [
            new CoursQueryDto
            {
                Id = Id,
                Nom = NomCours,
                CourteDescription = CourteDescription,
                LongueDescription = LongueDescription,
                DureeEnJours = Duree,
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
                DureeEnJours = Duree,
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