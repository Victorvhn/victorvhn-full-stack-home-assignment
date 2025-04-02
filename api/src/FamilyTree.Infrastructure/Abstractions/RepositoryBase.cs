using FamilyTree.Domain.Abstractions;
using FamilyTree.Domain.Abstractions.Infrastructure;
using FamilyTree.Infrastructure.Databases;
using Microsoft.EntityFrameworkCore;

namespace FamilyTree.Infrastructure.Abstractions;

internal class RepositoryBase<T> : IRepositoryBase<T> where T : EntityBase
{
    protected readonly EntityFrameworkDbContext DbContext;
    protected readonly DbSet<T> Set;

    protected RepositoryBase(EntityFrameworkDbContext dbContext)
    {
        DbContext = dbContext;
        Set = dbContext.Set<T>();
    }

    public async Task<bool> ExistsAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await Set.AnyAsync(entity => entity.Id == id, cancellationToken);
    }
}
