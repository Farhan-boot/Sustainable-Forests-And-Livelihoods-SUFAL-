using Microsoft.AspNetCore.Mvc;

using PTSL.GENERIC.Web.Core.Helper;

namespace PTSL.GENERIC.Web.Core.Controllers.AccountManagement;

[SessionAuthorize]
public class AccountApprovalController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
