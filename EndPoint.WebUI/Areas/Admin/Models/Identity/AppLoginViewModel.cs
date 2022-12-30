using System.ComponentModel.DataAnnotations;

namespace EndPoint.WebUI.Areas.Admin.Models.Identity;

public class AppLoginViewModel
{
    [Required]
    [Display(Name = "User Name / Email ")]
    public string Name { get; set; }
    [Required]
    [UIHint("password")]
    public string Password { get; set; }
    public string ReturnUrl { get; set; } = "/";
}
