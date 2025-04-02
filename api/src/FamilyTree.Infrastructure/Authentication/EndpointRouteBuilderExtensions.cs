using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FamilyTree.Infrastructure.Authentication;

public static class EndpointRouteBuilderExtensions
{
    public static RouteHandlerBuilder RequireClientAuthentication(this RouteHandlerBuilder builder)
    {
        return builder
            .AddEndpointFilter<ApiAuthenticationFilter>()
            .Produces<ProblemDetails>(StatusCodes.Status401Unauthorized, "application/problem+json")
            .Produces<ProblemDetails>(StatusCodes.Status400BadRequest, "application/problem+json");
    }
}
