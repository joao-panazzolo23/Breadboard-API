using Breadboard.Shared.Results;

namespace Breadboard.Shared.Cops;

public interface IRequestHandler<in TRequest, TResponse>
{
    Task<Result<TResponse>> Handle(TRequest request);
}