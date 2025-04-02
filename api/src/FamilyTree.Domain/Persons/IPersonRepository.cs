using FamilyTree.Domain.Abstractions.Infrastructure;

namespace FamilyTree.Domain.Persons;

public interface IPersonRepository : IRepositoryBase<Person>
{
    Task<IEnumerable<Person>> GetByTreeIdAsync(Guid treeId, CancellationToken cancellationToken = default);
}
