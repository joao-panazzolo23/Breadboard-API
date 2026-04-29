using Breadboard.Application.ResultPattern;
using Mediator;
using Products.Application.Products.Queries;
using Products.Domain.Products.QueryRepositories;
using Products.Domain.Products.Viewmodels;

namespace Products.Application.Products.Handlers;

public class ListProductHandler(
    IProductQueryRepository _repository
)
    : IQueryHandler<ListProductsQuery, Result<IEnumerable<ListProductDto>>>
{
    public ValueTask<Result<IEnumerable<ListProductDto>>> Handle(ListProductsQuery query,
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}