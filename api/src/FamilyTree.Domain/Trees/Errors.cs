using System.Globalization;
using FamilyTree.Domain.Abstractions;
using FamilyTree.Domain.Trees.Resources;

namespace FamilyTree.Domain.Trees;

public static class TreeErrors
{
    public static Error NotFound(Guid treeId)
    {
        return new Error("Tree.NotFound",
            string.Format(CultureInfo.InvariantCulture, TreeResources.Error_NotFound, treeId), ErrorType.NotFound);
    }
}
