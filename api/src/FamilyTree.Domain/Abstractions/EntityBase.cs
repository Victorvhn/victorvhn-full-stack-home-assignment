namespace FamilyTree.Domain.Abstractions;

public abstract class EntityBase
{
    public Guid Id { get; private init; } = Guid.CreateVersion7();
}
