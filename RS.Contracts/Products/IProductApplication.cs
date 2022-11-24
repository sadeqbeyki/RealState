﻿using AppFramework.Application;

namespace RS.Contracts.Products;

public interface IProductApplication
{
    OperationResult Create(CreateProduct command);
    OperationResult Edit(EditProduct command);
    EditProduct? GetDetails(long id);
    List<ProductViewModel> Search(ProductSearchModel searchModel);
    List<ProductViewModel> GetProducts();
}