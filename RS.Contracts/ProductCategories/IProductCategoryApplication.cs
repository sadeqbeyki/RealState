using AppFramework.Application;

namespace RS.Contracts.ProductCategories;

public interface IProductCategoryApplication
{
    OperationResult Create(CreateProductCategory command);
    OperationResult Edit(EditProductCategory command);
    EditProductCategory GetDetails(long id);
    List<ProductCategoryViewModel> GetProductCategories();
    List<ProductCategoryViewModel> GetAllCategories();
    List<ProductCategoryViewModel> Search(string searchString);
}
