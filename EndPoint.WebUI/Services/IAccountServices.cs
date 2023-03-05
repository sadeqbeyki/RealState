using EndPoint.WebUI.Areas.Admin.Models;
using EndPoint.WebUI.Areas.Admin.Models.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EndPoint.WebUI.Services;

public interface IAccountServices
{
    Task<AppLoginViewModel> Login(AppLoginViewModel model);
    CreateUserViewModel Register(CreateUserViewModel model);
}
public class AccountServices : IAccountServices
{
    public Task<AppLoginViewModel> Login(AppLoginViewModel model)
    {
        throw new NotImplementedException();
    }

    public CreateUserViewModel Register(CreateUserViewModel model)
    {
        throw new NotImplementedException();
    }
}
