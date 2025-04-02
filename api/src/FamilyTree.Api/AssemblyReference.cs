using System.Reflection;

namespace FamilyTree.Api;

internal static class AssemblyReference
{
    public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
}
