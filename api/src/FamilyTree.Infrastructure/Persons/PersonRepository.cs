using FamilyTree.Domain.Persons;
using FamilyTree.Infrastructure.Abstractions;
using FamilyTree.Infrastructure.Databases;
using Microsoft.EntityFrameworkCore;

namespace FamilyTree.Infrastructure.Persons;

internal sealed class PersonRepository(EntityFrameworkDbContext dbContext)
    : RepositoryBase<Person>(dbContext), IPersonRepository
{
    // It probably should be a paginated list, but for now, I'll keep it simple.
    public async Task<IEnumerable<Person>> GetByTreeIdAsync(Guid treeId, CancellationToken cancellationToken = default)
    {
        return await Set
            .AsNoTracking()
            .Where(w => w.FamilyTreeId == treeId)
            .ToListAsync(cancellationToken);
    }
}
