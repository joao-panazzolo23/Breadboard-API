namespace Breadboard.Presentation.ExceptionHandler.Strategies.Abstract;

public interface IExceptionStrategy
{
    Task<bool> Handle(HttpContext context, Exception exception, CancellationToken cancellationToken);
}