namespace EndPoint.WebUI.Areas.Admin.Models.Identity;

public class CreateRoleViewModel
{
    public string Name { get; set; }
}
public class UpdateRoleViewModel : CreateRoleViewModel
{
    public int Id { get; set; }
}
