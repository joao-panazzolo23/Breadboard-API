namespace Breadboard.Application.Exceptions.Models;

public record ExceptionDetail(string field, string error)
{
    public string Field { get; set; } = field;
    public string Error { get; set; } = error;
}