using System.Diagnostics.CodeAnalysis;
using FamilyTree.Domain.Abstractions;
using FamilyTree.Domain.Persons.Enums;
using FamilyTree.Domain.Persons.Resources;
using FamilyTree.Domain.Trees;

namespace FamilyTree.Domain.Persons;

// This should be fixed just by creating a factory method.
[SuppressMessage("Major Bug", "S3453:Classes should not have only \"private\" constructors")]
public sealed class Person : EntityBase
{
    // This constructor is private to enforce the use of a factory method.
    // And to allow EF to create the object.
    private Person() { }

    public required string GivenName { get; init; }

    public required string Surname { get; init; }

    public required PersonGender Gender { get; init; }

    public DateTime? BirthDate { get; init; }

    public string? BirthLocation { get; init; }

    public DateTime? DeathDate { get; init; }

    public string? DeathLocation { get; init; }

    // Straightforward link between Person and Tree.
    // In a real-world application, this might be a many-to-many relationship or even a graph.
    public Tree? FamilyTree { get; init; }
    public Guid? FamilyTreeId { get; init; }

    public string DisplayName => $"{GivenName} {Surname} ({GetLifespan()})";

    private string GetLifespan()
    {
        return (BirthDate, DeathDate) switch
        {
            ({ } birthDate, { } deathDate) => $"{birthDate.Year}-{deathDate.Year}",
            (null, { } deathDate) => $"-{deathDate.Year}",
            ({ } birthDate, null) => DateTime.UtcNow.Year - birthDate.Year < Constants.MaxLivingAge
                ? PersonResources.Lifespan_Living
                : $"{birthDate.Year}-",
            (null, null) => PersonResources.Lifespan_Living
        };
    }

    public static class Constants
    {
        public const byte MaxLivingAge = 120;
    }

    public static class Constraints
    {
        public const int GivenNameMaxLength = 150;
        public const int SurnameMaxLength = 300;
        public const int BirthLocationMaxLength = 500;
        public const int DeathLocationMaxLength = 500;
    }
}
