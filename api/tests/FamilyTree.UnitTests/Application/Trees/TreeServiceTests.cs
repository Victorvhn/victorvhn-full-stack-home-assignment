using FamilyTree.Application.Persons;
using FamilyTree.Application.Trees;
using FamilyTree.Domain.Abstractions;
using FamilyTree.Domain.Persons;
using FamilyTree.Domain.Trees;
using FamilyTree.Shared.Tests;
using FluentAssertions;
using NSubstitute;

namespace FamilyTree.Domain.UnitTests.Application.Trees;

public class TreeServiceTests
{
    private readonly Bogus.Faker<Person> _personFaker = PersonFaker.GetFaker();
    private readonly IPersonRepository _personRepository = Substitute.For<IPersonRepository>();

    private readonly ITreeRepository _treeRepository = Substitute.For<ITreeRepository>();
    private readonly TreeService _treeService;

    public TreeServiceTests()
    {
        _treeService = new TreeService(_treeRepository, _personRepository);
    }

    [Fact]
    public async Task GetFamilyMembersByIdAsync_WhenTreeNotFound_ShouldReturnFailure()
    {
        // Arrange
        var treeId = Guid.NewGuid();
        _treeRepository.ExistsAsync(treeId).Returns(false);

        // Act
        Result<PersonDto[]> result = await _treeService.GetFamilyMembersByIdAsync(treeId);

        // Assert
        result.IsFailure.Should().BeTrue();
        result.Error.Should().Be(TreeErrors.NotFound(treeId));
    }

    [Fact]
    public async Task GetFamilyMembersByIdAsync_WhenTreeExists_ShouldReturnMembers()
    {
        // Arrange
        var treeId = Guid.NewGuid();

        List<Person> members = _personFaker
            .RuleFor(person => person.FamilyTreeId, treeId)
            .Generate(2);

        _treeRepository.ExistsAsync(treeId).Returns(true);
        _personRepository.GetByTreeIdAsync(treeId).Returns(members);

        // Act
        Result<PersonDto[]> result = await _treeService.GetFamilyMembersByIdAsync(treeId);

        // Assert
        result.IsSuccess.Should().BeTrue();
        result.Value.Should().BeEquivalentTo(members, config =>
            config
                .ExcludingMissingMembers()
                .WithMapping<Person, PersonDto>(person => person.Id, dto => dto.PersonId)
        );
    }
}
