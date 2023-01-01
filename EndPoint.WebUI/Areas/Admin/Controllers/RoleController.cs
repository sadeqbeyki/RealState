using EndPoint.WebUI.Areas.Admin.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EndPoint.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RoleController : Controller
    {
        private readonly RoleManager<AppIdentityRole> _roleManager;

        public RoleController(RoleManager<AppIdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            var roles = _roleManager.Roles.ToList();
            return View(roles);
        }
        #region Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                AppIdentityRole role = new() { Name = model.Name };
                var result = _roleManager.CreateAsync(role).Result;
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
            return View(model);
        }
        #endregion

        #region Update
        public IActionResult Update(int id)
        {
            var role = _roleManager.FindByIdAsync(id.ToString()).Result;
            if (role != null)
            {
                UpdateRoleViewModel model = new()
                {
                    Id = role.Id,
                    Name = role.Name,
                };
                return View(model);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Update(int id, UpdateRoleViewModel model)
        {
            var role = _roleManager.FindByIdAsync(id.ToString()).Result;
            if (role != null)
            {
                role.Name = model.Name;
                var result = _roleManager.UpdateAsync(role).Result;
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
                return View(model);
            }
            return NotFound();
        }
        #endregion

        #region Delete
        public IActionResult Delete(int id)
        {
            var role = _roleManager.FindByIdAsync(id.ToString()).Result;
            if (role != null)
            {
                var result = _roleManager.DeleteAsync(role).Result;
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
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
        #endregion
    }
}
