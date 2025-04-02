using FamilyTree.Domain.Persons;
using FamilyTree.Domain.Persons.Enums;

namespace FamilyTree.Application.Persons;

public readonly record struct PersonDto
{
    public PersonDto(Person person)
    {
        PersonId = person.Id;
        GivenName = person.GivenName;
        Surname = person.Surname;
        Gender = person.Gender;
        BirthDate = person.BirthDate;
        BirthLocation = person.BirthLocation;
        DeathDate = person.DeathDate;
        DeathLocation = person.DeathLocation;
        FamilyTreeId = person.FamilyTreeId;
        DisplayName = person.DisplayName;
    }

    public Guid PersonId { get; init; }
    public string GivenName { get; init; }
    public string Surname { get; init; }
    public PersonGender Gender { get; init; }
    public DateTime? BirthDate { get; init; }
    public string? BirthLocation { get; init; }
    public DateTime? DeathDate { get; init; }
    public string? DeathLocation { get; init; }
    public Guid? FamilyTreeId { get; init; }
    public string DisplayName { get; init; }
}
