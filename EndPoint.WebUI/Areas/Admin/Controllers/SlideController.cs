using Microsoft.AspNetCore.Mvc;
using RS.Contracts.Slides;

namespace EndPoint.WebUI.Areas.Admin.Controllers;
[Area("Admin")]
public class SlideController : Controller
{
    [TempData]
    public string Message { get; set; }

    public List<SlideViewModel> Slides;
    private readonly ISlideApplication _slideApplication;

    public SlideController(ISlideApplication slideApplication)
    {
        _slideApplication = slideApplication;
    }

    public IActionResult Index()
    {
        Slides = _slideApplication.GetList();
        return View("Index", Slides);
    }
    [HttpGet]
    public PartialViewResult Create()
    {
        var command = new CreateSlide();
        return PartialView("Create", command);
    }
    [HttpPost]
    public JsonResult Create(CreateSlide command)
    {
        var result = _slideApplication.Create(command);
        return new JsonResult(result);
    }
    [HttpGet]
    public PartialViewResult Edit(long id)
    {
        var slide = _slideApplication.GetDetails(id);
        return PartialView("Edit", slide);
    }
    [HttpPost]
    public JsonResult Edit(EditSlide command)
    {
        var result = _slideApplication.Edit(command);
        return new JsonResult(result);
    }
    public IActionResult Remove(long id)
    {
        var result = _slideApplication.Remove(id);
        if (result.IsSucceeded)
            return RedirectToAction("Index");
        Message = result.Message;
        return RedirectToAction("Index");
    }
    public IActionResult Restore(long id)
    {
        var result = _slideApplication.Restore(id);
        if (result.IsSucceeded)
            return RedirectToAction("Index"); 
        Message = result.Message;
        return RedirectToAction("Index");
    }
}
