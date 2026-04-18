using Breadboard.Application.Products.Queries;
using Breadboard.Application.ResultPattern;
using Breadboard.Domain.Products.QueryRepositories;
using Breadboard.Domain.Products.Viewmodels;
using Mediator;

namespace Breadboard.Application.Products.Handlers;

// public class ListProductHandler(
//     IProductQueryRepository _repository
// )
//     : IQueryHandler<ListProductsQuery, Result<IEnumerable<ListProductDto>>>
// {
//     public ValueTask<Result<IEnumerable<ListProductDto>>> Handle(ListProductsQuery query,
//         CancellationToken cancellationToken)
//     {
//         throw new NotImplementedException();
//     }
// }