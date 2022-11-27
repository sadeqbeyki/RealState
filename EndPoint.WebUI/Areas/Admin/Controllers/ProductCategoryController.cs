using Microsoft.AspNetCore.Mvc;
using RS.Contracts.ProductCategories;

namespace EndPoint.WebUI.Areas.Admin.Controllers;
[Area("Admin")]
public class ProductCategoryController : Controller
{
    public ProductCategorySearchModel SearchModel;
    public List<ProductCategoryViewModel> ProductCategories;
    private readonly IProductCategoryApplication _productCategoryApplication;

    public ProductCategoryController(IProductCategoryApplication productCategoryApplication)
    {
        _productCategoryApplication = productCategoryApplication;
    }
    //[NeedsPermission(ShopPermissions.ListProductCategories)]

    public IActionResult Index(string searchString)
    {
        ProductCategories = _productCategoryApplication.Search(searchString);
        return View("Index", ProductCategories);
    }

    [HttpGet]
    public PartialViewResult Create()
    {
        return PartialView("Create", new CreateProductCategory());
    }
    [HttpPost]
    //[NeedsPermission(ShopPermissions.CreateProductCategory)]
    public JsonResult Create(CreateProductCategory command)
    {
        var result = _productCategoryApplication.Create(command);
        return new JsonResult(result);
    }

    public PartialViewResult Edit(long id)
    {
        var productCategory = _productCategoryApplication.GetDetails(id);
        return PartialView("Edit", productCategory);
    }
    [HttpPost]
    //[NeedsPermission(ShopPermissions.EditProductCategory)]
    public IActionResult Edit(EditProductCategory command)
    {
        if (!ModelState.IsValid)
        {
            return new JsonResult(new { message = "فایل انتخاب شده مجاز نیست" });
        }

        var result = _productCategoryApplication.Edit(command);
        return new JsonResult(result);
    }
}
