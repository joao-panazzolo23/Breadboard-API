using Mediator;

namespace Breadboard.Application.Data;

public abstract record ListQuery<T> : IQuery<T>
{
    public string? Search { get; set; }
    public int Page { get; set; }
    public int Items { get; set; }
}