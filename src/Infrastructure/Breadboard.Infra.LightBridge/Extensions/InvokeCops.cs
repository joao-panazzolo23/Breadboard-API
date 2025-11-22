using Breadboard.Shared.Cops;

namespace Breadboard.Infra.LightBridget.Extensions;

public static class InvokeCops
{
    public static Func<object, Task<object>> CreateInvoker(
        Type requestType, 
        Type responseType, 
        object handlerInstance)
    {
        var handlerInterface = typeof(IRequestHandler<,>)
            .MakeGenericType(requestType, responseType);

        var method = handlerInterface.GetMethod("Handle")!;

        // compiles heavily typed functions within app startup
        return async (object request) =>
        {
            var resultTask = (Task)method.Invoke(handlerInstance, new[] { request })!;
            await resultTask.ConfigureAwait(false);

            var resultProperty = resultTask.GetType().GetProperty("Result")!;
            return resultProperty.GetValue(resultTask)!;
        };
    }
}