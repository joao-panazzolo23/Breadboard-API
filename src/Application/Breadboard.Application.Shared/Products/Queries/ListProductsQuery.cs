using Breadboard.Application.Data;
using Breadboard.Application.ResultPattern;
using Breadboard.Domain.Products.Viewmodels;

namespace Breadboard.Application.Products.Queries;

public record ListProductsQuery : ListQuery<Result<IEnumerable<ListProductDto>>>
{
    public string? Code { get; set; }
}
