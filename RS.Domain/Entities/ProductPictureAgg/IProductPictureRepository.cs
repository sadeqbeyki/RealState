using AppFramework.Domain;
using ShopManagement.Application.Contracts.ProductPicture;

namespace RS.Domain.Entities.ProductPictureAgg
{
    public interface IProductPictureRepository : IBaseRepository<long, ProductPicture>
    {
        EditProductPicture GetDetails(long id);
        ProductPicture GetWithProductAndCategory(long id);
        List<ProductPictureViewModel> Search(ProductPictureSearchModel searchModel);
    }
}
