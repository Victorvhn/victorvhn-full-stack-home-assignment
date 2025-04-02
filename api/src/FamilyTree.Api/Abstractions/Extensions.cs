using FamilyTree.Domain.Abstractions;

namespace FamilyTree.Api.Abstractions;

internal static class Extensions
{
    public static TOut Match<TOut>(
        this Result result,
        Func<TOut> onSuccess,
        Func<Result, TOut> onFailure)
    {
        return result.IsSuccess ? onSuccess() : onFailure(result);
    }
}
