using Breadboard.Domain.Products.Viewmodels;

namespace Breadboard.Domain.Products.QueryRepositories;

public interface IProductQueryRepository
{
    public IEnumerable<ListProductDto> Type { get; set; }
}