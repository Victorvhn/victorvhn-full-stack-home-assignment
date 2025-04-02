using FamilyTree.Domain.Abstractions;

namespace FamilyTree.Api.Abstractions;

internal static class ApiResults
{
    public static IResult Problem(Result result)
    {
        if (result.IsSuccess)
        {
            throw new InvalidOperationException();
        }

        return Results.Problem(
            title: GetTitle(result.Error),
            detail: GetDetail(result.Error),
            type: GetType(result.Error.Type),
            statusCode: GetStatusCode(result.Error.Type));

        static string GetTitle(Error error) => error.Type switch
        {
            ErrorType.NotFound => error.Code,
            _ => "Server failure"
        };

        static string GetDetail(Error error) => error.Type switch
        {
            ErrorType.NotFound => error.Description,
            _ => "An unexpected error occurred"
        };

        static string GetType(ErrorType errorType) => errorType switch
        {
            ErrorType.NotFound => "https://tools.ietf.org/html/rfc7231#section-6.5.4",
            _ => "https://tools.ietf.org/html/rfc7231#section-6.6.1"
        };

        static int GetStatusCode(ErrorType errorType) => errorType switch
        {
            ErrorType.NotFound => StatusCodes.Status404NotFound,
            _ => StatusCodes.Status500InternalServerError
        };
    }
}
