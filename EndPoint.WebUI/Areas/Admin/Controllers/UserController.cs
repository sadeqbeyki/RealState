using EndPoint.WebUI.Areas.Admin.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EndPoint.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
public class UserController : Controller
{
    private readonly UserManager<AppUser> _userManager;

    public UserController(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }

    public IActionResult Index()
    {
        var users = _userManager.Users.Take(50).ToList();
        return View(users);
    }
    [HttpGet]
    public PartialViewResult Create()
    {
        return PartialView("Create");
    }
    [HttpPost]
    public JsonResult Create(CreateUserViewModel model)
    {
        if (ModelState.IsValid)
        {
            AppUser user = new()
            {
                UserName = model.UserName,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                BirthDate = model.BirthDate,
            };
            var result = _userManager.CreateAsync(user, model.Password).Result;
            if (result.Succeeded)
            {
                return new JsonResult(result);
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.Code, item.Description);
                }
            }
        }
        return new JsonResult(model);
    }
    [HttpGet]
    public PartialViewResult Update(int id)
    {
        var user = _userManager.FindByIdAsync(id.ToString()).Result;
        if (user != null)
        {
            UpdateUserViewModel model = new()
            {
                Id = user.Id,
                UserName = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                BirthDate = user.BirthDate
            };
            return PartialView("Update", model);
        }
        return PartialView("Error");
    }
    [HttpPost]
    public JsonResult Update(int id, UpdateUserViewModel model)
    {
        var user = _userManager.FindByIdAsync(id.ToString()).Result;
        if (user != null)
        {
            user.UserName = model.UserName;
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.Email = model.Email;
            user.BirthDate = model.BirthDate;

            var result = _userManager.UpdateAsync(user).Result;
            if (result.Succeeded)
            {
                return new JsonResult(result);
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.Code, item.Description);
                }
            }
            return new JsonResult(model);
        }
        return  new JsonResult("Index");
    }
    public IActionResult Delete(int id)
    {
        var user = _userManager.FindByIdAsync(id.ToString()).Result;
        if (user != null)
        {
            var result = _userManager.DeleteAsync(user).Result;
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.Code, item.Description);
                }
            }
        }
        return View();
    }
}
