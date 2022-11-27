using AppFramework.Domain;
using RS.Contracts.ProductCategories;

namespace RS.Domain.Entities.ProductCategoryAgg
{
    public interface IProductCategoryRepository : IBaseRepository<long, ProductCategory>
    {
        List<ProductCategoryViewModel> GetProductCategories();
        List<ProductCategoryViewModel> GetAllCategories();
        EditProductCategory GetDetails(long id);
        string GetSlugById(long id);
        List<ProductCategoryViewModel> Search(string searchString);
    }
}
