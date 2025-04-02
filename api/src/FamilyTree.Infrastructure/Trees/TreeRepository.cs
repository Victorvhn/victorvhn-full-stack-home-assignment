using FamilyTree.Domain.Trees;
using FamilyTree.Infrastructure.Abstractions;
using FamilyTree.Infrastructure.Databases;

namespace FamilyTree.Infrastructure.Trees;

internal sealed class TreeRepository(EntityFrameworkDbContext dbContext)
    : RepositoryBase<Tree>(dbContext), ITreeRepository;
