using FamilyTree.Application.Persons;
using FamilyTree.Domain.Abstractions;

namespace FamilyTree.Application.Trees;

public interface ITreeService
{
    Task<Result<PersonDto[]>> GetFamilyMembersByIdAsync(Guid treeId,
        CancellationToken cancellationToken = default);
}
