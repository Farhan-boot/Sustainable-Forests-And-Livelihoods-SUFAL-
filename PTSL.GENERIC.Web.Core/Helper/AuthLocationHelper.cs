using Microsoft.AspNetCore.Mvc.Rendering;

using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Beneficiary;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Common;
using PTSL.GENERIC.Web.Core.Model.GeneralSetup;
using PTSL.GENERIC.Web.Core.Services.Interface.Beneficiary;
using PTSL.GENERIC.Web.Core.Services.Interface.GeneralSetup;

namespace PTSL.GENERIC.Web.Core.Helper;

public static class AuthLocationHelper
{
    public static void GenerateViewBagForForestAndCivil(
        HttpContext context,
        dynamic viewBag,
        IForestCircleService forestCircleService,
        IForestDivisionService forestDivisionService,
        IForestRangeService forestRangeService,
        IForestBeatService forestBeatService,
        IForestFcvVcfService forestFcvVcfService,

        IDivisionService divisionService,
        IDistrictService districtService,
        IUpazillaService upazillaService,
        IUnionService unionService,
        ForestCivilLocationFilter? filter = null
        )
    {
        _ = long.TryParse(context.Session.GetString(SessionKey.DivisionId), out var divisionId);
        _ = long.TryParse(context.Session.GetString(SessionKey.DistrictId), out var districtId);
        _ = long.TryParse(context.Session.GetString(SessionKey.UpazillaId), out var upazillaId);
        _ = long.TryParse(context.Session.GetString(SessionKey.UnionId), out var unionId);

        ForestAdministration(
            context,
            viewBag, 
            forestCircleService,
            forestDivisionService, 
            forestRangeService, 
            forestBeatService, 
            forestFcvVcfService, 
            filter);

        // Division
        if (divisionId > 0)
        {
            viewBag.DivisionId = new SelectList(
                new List<DivisionVM>()
                {
                    divisionService.GetById(divisionId).entity ?? new DivisionVM()
                }
                , "Id", "Name", divisionId);
        }
        else
        {
            viewBag.DivisionId = filter?.DivisionId > 0
                ? new SelectList(divisionService.List().entity ?? new List<DivisionVM>(), "Id", "Name", filter.DivisionId)
                : new SelectList(divisionService.List().entity ?? new List<DivisionVM>(), "Id", "Name");
        }

        // District
        if (districtId > 0)
        {
            viewBag.DistrictId = new SelectList(
                new List<DistrictVM>()
                {
                    districtService.GetById(districtId).entity ?? new DistrictVM()
                }
                , "Id", "Name", districtId);
        }
        else
        {
            viewBag.DistrictId = filter?.DivisionId > 0
                ? new SelectList(districtService.ListByDivision(filter?.DivisionId ?? 0).entity ?? new List<DistrictVM>(), "Id", "Name", filter?.DistrictId)
                : new SelectList("");
        }

        // Upazilla
        if (upazillaId > 0)
        {
            viewBag.UpazillaId = new SelectList(
                new List<UpazillaVM>()
                {
                    upazillaService.GetById(upazillaId).entity ?? new UpazillaVM()
                }
                , "Id", "Name", upazillaId);
        }
        else
        {
            viewBag.UpazillaId = filter?.DistrictId > 0
                ? new SelectList(upazillaService.ListByDistrict(filter?.DistrictId ?? 0).entity ?? new List<UpazillaVM>(), "Id", "Name", filter?.UpazillaId)
                : new SelectList("");
        }

        // Union
        if (unionId > 0)
        {
            viewBag.UnionId = new SelectList(
                new List<UnionVM>()
                {
                    unionService.GetById(unionId).entity ?? new UnionVM()
                }
                , "Id", "Name", unionId);
        }
        else
        {
            viewBag.UnionId = filter?.UpazillaId > 0
                ? new SelectList(unionService.ListByUpazilla(filter?.UpazillaId ?? 0).entity ?? new List<UnionVM>(), "Id", "Name", filter?.UnionId)
                : new SelectList("");
        }
    }

    private static void ForestAdministration(HttpContext context, dynamic viewBag, IForestCircleService forestCircleService, IForestDivisionService forestDivisionService, IForestRangeService forestRangeService, IForestBeatService forestBeatService, IForestFcvVcfService forestFcvVcfService, ForestCivilLocationFilter? filter)
    {
        _ = long.TryParse(context.Session.GetString(SessionKey.ForestCircleId), out var forestCircleId);
        _ = long.TryParse(context.Session.GetString(SessionKey.ForestDivisionId), out var forestDivisionId);
        _ = long.TryParse(context.Session.GetString(SessionKey.ForestRangeId), out var forestRangeId);
        _ = long.TryParse(context.Session.GetString(SessionKey.ForestBeatId), out var forestBeatId);
        _ = long.TryParse(context.Session.GetString(SessionKey.ForestFcvVcfId), out var forestFcvVcfId);

        // Forest Circle
        if (forestCircleId > 0)
        {
            viewBag.ForestCircleId = new SelectList(
                new List<ForestCircleVM>()
                {
                    forestCircleService.GetById(forestCircleId).entity ?? new ForestCircleVM()
                }
                , "Id", "Name", forestCircleId);
        }
        else
        {
            viewBag.ForestCircleId = filter?.ForestCircleId > 0
                ? new SelectList(forestCircleService.List().entity ?? new List<ForestCircleVM>(), "Id", "Name", filter.ForestCircleId)
                : new SelectList(forestCircleService.List().entity ?? new List<ForestCircleVM>(), "Id", "Name");
        }

        // Forest Division
        if (forestDivisionId > 0)
        {
            viewBag.ForestDivisionId = new SelectList(
                new List<ForestDivisionVM>()
                {
                    forestDivisionService.GetById(forestDivisionId).entity ?? new ForestDivisionVM()
                }
                , "Id", "Name", forestDivisionId);
        }
        else
        {
            viewBag.ForestDivisionId = filter?.ForestCircleId > 0
                ? new SelectList(forestDivisionService.ListByForestCircle(filter?.ForestCircleId ?? 0).entity ?? new List<ForestDivisionVM>(), "Id", "Name", filter?.ForestDivisionId)
                : new SelectList("");
        }

        // Forest Range
        if (forestRangeId > 0)
        {
            viewBag.ForestRangeId = new SelectList(
                new List<ForestRangeVM>()
                {
                    forestRangeService.GetById(forestRangeId).entity ?? new ForestRangeVM()
                }
                , "Id", "Name", forestRangeId);
        }
        else
        {
            viewBag.ForestRangeId = filter?.ForestDivisionId > 0
                ? new SelectList(forestRangeService.ListByForestDivision(filter.ForestDivisionId ?? 0).entity ?? new List<ForestRangeVM>(), "Id", "Name", filter?.ForestRangeId)
                : new SelectList("");
        }

        // Forest Beat
        if (forestBeatId > 0)
        {
            viewBag.ForestBeatId = new SelectList(
                new List<ForestBeatVM>()
                {
                    forestBeatService.GetById(forestBeatId).entity ?? new ForestBeatVM()
                }
                , "Id", "Name", forestBeatId);
        }
        else
        {
            viewBag.ForestBeatId = filter?.ForestRangeId > 0
                ? new SelectList(forestBeatService.ListByForestRange(filter?.ForestRangeId ?? 0).entity ?? new List<ForestBeatVM>(), "Id", "Name", filter?.ForestBeatId)
                : new SelectList("");
        }

        // Forest FcvVcf
        if (forestFcvVcfId > 0)
        {
            var fcv =
                new List<ForestFcvVcfVM>()
                {
                    forestFcvVcfService.GetById(forestFcvVcfId).entity ?? new ForestFcvVcfVM()
                };
            viewBag.ForestFcvVcfId = new SelectList(fcv, "Id", "Name", forestFcvVcfId);
            viewBag.FcvVcfType = new SelectList(EnumHelper.GetEnumDropdowns<FcvVcfType>(), "Id", "Name", FcvVcfHelper.GetFcvVcfType(fcv, forestFcvVcfId));
        }
        else
        {
            var fcv = filter?.ForestBeatId > 0 ? forestFcvVcfService.ListByForestBeat(filter?.ForestBeatId ?? 0).entity ?? new List<ForestFcvVcfVM>() : new List<ForestFcvVcfVM>();

            viewBag.ForestFcvVcfId = filter?.ForestBeatId > 0
                ? new SelectList(fcv, "Id", "Name", filter?.ForestFcvVcfId)
                : new SelectList("");

            viewBag.FcvVcfType = new SelectList(EnumHelper.GetEnumDropdowns<FcvVcfType>(), "Id", "Name", FcvVcfHelper.GetFcvVcfType(fcv, filter?.ForestFcvVcfId));
        }
    }

    public static void GenerateViewBagForForest(
        HttpContext context,
        dynamic viewBag,
        IForestCircleService forestCircleService,
        IForestDivisionService forestDivisionService,
        IForestRangeService forestRangeService,
        IForestBeatService forestBeatService,
        IForestFcvVcfService forestFcvVcfService,

        long? forestCircleId = 0,
        long? forestDivisionId = 0,
        long? forestRangeId = 0,
        long? forestBeatId = 0,
        long? forestFcvVcfId = 0
        )
    {
        ForestAdministration(
            context,
            viewBag, 
            forestCircleService,
            forestDivisionService, 
            forestRangeService, 
            forestBeatService, 
            forestFcvVcfService, 
            new ForestCivilLocationFilter
            {
                ForestCircleId = forestCircleId,
                ForestDivisionId = forestDivisionId,
                ForestRangeId = forestRangeId,
                ForestBeatId = forestBeatId,
                ForestFcvVcfId = forestFcvVcfId
            });
    }

    public static void GenerateViewBagForForestAndCivil(
        HttpContext context,
        dynamic viewBag,
        IForestCircleService forestCircleService,
        IForestDivisionService forestDivisionService,
        IForestRangeService forestRangeService,
        IForestBeatService forestBeatService,
        IForestFcvVcfService forestFcvVcfService,

        IDivisionService divisionService,
        IDistrictService districtService,
        IUpazillaService upazillaService,
        IUnionService unionService,

        long? forestCircleId,
        long? forestDivisionId,
        long? forestRangeId,
        long? forestBeatId,
        long? forestFcvVcfId,
        long? divisionId,
        long? districtId,
        long? upazillaId,
        long? unionId
        )
    {
        GenerateViewBagForForestAndCivil(
            context,
            viewBag,
            forestCircleService,
            forestDivisionService,
            forestRangeService,
            forestBeatService,
            forestFcvVcfService,
            divisionService,
            districtService,
            upazillaService,
            unionService,
            new ForestCivilLocationFilter
            {
                ForestCircleId = forestCircleId,
                ForestDivisionId = forestDivisionId,
                ForestRangeId = forestRangeId,
                ForestBeatId = forestBeatId,
                ForestFcvVcfId = forestFcvVcfId,
                DivisionId = divisionId,
                DistrictId = districtId,
                UpazillaId = upazillaId,
                UnionId = unionId
            }
        );
    }

    public static T GetFilterFromSession<T>(HttpContext context, int? take = 50) where T : ForestCivilLocationFilter, new()
    {
        _ = long.TryParse(context.Session.GetString(SessionKey.ForestCircleId), out var forestCircleId);
        _ = long.TryParse(context.Session.GetString(SessionKey.ForestDivisionId), out var forestDivisionId);
        _ = long.TryParse(context.Session.GetString(SessionKey.ForestRangeId), out var forestRangeId);
        _ = long.TryParse(context.Session.GetString(SessionKey.ForestBeatId), out var forestBeatId);
        _ = long.TryParse(context.Session.GetString(SessionKey.ForestFcvVcfId), out var forestFcvVcfId);

        _ = long.TryParse(context.Session.GetString(SessionKey.DivisionId), out var divisionId);
        _ = long.TryParse(context.Session.GetString(SessionKey.DistrictId), out var districtId);
        _ = long.TryParse(context.Session.GetString(SessionKey.UpazillaId), out var upazillaId);
        _ = long.TryParse(context.Session.GetString(SessionKey.UnionId), out var unionId);

        return new T
        {
            ForestCircleId = forestCircleId,
            ForestDivisionId = forestDivisionId,
            ForestRangeId = forestRangeId,
            ForestBeatId = forestBeatId,
            ForestFcvVcfId = forestFcvVcfId,
            DivisionId = divisionId,
            DistrictId = districtId,
            UpazillaId = upazillaId,
            UnionId = unionId,
            Take = take
        };
    }

    public static ForestCivilLocationVM GetSurveyFilterFromSession(HttpContext context, int? take = 50)
    {
        _ = long.TryParse(context.Session.GetString(SessionKey.ForestCircleId), out var forestCircleId);
        _ = long.TryParse(context.Session.GetString(SessionKey.ForestDivisionId), out var forestDivisionId);
        _ = long.TryParse(context.Session.GetString(SessionKey.ForestRangeId), out var forestRangeId);
        _ = long.TryParse(context.Session.GetString(SessionKey.ForestBeatId), out var forestBeatId);
        _ = long.TryParse(context.Session.GetString(SessionKey.ForestFcvVcfId), out var forestFcvVcfId);

        _ = long.TryParse(context.Session.GetString(SessionKey.DivisionId), out var divisionId);
        _ = long.TryParse(context.Session.GetString(SessionKey.DistrictId), out var districtId);
        _ = long.TryParse(context.Session.GetString(SessionKey.UpazillaId), out var upazillaId);
        _ = long.TryParse(context.Session.GetString(SessionKey.UnionId), out var unionId);

        return new ForestCivilLocationVM
        {
            ForestCircleId = forestCircleId,
            ForestDivisionId = forestDivisionId,
            ForestRangeId = forestRangeId,
            ForestBeatId = forestBeatId,
            ForestFcvVcfId = forestFcvVcfId,
            PresentDivisionId = divisionId,
            PresentDistrictId = districtId,
            PresentUpazillaId = upazillaId,
            PresentUnionId = unionId,

            Take = take
        };
    }
}

