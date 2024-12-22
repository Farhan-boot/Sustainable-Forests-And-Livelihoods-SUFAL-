using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using PTSL.GENERIC.Web.Core.Helper;
using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.AIG;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Beneficiary;

namespace PTSL.GENERIC.Web.Core.Controllers.Reports;

public partial class ReportsController : Controller
{
    // Beneficiary Wise Repayment Progress
    public ActionResult BeneficiaryWiseRepaymentProgressReportFilter()
    {
        AuthLocationHelper.GenerateViewBagForForestAndCivil(
            HttpContext,
            ViewBag,
            _ForestCircleService,
            _ForestDivisionService,
            _ForestRangeService,
            _ForestBeatService,
            _ForestFcvVcfService,
            _DivisionService,
            _DistrictService,
            _UpazillaService,
            _UnionService
        );

        ViewBag.Gender = new SelectList(EnumHelper.GetEnumDropdowns<Gender>(), "Id", "Name");
        ViewBag.NgoId = new SelectList(_NgoService.List().entity ?? new List<NgoVM>(), "Id", "Name");

        return View();
    }

    [HttpPost]
    public ActionResult BeneficiaryWiseRepaymentProgressReport(long SurveyId)
    {
        var result = _AIGBasicInformationService.BeneficiaryWiseRepaymentProgress(SurveyId);

        return View(result.entity ?? new List<AIGBasicInformationVM>());
    }
}
