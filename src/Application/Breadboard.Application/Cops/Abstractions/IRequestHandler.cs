using Breadboard.Application.ResultPattern;

namespace Breadboard.Application.Cops;

public interface IRequestHandler<in TRequest, TResponse>
{
    Task<Result<TResponse>> Handle(TRequest request);
}