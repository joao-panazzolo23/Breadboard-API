using Breadboard.Application.ResultPattern;

namespace Breadboard.Application.Cops.Abstractions;

public interface IRequestHandler<in TRequest, TResponse>
{
    Task<Result<TResponse>> Handle(TRequest request);
}