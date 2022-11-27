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
    public IActionResult Index(ProductSearchModel searchModel)
    {
        ProductCategories = new SelectList(_productCategoryApplication.GetProductCategories(), "Id", "Name");
        ViewBag.ProductCategories = ProductCategories;
        Products = _productApplication.Search(searchModel);
        ViewBag.Products = Products;
        //var products = _productApplication.GetProducts().ToList();
        //return View("Index", products);
        return View("Index");
    }
    [HttpGet]
    public PartialViewResult Create()
    {
        var command = new CreateProduct
        {
            Categories = _productCategoryApplication.GetProductCategories()
        };
        return PartialView("Create", command);
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
