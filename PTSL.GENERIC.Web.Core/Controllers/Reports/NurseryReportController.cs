using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using PTSL.GENERIC.Web.Core.Helper;
using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.AIG;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Beneficiary;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.GeneralSetup;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.SocialForestry;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.SocialForestry.Nursery;
using PTSL.GENERIC.Web.Core.Model.GeneralSetup;
using PTSL.GENERIC.Web.Core.Services.Implementation.GeneralSetup;
using PTSL.GENERIC.Web.Core.Services.Implementation.SocialForestry;
using PTSL.GENERIC.Web.Core.Services.Implementation.SocialForestry.Nursery;
using PTSL.GENERIC.Web.Core.Services.Interface.Beneficiary;
using PTSL.GENERIC.Web.Core.Services.Interface.GeneralSetup;
using PTSL.GENERIC.Web.Core.Services.Interface.SocialForestry;
using PTSL.GENERIC.Web.Core.Services.Interface.SocialForestry.Nursery;
using PTSL.GENERIC.Web.Helper;
using PTSL.GENERIC.Web.Services.Implementation.GeneralSetup;

namespace PTSL.GENERIC.Web.Core.Controllers.Reports;

public partial class NurseryReportController : Controller
{
    private readonly INurseryRaisedSeedlingInformationService _nurseryRaisedSeedlingInformationService;
    private readonly INurseryInformationService _nurseryInformationService;
    private readonly INurseryRaisingSectorService _nurseryRaisingSectorService;

    private readonly IForestCircleService _ForestCircleService;
    private readonly IForestDivisionService _ForestDivisionService;
    private readonly IForestRangeService _ForestRangeService;
    private readonly IForestBeatService _ForestBeatService;
    private readonly IForestFcvVcfService _ForestFcvVcfService;

    private readonly IDivisionService _DivisionService;
    private readonly IDistrictService _DistrictService;
    private readonly IUpazillaService _UpazillaService;
    private readonly IUnionService _UnionService;

    private readonly IFinancialYearService _financialYearService;
    private readonly IProjectTypeService _projectTypeService;
    private readonly INurseryTypeService _nurseryTypeService;

    private readonly ISocialForestryDesignationService _socialForestryDesignationService;
    public NurseryReportController(HttpHelper httpHelper)
    {
        _nurseryRaisedSeedlingInformationService = new NurseryRaisedSeedlingInformationService(httpHelper);
        _nurseryInformationService = new NurseryInformationService(httpHelper);
        _nurseryRaisingSectorService = new NurseryRaisingSectorService(httpHelper);

        _ForestCircleService = new ForestCircleService(httpHelper);
        _ForestDivisionService = new ForestDivisionService(httpHelper);
        _ForestRangeService = new ForestRangeService(httpHelper);
        _ForestBeatService = new ForestBeatService(httpHelper);
        _ForestFcvVcfService = new ForestFcvVcfService(httpHelper);

        _DivisionService = new DivisionService(httpHelper);
        _DistrictService = new DistrictService(httpHelper);
        _UpazillaService = new UpazillaService(httpHelper);
        _UnionService = new UnionService(httpHelper);
        _financialYearService = new FinancialYearService(httpHelper);
        _projectTypeService = new ProjectTypeService(httpHelper);
        _nurseryTypeService = new NurseryTypeService(httpHelper);

        _socialForestryDesignationService = new SocialForestryDesignationService(httpHelper);

    }


    public ActionResult NurseryReport()
    {

        ViewBag.ForestCircleId = _ForestCircleService.List().entity ?? new List<ForestCircleVM>();

        ViewBag.DivisionId = new SelectList(_DivisionService.List().entity ?? new List<DivisionVM>(), "Id", "Name");
        ViewBag.DistrictId = new SelectList("");
        ViewBag.UpazillaId = new SelectList("");
        ViewBag.UnionId = new SelectList("");

        List<FinancialYearVM>? nursaryRaisingYearList = _financialYearService.List().entity?.OrderBy(x => x.Name).ToList();
        ViewBag.FinancialYearId = nursaryRaisingYearList ?? new List<FinancialYearVM>();
        ViewBag.NurseryList = _nurseryInformationService.List().entity ?? new List<NurseryInformationVM>();


        var nurseryInformationReport = new List<SocialForestryReportVM>();

        return View(nurseryInformationReport);

    }
    [HttpPost]
    public ActionResult NurseryReport(NurseryFilterVM nurseryFilterVM)
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
                _UnionService,
                nurseryFilterVM
            );
        ViewBag.ForestCircleId = _ForestCircleService.List().entity ?? new List<ForestCircleVM>();

        ViewBag.DivisionId = new SelectList(_DivisionService.List().entity ?? new List<DivisionVM>(), "Id", "Name");
        ViewBag.DistrictId = new SelectList("");
        ViewBag.UpazillaId = new SelectList("");
        ViewBag.UnionId = new SelectList("");

        List<FinancialYearVM>? nursaryRaisingYearList = _financialYearService.List().entity?.OrderBy(x => x.Name).ToList();
        ViewBag.FinancialYearId = nursaryRaisingYearList ?? new List<FinancialYearVM>();

        ViewBag.NurseryList = _nurseryInformationService.List().entity ?? new List<NurseryInformationVM>();

        var result = _nurseryInformationService.GetNurseryReport(nurseryFilterVM);

        return View("NurseryReport", result.entity ?? new List<SocialForestryReportVM>());
    }
    public ActionResult NurseryDistributionReport()
    {

        ViewBag.ForestCircleId = _ForestCircleService.List().entity ?? new List<ForestCircleVM>();

        ViewBag.DivisionId = new SelectList(_DivisionService.List().entity ?? new List<DivisionVM>(), "Id", "Name");
        ViewBag.DistrictId = new SelectList("");
        ViewBag.UpazillaId = new SelectList("");
        ViewBag.UnionId = new SelectList("");

        List<FinancialYearVM>? nursaryRaisingYearList = _financialYearService.List().entity?.OrderBy(x => x.Name).ToList();
        ViewBag.FinancialYearId = nursaryRaisingYearList ?? new List<FinancialYearVM>();
        ViewBag.NurseryList = _nurseryInformationService.List().entity ?? new List<NurseryInformationVM>();


        var nurseryInformationReport = new List<SocialForestryReportVM>();

        return View(nurseryInformationReport);

    }
    [HttpPost]
    public ActionResult NurseryDistributionReport(NurseryFilterVM nurseryFilterVM)
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
                _UnionService,
                nurseryFilterVM
            );
        ViewBag.ForestCircleId = _ForestCircleService.List().entity ?? new List<ForestCircleVM>();

        ViewBag.DivisionId = new SelectList(_DivisionService.List().entity ?? new List<DivisionVM>(), "Id", "Name");
        ViewBag.DistrictId = new SelectList("");
        ViewBag.UpazillaId = new SelectList("");
        ViewBag.UnionId = new SelectList("");

        List<FinancialYearVM>? nursaryRaisingYearList = _financialYearService.List().entity?.OrderBy(x => x.Name).ToList();
        ViewBag.FinancialYearId = nursaryRaisingYearList ?? new List<FinancialYearVM>();

        ViewBag.NurseryList = _nurseryInformationService.List().entity ?? new List<NurseryInformationVM>();

        var result = _nurseryInformationService.GetNurseryDistributionReport(nurseryFilterVM);

        return View("NurseryDistributionReport", result.entity ?? new List<SocialForestryReportVM>());
    }
    public ActionResult BeneficiaryWiseDistribution()
    {

        ViewBag.ForestCircleId = _ForestCircleService.List().entity ?? new List<ForestCircleVM>();

        ViewBag.DivisionId = new SelectList(_DivisionService.List().entity ?? new List<DivisionVM>(), "Id", "Name");
        ViewBag.DistrictId = new SelectList("");
        ViewBag.UpazillaId = new SelectList("");
        ViewBag.UnionId = new SelectList("");

        List<FinancialYearVM>? nursaryRaisingYearList = _financialYearService.List().entity?.OrderBy(x => x.Name).ToList();
        ViewBag.FinancialYearId = nursaryRaisingYearList ?? new List<FinancialYearVM>();
        ViewBag.NurseryList = _nurseryInformationService.List().entity ?? new List<NurseryInformationVM>();


        var nurseryInformationReport = new List<SocialForestryReportVM>();

        return View(nurseryInformationReport);

    }
    [HttpPost]
    public ActionResult BeneficiaryWiseDistribution(NurseryFilterVM nurseryFilterVM)
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
                _UnionService,
                nurseryFilterVM
            );
        ViewBag.ForestCircleId = _ForestCircleService.List().entity ?? new List<ForestCircleVM>();

        ViewBag.DivisionId = new SelectList(_DivisionService.List().entity ?? new List<DivisionVM>(), "Id", "Name");
        ViewBag.DistrictId = new SelectList("");
        ViewBag.UpazillaId = new SelectList("");
        ViewBag.UnionId = new SelectList("");

        List<FinancialYearVM>? nursaryRaisingYearList = _financialYearService.List().entity?.OrderBy(x => x.Name).ToList();
        ViewBag.FinancialYearId = nursaryRaisingYearList ?? new List<FinancialYearVM>();

        ViewBag.NurseryList = _nurseryInformationService.List().entity ?? new List<NurseryInformationVM>();

        nurseryFilterVM.BeneficiaryNid = !string.IsNullOrEmpty(nurseryFilterVM.BeneficiaryNid) ? nurseryFilterVM.BeneficiaryNid?.Trim() : null;
        nurseryFilterVM.BeneficiaryName = !string.IsNullOrEmpty(nurseryFilterVM.BeneficiaryName) ? nurseryFilterVM.BeneficiaryName?.Trim() : null;

        var result = _nurseryInformationService.GetNurseryDistributionByBeneficiaryReport(nurseryFilterVM);

        return View("BeneficiaryWiseDistribution", result.entity ?? new List<SocialForestryReportVM>());
    }
}
