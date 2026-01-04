using FluentValidation.Results;

namespace Breadboard.Application.ResultPattern.Factory;

public interface IValidationFactory<out TResponse> where TResponse : IResult
{
    TResponse CreateBadRequest(List<ValidationFailure> errors);
}