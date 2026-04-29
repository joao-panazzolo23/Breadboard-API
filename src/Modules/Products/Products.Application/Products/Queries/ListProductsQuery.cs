using Breadboard.Application.Data;
using Breadboard.Application.ResultPattern;
using Products.Domain.Products.Viewmodels;


namespace Products.Application.Products.Queries;

public record ListProductsQuery : ListQuery<Result<IEnumerable<ListProductDto>>>
{
    public string? Code { get; set; }
}
