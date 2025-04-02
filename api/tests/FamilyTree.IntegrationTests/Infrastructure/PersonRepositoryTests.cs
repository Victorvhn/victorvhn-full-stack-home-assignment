using FamilyTree.Domain.Persons;
using FamilyTree.Infrastructure.Databases;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;

namespace FamilyTree.IntegrationTests.Infrastructure;

public sealed class PersonRepositoryTests : BaseIntegrationTest
{
    private readonly IPersonRepository _personRepository;

    public PersonRepositoryTests(IntegrationTestWebAppFactory factory) : base(factory)
    {
        _personRepository = ServiceProvider.GetRequiredService<IPersonRepository>();
    }

    [Fact]
    public async Task GetByTreeIdAsync_ShouldReturnTreeFamilyRelatedMembers()
    {
        // Arrange
        var treeId = Guid.Parse("0195f373-c5e5-70b6-95be-7e7e003b4b7a");
        Person[] expectedPersons = SeedData.GeneratePersons()[..10];

        // Act
        Person[] members = (await _personRepository.GetByTreeIdAsync(treeId)).ToArray();

        // Assert
        members.Should().BeEquivalentTo(expectedPersons);
    }
}
