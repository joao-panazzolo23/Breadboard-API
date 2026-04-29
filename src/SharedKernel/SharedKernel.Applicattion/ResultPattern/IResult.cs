using FluentValidation.Results;

namespace Breadboard.Application.ResultPattern;

public interface IResult
{
    public int StatusCode { get; }
    // public List<ValidationFailure> Errors { get; }
    // public IResult HasErrors(ValidationFailure error);
    // public IResult HasErrors(List<ValidationFailure> error);
}

public interface IResult<out T> : IResult
{
    T Data { get; }
}