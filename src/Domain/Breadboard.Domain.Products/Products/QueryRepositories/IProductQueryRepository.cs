using Products.Domain.Products.Viewmodels;

namespace Products.Domain.Products.QueryRepositories;

public interface IProductQueryRepository
{
    public IEnumerable<ListProductDto> Type { get; set; }
}