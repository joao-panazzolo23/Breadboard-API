using Breadboard.Shared.Entities;

namespace Breadboard.Shared.Cops;

public interface IRequestHandler<in TRequest, TResponse>
{
    Task<TypedResult<TResponse>> Handle(TRequest request);
}