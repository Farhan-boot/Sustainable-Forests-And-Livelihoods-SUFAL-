using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.SignalR;

using Newtonsoft.Json;

using PTSL.GENERIC.Web.Controllers.GeneralSetup;
using PTSL.GENERIC.Web.Core.Helper;
using PTSL.GENERIC.Web.Core.Helper.Auth;
using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Helper.Enum.ForestManagement;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Beneficiary;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.CipManagement;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.ForestManagement;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.GeneralSetup;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.NecessaryLinkManagement;
using PTSL.GENERIC.Web.Core.Model.GeneralSetup;
using PTSL.GENERIC.Web.Core.Services.Implementation.Beneficiary;
using PTSL.GENERIC.Web.Core.Services.Implementation.CipManagement;
using PTSL.GENERIC.Web.Core.Services.Implementation.ForestManagement;
using PTSL.GENERIC.Web.Core.Services.Implementation.GeneralSetup;
using PTSL.GENERIC.Web.Core.Services.Implementation.NecessaryLinkManagement;
using PTSL.GENERIC.Web.Core.Services.Interface.Beneficiary;
using PTSL.GENERIC.Web.Core.Services.Interface.CipManagement;
using PTSL.GENERIC.Web.Core.Services.Interface.ForestManagement;
using PTSL.GENERIC.Web.Core.Services.Interface.GeneralSetup;
using PTSL.GENERIC.Web.Core.Services.Interface.NecessaryLinkManagement;
using PTSL.GENERIC.Web.Helper;
using PTSL.GENERIC.Web.Services.Implementation.GeneralSetup;

namespace PTSL.GENERIC.Web.Core.Controllers.CipManagement;


[SessionAuthorize]
public class NecessaryLinkController : Controller
{
    private readonly IForestFcvVcfService _ForestFcvVcfService;

    private readonly IForestCircleService _ForestCircleService;
    private readonly IForestDivisionService _ForestDivisionService;
    private readonly IForestRangeService _ForestRangeService;
    private readonly IForestBeatService _ForestBeatService;
    private readonly IEthnicityService _EthnicityService;
    private readonly IOtherCommitteeMemberService _OtherCommitteeMemberService;
    private readonly ISurveyService _SurveyService;
    private readonly INgoService _NgoService;

    // Civil administration
    private readonly IDivisionService _DivisionService;
    private readonly IDistrictService _DistrictService;
    private readonly IUpazillaService _UpazillaService;
    private readonly IUnionService _UnionService;
    private readonly ICommitteeDesignationService _SubCommitteeDesignationService;
    private readonly ICommitteeManagementService _CommitteeManagementService;
    private readonly ICommitteeManagementMemberService _CommitteeManagementMemberService;
    private readonly ICipService _CipService;
    private readonly ICipTeamService _CipTeamService;
    private readonly ICipTeamMemberService _CipTeamMemberService;
    private readonly INecessaryLinkService _NecessaryLinkService;
    private readonly FileHelper _fileHelper;


    public NecessaryLinkController(HttpHelper httpHelper, FileHelper fileHelper)
    {
        _ForestFcvVcfService = new ForestFcvVcfService(httpHelper);
        _ForestCircleService = new ForestCircleService(httpHelper);
        _ForestDivisionService = new ForestDivisionService(httpHelper);
        _ForestRangeService = new ForestRangeService(httpHelper);
        _ForestBeatService = new ForestBeatService(httpHelper);
        _EthnicityService = new EthnicityService(httpHelper);
        _OtherCommitteeMemberService = new OtherCommitteeMemberService(httpHelper);
        _SurveyService = new SurveyService(httpHelper);
        _NgoService = new NgoService(httpHelper);
        _DivisionService = new DivisionService(httpHelper);
        _DistrictService = new DistrictService(httpHelper);
        _UpazillaService = new UpazillaService(httpHelper);
        _UnionService = new UnionService(httpHelper);
        _CommitteeManagementService = new CommitteeManagementService(httpHelper);
        _CommitteeManagementMemberService = new CommitteeManagementMemberService(httpHelper);
        _SubCommitteeDesignationService = new CommitteeDesignationService(httpHelper);
        _CipService = new CipService(httpHelper);
        _CipTeamService = new CipTeamService(httpHelper);
        _CipTeamMemberService = new CipTeamMemberService(httpHelper);
        _NecessaryLinkService = new NecessaryLinkService(httpHelper);
        
        _fileHelper = fileHelper;
    }
    public ActionResult Index()
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
        
        (ExecutionState executionState, List<NecessaryLinkVM> entity, string message) returnResponse = _NecessaryLinkService.List();
        return View(returnResponse.entity);
    }

    public ActionResult Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }
        (ExecutionState executionState, NecessaryLinkVM entity, string message) returnResponse = _NecessaryLinkService.GetById(id);

        return View(returnResponse.entity);
    }

    public ActionResult Create()
    {
        NecessaryLinkVM entity = new NecessaryLinkVM();

        return View(entity);
    }

    [HttpPost]
    public ActionResult Create(NecessaryLinkVM entity)
    {
        try
        {
            if (ModelState.IsValid)
            {
                entity.IsActive = true;
                entity.CreatedAt = DateTime.Now;
                // TODO: Add insert logic here
                (ExecutionState executionState, NecessaryLinkVM entity, string message) returnResponse1 = _NecessaryLinkService.Create(entity);

                if (returnResponse1.executionState.ToString() != "Created")
                {
                    return View(entity);
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }

            //                Session["Message"] = _ModelStateValidation.ModelStateErrorMessage(ModelState);
            //                Session["executionState"] = ExecutionState.Failure;
            return View(entity);
        }
        catch
        {
            //                Session["Message"] = "Form Data Not Valid.";
            //                Session["executionState"] = ExecutionState.Failure;
            return View(entity);
        }
    }

    public ActionResult Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }
        (ExecutionState executionState, NecessaryLinkVM entity, string message) returnResponse = _NecessaryLinkService.GetById(id);

        return View(returnResponse.entity);
    }

    // POST: NecessaryLink/Edit/5
    [HttpPost]
    public ActionResult Edit(int id, NecessaryLinkVM entity)
    {
        try
        {
            if (ModelState.IsValid)
            {
                // TODO: Add update logic here
                if (id != entity.Id)
                {
                    return RedirectToAction(nameof(NecessaryLinkController.Index), "NecessaryLink");
                }
                entity.IsActive = true;
                entity.IsDeleted = false;
                entity.UpdatedAt = DateTime.Now;
                (ExecutionState executionState, NecessaryLinkVM entity, string message) returnResponse = _NecessaryLinkService.Update(entity);
                //                    Session["Message"] = returnResponse.message;
                //                    Session["executionState"] = returnResponse.executionState;
                if (returnResponse.executionState.ToString() != "Updated")
                {
                    return View(entity);
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            //                Session["Message"] = _ModelStateValidation.ModelStateErrorMessage(ModelState);
            //                Session["executionState"] = ExecutionState.Failure;
            return View(entity);
        }
        catch
        {
            //                Session["Message"] = "Form Data Not Valid.";
            //                Session["executionState"] = ExecutionState.Failure;
            return View(entity);
        }
    }

    public JsonResult Delete(int id)
    {
        var result = _NecessaryLinkService.SoftDelete(id);
        if (result.isDeleted)
        {
            result.message = "Item deleted successfully.";
        }
        else
        {
            result.message = "Failed to delete this item.";
        }

        return Json(new { Message = result.message, result.executionState }, SerializerOption.Default);
    }

}
