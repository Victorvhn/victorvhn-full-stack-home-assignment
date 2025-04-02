namespace FamilyTree.Api.Abstractions;

internal interface IEndpoint
{
    void MapEndpoint(IEndpointRouteBuilder app);
}
