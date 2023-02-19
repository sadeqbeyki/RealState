using AppFramework;

namespace EndPoint.WebUI.Areas.Admin.Models.Identity.Auth
{
    public interface IAuthHelper
    {
        void SignOut();
        bool IsAuthenticated();
        void SignIn(AuthViewModel account);
        string CurrentAccountRole();
        AuthViewModel CurrentAccountInfo();
        List<int> GetPermissions();
        long CurrentAccountId();
        string CurrentAccountMobile();
    }
}
