using FamilyTree.Application.Persons;
using FamilyTree.Domain.Abstractions;
using FamilyTree.Domain.Persons;
using FamilyTree.Domain.Trees;

namespace FamilyTree.Application.Trees;

internal sealed class TreeService(
    ITreeRepository treeRepository,
    IPersonRepository personRepository) : ITreeService
{
    public async Task<Result<PersonDto[]>> GetFamilyMembersByIdAsync(Guid treeId,
        CancellationToken cancellationToken = default)
    {
        bool treeExists = await treeRepository.ExistsAsync(treeId, cancellationToken);
        if (!treeExists)
        {
            return Result.Failure<PersonDto[]>(TreeErrors.NotFound(treeId));
        }

        IEnumerable<Person> memberList = await personRepository.GetByTreeIdAsync(treeId, cancellationToken);

        return memberList
            .Select(person => new PersonDto(person))
            .ToArray();
    }
}
