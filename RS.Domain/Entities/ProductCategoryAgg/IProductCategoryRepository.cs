﻿using AppFramework.Domain;
using RS.Application.ProductCategory;

namespace RS.Domain.Entities.ProductCategoryAgg
{
    public interface IProductCategoryRepository : IBaseRepository<long, ProductCategory>
    {
        List<ProductCategoryViewModel> GetProductCategories();
        EditProductCategory GetDetails(long id);
        string GetSlugById(long id);
        List<ProductCategoryViewModel> Search(ProductCategorySearchModel searchModel);
    }
}
