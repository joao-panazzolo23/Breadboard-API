using Breadboard.Shared.Extensions;

namespace Breadboard.Shared.Results;

public static class ResultExtensions
{
    public static bool IsSucess<T>(this Result<T> result) => 
         result.StatusCode.Between(200, 299);
}