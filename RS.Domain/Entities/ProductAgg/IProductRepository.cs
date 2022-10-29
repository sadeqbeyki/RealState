using AppFramework.Domain;
using RS.Application.Product;

namespace RS.Domain.Entities.ProductAgg
{
    public interface IProductRepository : IBaseRepository<long, Product>
    {
        EditProduct? GetDetails(long id);
        Product GetProductWithCategory(long id);
        List<ProductViewModel> Search(ProductSearchModel searchModel);
        List<ProductViewModel> GetProducts();
    }
}
