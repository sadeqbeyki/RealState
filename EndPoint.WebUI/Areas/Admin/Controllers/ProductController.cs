using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RS.Contracts.ProductCategories;
using RS.Contracts.Products;

namespace EndPoint.WebUI.Areas.Admin.Controllers;
[Area("Admin")]
public class ProductController : Controller
{
    [TempData] public string Message { get; set; }
    public ProductSearchModel SearchModel;
    public List<ProductViewModel> Products;
    public SelectList ProductCategories;

    private readonly IProductApplication _productApplication;
    private readonly IProductCategoryApplication _productCategoryApplication;

    public ProductController(IProductApplication productApplication,
        IProductCategoryApplication productCategoryApplication)
    {
        _productApplication = productApplication;
        _productCategoryApplication = productCategoryApplication;
    }
    //[NeedsPermission(ShopPermissions.ListProducts)]
    public void Index(ProductSearchModel searchModel)
    {
        ProductCategories = new SelectList(_productCategoryApplication.GetProductCategories(), "Id", "Name");
        Products = _productApplication.Search(searchModel);
    }
    [HttpGet]
    public PartialViewResult Create()
    {
        var command = new CreateProduct
        {
            Categories = _productCategoryApplication.GetProductCategories()
        };
        return PartialView("./Create", command);
    }
    [HttpPost]
    //[NeedsPermission(ShopPermissions.CreateProduct)]
    public JsonResult Create(CreateProduct command)
    {
        var result = _productApplication.Create(command);
        return new JsonResult(result);
    }
    [HttpGet]
    public PartialViewResult Edit(long id)
    {
        var product = _productApplication.GetDetails(id);
        product.Categories = _productCategoryApplication.GetProductCategories();
        return PartialView("Edit", product);
    }
    [HttpPost]
    //[NeedsPermission(ShopPermissions.EditProduct)]
    public JsonResult Edit(EditProduct command)
    {
        var result = _productApplication.Edit(command);
        return new JsonResult(result);
    }
}
