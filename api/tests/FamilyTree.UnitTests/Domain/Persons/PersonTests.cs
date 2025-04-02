using Bogus;
using FamilyTree.Domain.Persons.Resources;
using FamilyTree.Shared.Tests;
using FluentAssertions;
using Person = FamilyTree.Domain.Persons.Person;

namespace FamilyTree.Domain.UnitTests.Domain.Persons;

public class PersonTests
{
    [Fact]
    public void DisplayName_WhenBirthDateAndDeathDateAreProvided_ShouldReturnBirthAndDeathYears()
    {
        // Arrange
        Faker<Person>? faker = PersonFaker.GetFaker()
            .RuleFor(p => p.BirthDate, f => new DateTime(1950, 1, 1, 0, 0, 0, DateTimeKind.Utc))
            .RuleFor(p => p.DeathDate, f => new DateTime(2000, 1, 1, 0, 0, 0, DateTimeKind.Utc));

        // Act
        Person person = faker.Generate();
        string expected = $"{person.GivenName} {person.Surname} (1950-2000)";

        // Assert
        person.DisplayName.Should().Be(expected);
    }

    [Fact]
    public void DisplayName_WhenOnlyDeathDateIsProvided_ShouldReturnDeathYearOnly()
    {
        // Arrange
        Faker<Person>? faker = PersonFaker.GetFaker()
            .RuleFor(p => p.BirthDate, f => null)
            .RuleFor(p => p.DeathDate, f => new DateTime(2000, 1, 1, 0, 0, 0, DateTimeKind.Utc));

        // Act
        Person person = faker.Generate();
        string expected = $"{person.GivenName} {person.Surname} (-2000)";

        // Assert
        person.DisplayName.Should().Be(expected);
    }

    [Fact]
    public void DisplayName_WhenBirthAndDeathDatesAreNotProvided_ShouldReturnLiving()
    {
        // Arrange
        Faker<Person>? faker = PersonFaker.GetFaker()
            .RuleFor(p => p.BirthDate, f => null)
            .RuleFor(p => p.DeathDate, f => null);

        // Act
        Person person = faker.Generate();
        string expected = $"{person.GivenName} {person.Surname} ({PersonResources.Lifespan_Living})";

        // Assert
        person.DisplayName.Should().Be(expected);
    }

    [Fact]
    public void DisplayName_WhenBirthDateOnlyAndAgeLessThanMax_ShouldReturnLiving()
    {
        // Arrange
        int currentYear = DateTime.UtcNow.Year;
        var birthDate = new DateTime(currentYear - 50, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        Faker<Person>? faker = PersonFaker.GetFaker()
            .RuleFor(p => p.BirthDate, f => birthDate)
            .RuleFor(p => p.DeathDate, f => null);

        // Act
        Person person = faker.Generate();
        string expected = $"{person.GivenName} {person.Surname} ({PersonResources.Lifespan_Living})";

        // Assert
        person.DisplayName.Should().Be(expected);
    }

    [Fact]
    public void DisplayName_WhenBirthDateOnlyAndAgeAtLeastMax_ShouldReturnBirthYearDash()
    {
        // Arrange
        var birthDate = new DateTime(1900, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        Faker<Person>? faker = PersonFaker.GetFaker()
            .RuleFor(p => p.BirthDate, f => birthDate)
            .RuleFor(p => p.DeathDate, f => null);

        // Act
        Person person = faker.Generate();
        string expected = $"{person.GivenName} {person.Surname} (1900-)";

        // Assert
        person.DisplayName.Should().Be(expected);
    }
}
