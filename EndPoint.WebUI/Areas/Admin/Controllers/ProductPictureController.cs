using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RS.Contracts.ProductPictures;
using RS.Contracts.Products;

namespace EndPoint.WebUI.Areas.Admin.Controllers;
[Area("Admin")]
public class ProductPictureController : Controller
{
    [TempData]
    public string Message { get; set; }
    public ProductPictureSearchModel SearchModel;
    public List<ProductPictureViewModel> ProductPictures;
    public SelectList Products;

    private readonly IProductApplication _productApplication;
    private readonly IProductPictureApplication _productPictureApplication;
    public ProductPictureController(IProductApplication productApplication,
        IProductPictureApplication productPictureApplication)
    {
        _productApplication = productApplication;
        _productPictureApplication = productPictureApplication;
    }

    public IActionResult Index(long productId)
    {
        Products = new SelectList(_productApplication.GetProducts(), "Id", "Name");
        ViewBag.Products = Products;
        ProductPictures = _productPictureApplication.Search(productId);
        //ViewBag.ProductPictures = ProductPictures;

        return View("Index", ProductPictures);
    }
    [HttpGet]
    public PartialViewResult Create()
    {
        var command = new CreateProductPicture
        {
            Products = _productApplication.GetProducts()
        };
        return PartialView("Create", command);
    }
    [HttpPost]
    public JsonResult Create(CreateProductPicture command)
    {
        var result = _productPictureApplication.Create(command);
        return new JsonResult(result);
    }
    [HttpGet]
    public PartialViewResult Edit(long id)
    {
        var productPicture = _productPictureApplication.GetDetails(id);
        productPicture.Products = _productApplication.GetProducts();
        return PartialView("Edit", productPicture);
    }
    [HttpPost]
    public JsonResult Edit(EditProductPicture command)
    {
        var result = _productPictureApplication.Edit(command);
        return new JsonResult(result);
    }

    public IActionResult Remove(long id)
    {
        var result = _productPictureApplication.Remove(id);
        if (result.IsSucceeded)
            return RedirectToAction("Index");
        Message = result.Message;
        return RedirectToAction("Index");

    }
    public IActionResult Restore(long id)
    {
        var result = _productPictureApplication.Restore(id);
        if (result.IsSucceeded)
            return RedirectToAction("Index");

        Message = result.Message;
        return RedirectToAction("Index");
    }
}

