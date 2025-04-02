using FamilyTree.Api.Abstractions;
using FamilyTree.Application.Persons;
using FamilyTree.Application.Trees;
using FamilyTree.Domain.Abstractions;
using FamilyTree.Infrastructure.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace FamilyTree.Api.Trees;

internal sealed class GetFamilyMembersById : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("trees/{treeId:guid}/family-members",
                async (Guid treeId, ITreeService treeService, CancellationToken cancellationToken) =>
                {
                    // In a real-world application, the best would probably be to use a mediator pattern.
                    // But for now, I'll keep it simple.
                    Result<PersonDto[]> result =
                        await treeService.GetFamilyMembersByIdAsync(treeId, cancellationToken);

                    return result.Match(() => Results.Ok(result.Value), ApiResults.Problem);
                })
            .RequireClientAuthentication()
            .WithTags(Tags.Trees)
            .WithName(nameof(GetFamilyMembersById))
            .WithDisplayName("Get family members by tree ID")
            .WithSummary("Retrieve Family Members by Tree ID")
            .WithDescription("This endpoint retrieves all family members associated with a specific tree ID.")
            .Produces<PersonDto[]>()
            .Produces<ProblemDetails>(StatusCodes.Status404NotFound, "application/problem+json");
    }
}
