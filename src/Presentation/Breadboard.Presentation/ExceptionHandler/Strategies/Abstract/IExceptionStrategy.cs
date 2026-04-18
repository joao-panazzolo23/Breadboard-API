namespace Breadboard.Presentation.ExceptionHandler.Strategies.Abstract;

public interface IExceptionStrategy
{
    bool CanHandle(Exception exception);
    Task<bool> Handle(HttpContext context, Exception exception, CancellationToken cancellationToken);
}