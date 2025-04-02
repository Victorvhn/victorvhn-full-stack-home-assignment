using FamilyTree.Domain.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Primitives;

namespace FamilyTree.Infrastructure.Authentication;

internal sealed class ApiAuthenticationFilter(IOptions<AuthenticationOptions> options) : IEndpointFilter
{
    private const string ApiKeyHeaderName = "x-client-id";
    private readonly AuthenticationOptions _options = options.Value;

    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        if (!context.HttpContext.Request.Headers.TryGetValue(ApiKeyHeaderName, out StringValues headers))
        {
            return Results.Problem(
                title: "Authentication.Missing",
                detail: DomainResources.Authentication_MissingHeader,
                type: "https://tools.ietf.org/html/rfc7231#section-6.5.4",
                statusCode: StatusCodes.Status400BadRequest
            );
        }

        if (headers.Count > 1)
        {
            return Results.Problem(
                title: "Authentication.Invalid",
                detail: DomainResources.Authentication_InvalidHeader,
                type: "https://tools.ietf.org/html/rfc7231#section-6.5.4",
                statusCode: StatusCodes.Status400BadRequest
            );
        }

        string header = headers[0];

        if (!string.Equals(header, _options.Secret, StringComparison.OrdinalIgnoreCase))
        {
            return Results.Problem(
                title: "Authentication.Invalid",
                detail: DomainResources.Authentication_UnknownHeader,
                type: "https://tools.ietf.org/html/rfc7235#section-3.1",
                statusCode: StatusCodes.Status401Unauthorized
            );
        }

        return await next(context);
    }
}
