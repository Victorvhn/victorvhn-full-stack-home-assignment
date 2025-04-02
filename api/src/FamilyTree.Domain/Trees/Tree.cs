using FamilyTree.Domain.Abstractions;
using FamilyTree.Domain.Persons;

namespace FamilyTree.Domain.Trees;

public sealed class Tree : EntityBase
{
    // This constructor is private to enforce the use of a factory method.
    // And to allow EF to create the object.
    private Tree() { }

    public ICollection<Person> FamilyMembers { get; init; } = [];

    public static Tree CreateInstance()
    {
        return new Tree();
    }
}
