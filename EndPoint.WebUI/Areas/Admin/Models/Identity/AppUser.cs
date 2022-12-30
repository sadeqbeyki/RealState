using Microsoft.AspNetCore.Identity;

namespace EndPoint.WebUI.Areas.Admin.Models.Identity
{
    public class AppUser : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
    }
}
