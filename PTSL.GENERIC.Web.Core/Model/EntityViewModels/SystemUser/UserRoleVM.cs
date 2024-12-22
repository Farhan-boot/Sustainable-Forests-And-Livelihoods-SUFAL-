namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.SystemUser;

public class UserRoleVM : BaseModel
{
    public string RoleName { get; set; } = string.Empty;
    public string AccessList { get; set; } = string.Empty;

    public List<UserVM>? Users { get; set; }
}
