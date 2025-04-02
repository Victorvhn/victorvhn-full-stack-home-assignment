using System.ComponentModel.DataAnnotations;

namespace FamilyTree.Infrastructure.Authentication;

public sealed class AuthenticationOptions
{
    public static string SectionName => "Authentication";

    [Required] public required string Secret { get; init; }
}
