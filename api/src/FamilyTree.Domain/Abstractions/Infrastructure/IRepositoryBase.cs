namespace FamilyTree.Domain.Abstractions.Infrastructure;

public interface IRepositoryBase<T> where T : EntityBase
{
    Task<bool> ExistsAsync(Guid id, CancellationToken cancellationToken = default);
}
