using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Business.BaseBusinesses;
using PTSL.GENERIC.Business.Businesses.Interface.Beneficiary;
using PTSL.GENERIC.Common.Entity;
using PTSL.GENERIC.Common.Entity.AIG;
using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Entity.BeneficiarySavingsAccount;
using PTSL.GENERIC.Common.Entity.Capacity;
using PTSL.GENERIC.Common.Entity.Dashboard;
using PTSL.GENERIC.Common.Entity.GeneralSetup;
using PTSL.GENERIC.Common.Entity.Labour;
using PTSL.GENERIC.Common.Entity.MeetingManagement;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Enum.AIG;
using PTSL.GENERIC.Common.Enum.Beneficiary;
using PTSL.GENERIC.Common.Helper;
using PTSL.GENERIC.Common.Model.BaseModels;
using PTSL.GENERIC.Common.Model.CustomModel;
using PTSL.GENERIC.Common.Model.EntityViewModels;
using PTSL.GENERIC.Common.Model.EntityViewModels.Beneficiary;
using PTSL.GENERIC.Common.Model.EntityViewModels.DashBoard;
using PTSL.GENERIC.Common.QuerySerialize.Implementation;
using PTSL.GENERIC.DAL.UnitOfWork;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTSL.GENERIC.Business.Businesses.Implementation.Beneficiary
{
    public class SurveyBusiness : BaseBusiness<Survey>, ISurveyBusiness
    {
        public readonly GENERICUnitOfWork _unitOfWork;
        private readonly GENERICReadOnlyCtx _readOnlyContext;
        private readonly GENERICWriteOnlyCtx _writeOnlyCtx;

        public SurveyBusiness(GENERICUnitOfWork unitOfWork, GENERICReadOnlyCtx readOnlyContext, GENERICWriteOnlyCtx writeOnlyCtx)
            : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _readOnlyContext = readOnlyContext;
            _writeOnlyCtx = writeOnlyCtx;
        }

        public async Task<(ExecutionState executionState, IList<SurveyEssentialVM> entity, string message)> ListLatest(int take = 50)
        {
            var surveyList = await _readOnlyContext.Set<Survey>()
                .OrderByDescending(x => x.Id)
                .Include(x => x.ForestFcvVcf)
                .Take(take)
                .Skip(0)
                .Select(x =>
                    new SurveyEssentialVM()
                    {
                        Id = x.Id,
                        BeneficiaryName = x.BeneficiaryName,
                        BeneficiaryNameBn = x.BeneficiaryNameBn,
                        BeneficiaryNid = x.BeneficiaryNid,
                        BeneficiaryPhone = x.BeneficiaryPhone,
                        BeneficiaryPhoneBn = x.BeneficiaryPhoneBn,
                        BeneficiaryGender = x.BeneficiaryGender,
                        BeneficiaryGenderString = x.BeneficiaryGender.ToString(),
                        BeneficiaryEthnicityId = x.BeneficiaryEthnicityId,
                        BeneficiaryEthnicityTxt = x.BeneficiaryEthnicityTxt,
                        ForestFcvVcf = new ForestFcvVcfVM { Name = x.ForestFcvVcf.Name, NameBn = x.ForestFcvVcf.NameBn, Id = x.ForestFcvVcf.Id },
                        BeneficiaryAge = x.BeneficiaryAge,
                        BeneficiaryAgeBn = x.BeneficiaryAgeBn,
                        BeneficiaryFatherName = x.BeneficiaryFatherName,
                        BeneficiaryFatherNameBn = x.BeneficiaryFatherNameBn,
                        BeneficiaryMotherName = x.BeneficiaryMotherName,
                        BeneficiaryMotherNameBn = x.BeneficiaryMotherNameBn,
                        BeneficiarySpouseName = x.BeneficiarySpouseName,
                        BeneficiarySpouseNameBn = x.BeneficiarySpouseNameBn,
                        HeadOfHouseholdName = x.HeadOfHouseholdName,
                        HeadOfHouseholdNameBn = x.HeadOfHouseholdNameBn,
                        HeadOfHouseholdGender = x.HeadOfHouseholdGender,
                        PresentVillageName = x.PresentVillageName,
                        PresentVillageNameBn = x.PresentVillageNameBn,
                        PresentPostOfficeName = x.PresentPostOfficeName,
                        PresentPostOfficeNameBn = x.PresentPostOfficeNameBn,
                        PresentDivisionId = x.PresentDivisionId,
                        PresentDistrictId = x.PresentDistrictId,
                        PresentUpazillaId = x.PresentUpazillaId,
                        PresentUnion = x.PresentUnion,
                        IsPermanentSameAsPresent = x.IsPermanentSameAsPresent,
                        PermanentVillageName = x.PermanentVillageName,
                        PermanentVillageNameBn = x.PermanentVillageNameBn,
                        PermanentPostOfficeName = x.PermanentPostOfficeName,
                        PermanentPostOfficeNameBn = x.PermanentPostOfficeNameBn,
                        PermanentDivisionId = x.PermanentDivisionId,
                        PermanentDistrictId = x.PermanentDistrictId,
                        PermanentUpazillaId = x.PermanentUpazillaId,
                        PermanentUnion = x.PermanentUnion,
                        PermanentUnionBn = x.PermanentUnionBn,
                        BeneficiaryLatitude = x.BeneficiaryLatitude,
                        BeneficiaryLongitude = x.BeneficiaryLongitude,
                        BeneficiaryAltitude = x.BeneficiaryAltitude,
                        BeneficiaryPrecision = x.BeneficiaryPrecision,
                        BeneficiaryHouseFrontImage = x.BeneficiaryHouseFrontImage,
                        BeneficiaryHouseFrontImageURL = x.BeneficiaryHouseFrontImageURL,
                        BeneficiaryHouseType = x.BeneficiaryHouseType,
                        BeneficiaryHouseTypeString = x.BeneficiaryHouseType.GetEnumDisplayName(),
                        GrandTotalLivestockCost = x.GrandTotalLivestockCost,
                        GrandTotalAssetsCost = x.GrandTotalAssetsCost,
                        GrandTotalImmovableAnnualReturn = x.GrandTotalImmovableAnnualReturn,
                        GrandTotalEnergyUsesMonthly = x.GrandTotalEnergyUsesMonthly,
                        GrandTotalNetIncomeAgriculture = x.GrandTotalNetIncomeAgriculture,
                        GrandTotalLandArea = x.GrandTotalLandArea,
                        GrandTotalGrossMarginAgriculture = x.GrandTotalGrossMarginAgriculture,
                        BeneficiaryApproveStatus = x.BeneficiaryApproveStatus,
                        BeneficiaryApproveStatusString = x.BeneficiaryApproveStatus.ToString()
                    }
                )
                .ToListAsync();

            return (executionState: ExecutionState.Retrieved, surveyList, "Survey retrieved successfully");
        }

        public override Task<(ExecutionState executionState, Survey entity, string message)> GetAsync(long key)
        {
            var filterOptions = new FilterOptions<Survey>()
            {
                FilterExpression = e => e.Id == key,
                IncludeExpression = e => e.Include(x => x.SurveyDocuments!)
            };

            return base.GetAsync(filterOptions);
        }

        public Task<(ExecutionState executionState, Survey entity, string message)> GetDetailsAsync(long key)
        {
            var filterOptions = new FilterOptions<Survey>()
            {
                FilterExpression = e => e.Id == key,
                IncludeExpression = e => e.Include(x => x.ForestCircle!)
                    .Include(x => x.ForestDivision!)
                    .Include(x => x.ForestRange!)
                    .Include(x => x.ForestBeat!)
                    .Include(x => x.ForestFcvVcf!)
                    .Include(x => x.Ngo!)
                    .Include(x => x.BeneficiaryEthnicity!)
                    .Include(x => x.PresentDivision!)
                    .Include(x => x.PresentDistrict!)
                    .Include(x => x.PresentUpazilla!)
                    .Include(x => x.PresentUnionNew!)
                    .Include(x => x.PermanentDivision!)
                    .Include(x => x.PermanentDistrict!)
                    .Include(x => x.PermanentUpazilla!)
                    .Include(x => x.PermanentUnionNew!)
                    .Include(x => x.SurveyDocuments!)
                    .Include(x => x.TypeOfHouse!)
            };

            return base.GetAsync(filterOptions);
        }

        public async Task<(ExecutionState executionState, IQueryable<HouseholdMember> entity, string message)> LoadMembers(long surveyId)
        {
            var filterOptions = new QueryOptions<HouseholdMember>()
            {
                FilterExpression = e => e.SurveyId == surveyId,
                IncludeExpression = e =>
                    e.Include(x => x.BFDAssociationHouseholdMembers!)
                    .Include(x => x.DisabilityTypeHouseholdMembers!)
            };

            return await _unitOfWork.List(filterOptions);
        }

        public async Task<(ExecutionState executionState, IQueryable<ExistingSkill> entity, string message)> LoadExistingSkill(long surveyId)
        {
            var filterOptions = new QueryOptions<ExistingSkill>()
            {
                FilterExpression = e => e.SurveyId == surveyId,
            };

            return await _unitOfWork.List(filterOptions);
        }

        public async Task<(ExecutionState executionState, IQueryable<AnnualHouseholdExpenditure> entity, string message)> LoadAnnualHouseholdExpenditure(long surveyId)
        {
            var filterOptions = new QueryOptions<AnnualHouseholdExpenditure>()
            {
                FilterExpression = e => e.SurveyId == surveyId,
            };

            return await _unitOfWork.List(filterOptions);
        }

        public async Task<(ExecutionState executionState, IQueryable<FoodSecurityItem> entity, string message)> LoadFoodSecurityItem(long surveyId)
        {
            var filterOptions = new QueryOptions<FoodSecurityItem>()
            {
                FilterExpression = e => e.SurveyId == surveyId,
            };

            return await _unitOfWork.List(filterOptions);
        }

        public async Task<(ExecutionState executionState, IQueryable<VulnerabilitySituation> entity, string message)> LoadVulnerabilitySituation(long surveyId)
        {
            var filterOptions = new QueryOptions<VulnerabilitySituation>()
            {
                FilterExpression = e => e.SurveyId == surveyId,
            };

            return await _unitOfWork.List(filterOptions);
        }

        public async Task<(ExecutionState executionState, IQueryable<GrossMarginIncomeAndCostStatus> entity, string message)> LoadGrossMarginIncomeAndCostStatus(long surveyId)
        {
            var filterOptions = new QueryOptions<GrossMarginIncomeAndCostStatus>()
            {
                FilterExpression = e => e.SurveyId == surveyId,
            };

            return await _unitOfWork.List(filterOptions);
        }

        public async Task<(ExecutionState executionState, IQueryable<ManualPhysicalWork> entity, string message)> LoadManualPhysicalWork(long surveyId)
        {
            var filterOptions = new QueryOptions<ManualPhysicalWork>()
            {
                FilterExpression = e => e.SurveyId == surveyId,
            };

            return await _unitOfWork.List(filterOptions);
        }

        public async Task<(ExecutionState executionState, IQueryable<NaturalResourcesIncomeAndCostStatus> entity, string message)> LoadNaturalResourcesIncomeAndCostStatus(long surveyId)
        {
            var filterOptions = new QueryOptions<NaturalResourcesIncomeAndCostStatus>()
            {
                FilterExpression = e => e.SurveyId == surveyId,
            };

            return await _unitOfWork.List(filterOptions);
        }

        public async Task<(ExecutionState executionState, IQueryable<OtherIncomeSource> entity, string message)> LoadOtherIncomeSource(long surveyId)
        {
            var filterOptions = new QueryOptions<OtherIncomeSource>()
            {
                FilterExpression = e => e.SurveyId == surveyId,
            };

            return await _unitOfWork.List(filterOptions);
        }

        public async Task<(ExecutionState executionState, IQueryable<Common.Entity.Beneficiary.Business> entity, string message)> LoadBusiness(long surveyId)
        {
            var filterOptions = new QueryOptions<Common.Entity.Beneficiary.Business>()
            {
                FilterExpression = e => e.SurveyId == surveyId,
            };

            return await _unitOfWork.List(filterOptions);
        }

        public async Task<(ExecutionState executionState, IQueryable<LandOccupancy> entity, string message)> LoadLandOccupancy(long surveyId)
        {
            var filterOptions = new QueryOptions<LandOccupancy>()
            {
                FilterExpression = e => e.SurveyId == surveyId,
            };

            return await _unitOfWork.List(filterOptions);
        }

        public async Task<(ExecutionState executionState, IQueryable<LiveStock> entity, string message)> LoadLiveStock(long surveyId)
        {
            var filterOptions = new QueryOptions<LiveStock>()
            {
                FilterExpression = e => e.SurveyId == surveyId,
            };

            return await _unitOfWork.List(filterOptions);
        }

        public async Task<(ExecutionState executionState, IQueryable<Asset> entity, string message)> LoadAsset(long surveyId)
        {
            var filterOptions = new QueryOptions<Asset>()
            {
                FilterExpression = e => e.SurveyId == surveyId,
            };

            return await _unitOfWork.List(filterOptions);
        }

        public async Task<(ExecutionState executionState, IQueryable<ImmovableAsset> entity, string message)> LoadImmovableAsset(long surveyId)
        {
            var filterOptions = new QueryOptions<ImmovableAsset>()
            {
                FilterExpression = e => e.SurveyId == surveyId,
            };

            return await _unitOfWork.List(filterOptions);
        }

        public async Task<(ExecutionState executionState, IQueryable<EnergyUse> entity, string message)> LoadEnergyUse(long surveyId)
        {
            var filterOptions = new QueryOptions<EnergyUse>()
            {
                FilterExpression = e => e.SurveyId == surveyId,
            };

            return await _unitOfWork.List(filterOptions);
        }

        public async Task<(ExecutionState executionState, EconomicStatusModel entity, string message)> LoadEconomicStatus(long surveyId)
        {
            try
            {
                var landQuery = new QueryOptions<LandOccupancy>()
                {
                    FilterExpression = e => e.SurveyId == surveyId,
                };
                var liveStockQuery = new QueryOptions<LiveStock>()
                {
                    FilterExpression = e => e.SurveyId == surveyId,
                };
                var assetQuery = new QueryOptions<Asset>()
                {
                    FilterExpression = e => e.SurveyId == surveyId,
                };
                var immovableAssetQuery = new QueryOptions<ImmovableAsset>()
                {
                    FilterExpression = e => e.SurveyId == surveyId,
                };
                var energyUseQuery = new QueryOptions<EnergyUse>()
                {
                    FilterExpression = e => e.SurveyId == surveyId,
                };

                var landOccupancies = await _unitOfWork.List(landQuery);
                var liveStocks = await _unitOfWork.List(liveStockQuery);
                var assets = await _unitOfWork.List(assetQuery);
                var immovableAssets = await _unitOfWork.List(immovableAssetQuery);
                var energyUses = await _unitOfWork.List(energyUseQuery);
                return (
                    executionState: ExecutionState.Retrieved, new EconomicStatusModel
                    {
                        LandOccupancies = landOccupancies.entity.ToList() ?? new List<LandOccupancy>(),
                        LiveStocks = liveStocks.entity.ToList() ?? new List<LiveStock>(),
                        Assets = assets.entity.ToList() ?? new List<Asset>(),
                        ImmovableAssets = immovableAssets.entity.ToList() ?? new List<ImmovableAsset>(),
                        EnergyUses = energyUses.entity.ToList() ?? new List<EnergyUse>(),
                    },
                    "Data loaded successfully.");
            }
            catch (Exception)
            {
                return (executionState: ExecutionState.Success, null!, "Unexpected error occured");
            }
        }

        public Task<(ExecutionState executionState, IQueryable<Survey> entity, string message)> GetBeneficiaryByFcvVcf(long fcvVcfId)
        {
            var queryOptions = new QueryOptions<Survey>
            {
                FilterExpression = x => x.ForestFcvVcfId == fcvVcfId,
            };

            return base.List(queryOptions);
        }

        public async Task<(ExecutionState executionState, PaginationResutl<SurveyEssentialVM> entity, string message)> GetBeneficiaryByFilter(BeneficiaryFilterVM filter)
        {
            try
            {
                if (
                    (filter.ForestCivilLocation == null
                    || (filter.ForestCivilLocation?.HasForestCircleId == false
                        && filter.ForestCivilLocation?.HasForestDivisionId == false
                        && filter.ForestCivilLocation?.HasForestRangeId == false
                        && filter.ForestCivilLocation?.HasForestBeatId == false
                        && filter.ForestCivilLocation?.HasForestFcvVcfId == false
                        && filter.ForestCivilLocation?.HasDistrictId == false
                        && filter.ForestCivilLocation?.HasDivisionId == false
                        && filter.ForestCivilLocation?.HasTake == false)
                    )
                    && filter.ForestCivilLocation?.HasUpazillaId == false
                    && filter.ForestCivilLocation?.HasUnionId == false
                    && filter.HasNID == false
                    && filter.HasPhoneNumber == false
                    && filter.HasGender == false
                    && filter.HasEthnicityId == false
                    && filter.HasNgoId == false
                    && filter.HasBeneficiaryName == false
                    && filter.HasFcvVcfName == false
                    )
                {
                    return (ExecutionState.Retrieved, new PaginationResutl<SurveyEssentialVM>(), "Empty Data.");
                }

                //IQueryable<Survey> query = _readOnlyContext.Set<Survey>()
                //    .OrderByDescending(x => x.Id);


                if (filter.sSearch != null)
                {
                    IQueryable<Survey> queryTotalSearch = _readOnlyContext.Set<Survey>()
                   .OrderByDescending(x => x.Id);
                    IQueryable<Survey> querySearch = _readOnlyContext.Set<Survey>()
                                     .OrderByDescending(x => x.Id);

                    querySearch = querySearch.Where(x => x.BeneficiaryName.Contains(filter.sSearch) || x.BeneficiaryNid.Contains(filter.sSearch));
                    var resultSearch = await querySearch.ToListAsync();


                    var result2 = await querySearch
            .Include(x => x.ForestFcvVcf)
            .Select(x =>
                new SurveyEssentialVM()
                {
                    Id = x.Id,

                    BeneficiaryName = x.BeneficiaryName,
                    BeneficiaryNameBn = x.BeneficiaryNameBn,
                    BeneficiaryNid = x.BeneficiaryNid,
                    BeneficiaryPhone = x.BeneficiaryPhone,
                    BeneficiaryPhoneBn = x.BeneficiaryPhoneBn,
                    BeneficiaryGender = x.BeneficiaryGender,
                    BeneficiaryGenderString = x.BeneficiaryGender.ToString(),
                    BeneficiaryEthnicityId = x.BeneficiaryEthnicityId,
                    BeneficiaryEthnicityTxt = x.BeneficiaryEthnicityTxt,
                    ForestFcvVcf = new ForestFcvVcfVM { Name = x.ForestFcvVcf.Name, NameBn = x.ForestFcvVcf.NameBn, Id = x.ForestFcvVcf.Id },
                    BeneficiaryAge = x.BeneficiaryAge,
                    BeneficiaryAgeBn = x.BeneficiaryAgeBn,
                    BeneficiaryFatherName = x.BeneficiaryFatherName,
                    BeneficiaryFatherNameBn = x.BeneficiaryFatherNameBn,
                    BeneficiaryMotherName = x.BeneficiaryMotherName,
                    BeneficiaryMotherNameBn = x.BeneficiaryMotherNameBn,
                    BeneficiarySpouseName = x.BeneficiarySpouseName,
                    BeneficiarySpouseNameBn = x.BeneficiarySpouseNameBn,
                    HeadOfHouseholdName = x.HeadOfHouseholdName,
                    HeadOfHouseholdNameBn = x.HeadOfHouseholdNameBn,
                    HeadOfHouseholdGender = x.HeadOfHouseholdGender,
                    PresentVillageName = x.PresentVillageName,
                    PresentVillageNameBn = x.PresentVillageNameBn,
                    PresentPostOfficeName = x.PresentPostOfficeName,
                    PresentPostOfficeNameBn = x.PresentPostOfficeNameBn,
                    PresentDivisionId = x.PresentDivisionId,
                    PresentDistrictId = x.PresentDistrictId,
                    PresentUpazillaId = x.PresentUpazillaId,
                    PresentUnion = x.PresentUnion,
                    IsPermanentSameAsPresent = x.IsPermanentSameAsPresent,
                    PermanentVillageName = x.PermanentVillageName,
                    PermanentVillageNameBn = x.PermanentVillageNameBn,
                    PermanentPostOfficeName = x.PermanentPostOfficeName,
                    PermanentPostOfficeNameBn = x.PermanentPostOfficeNameBn,
                    PermanentDivisionId = x.PermanentDivisionId,
                    PermanentDistrictId = x.PermanentDistrictId,
                    PermanentUpazillaId = x.PermanentUpazillaId,
                    PermanentUnion = x.PermanentUnion,
                    PermanentUnionBn = x.PermanentUnionBn,
                    BeneficiaryLatitude = x.BeneficiaryLatitude,
                    BeneficiaryLongitude = x.BeneficiaryLongitude,
                    BeneficiaryAltitude = x.BeneficiaryAltitude,
                    BeneficiaryPrecision = x.BeneficiaryPrecision,
                    BeneficiaryHouseFrontImage = x.BeneficiaryHouseFrontImage,
                    BeneficiaryHouseFrontImageURL = x.BeneficiaryHouseFrontImageURL,
                    BeneficiaryHouseType = x.BeneficiaryHouseType,
                    BeneficiaryHouseTypeString = x.BeneficiaryHouseType.GetEnumDisplayName(),
                    GrandTotalLivestockCost = x.GrandTotalLivestockCost,
                    GrandTotalAssetsCost = x.GrandTotalAssetsCost,
                    GrandTotalImmovableAnnualReturn = x.GrandTotalImmovableAnnualReturn,
                    GrandTotalEnergyUsesMonthly = x.GrandTotalEnergyUsesMonthly,
                    GrandTotalNetIncomeAgriculture = x.GrandTotalNetIncomeAgriculture,
                    GrandTotalLandArea = x.GrandTotalLandArea,
                    GrandTotalGrossMarginAgriculture = x.GrandTotalGrossMarginAgriculture,
                    BeneficiaryApproveStatus = x.BeneficiaryApproveStatus,
                    BeneficiaryApproveStatusString = x.BeneficiaryApproveStatus.ToString()
                }
            )
            .ToListAsync();




                    return (ExecutionState.Retrieved, new PaginationResutl<SurveyEssentialVM>
                    {
                        aaData = result2,
                        iTotalDisplayRecords = await queryTotalSearch.CountAsync(),
                        iTotalRecords = await queryTotalSearch.CountAsync(),
                    }, "Data returned successfully.");
                }





                IQueryable<Survey> query;
                if (filter.iDisplayStart != null || filter.iDisplayLength != null)
                {
                    query = _readOnlyContext.Set<Survey>()
                                      .OrderByDescending(x => x.Id)
                                      .Skip(filter.iDisplayStart ?? 0)
                                      .Take(filter.iDisplayLength ?? 0);
                }
                else
                {
                    query = _readOnlyContext.Set<Survey>()
                                       .OrderByDescending(x => x.Id);
                }
                IQueryable<Survey> queryTotal = _readOnlyContext.Set<Survey>()
               .OrderByDescending(x => x.Id);


                // Common
                query = query.WhereIf(filter.HasGender, x => x.BeneficiaryGender == filter.Gender);
                query = query.WhereIf(filter.HasPhoneNumber, x => x.BeneficiaryPhone == filter.PhoneNumber);
                query = query.WhereIf(filter.HasNID, x => x.BeneficiaryNid == filter.NID);
                query = query.WhereIf(filter.HasEthnicityId, x => x.BeneficiaryEthnicityId == filter.EthnicityId);
                query = query.WhereIf(filter.HasNgoId, x => x.NgoId == filter.NgoId);

                query = query.WhereIf(filter.HasBeneficiaryName, x => x.BeneficiaryName!.Contains(filter.BeneficiaryName!) || x.BeneficiaryNameBn!.Contains(filter.BeneficiaryName!));
                query = query.WhereIf(filter.HasFcvVcfName, x => x.ForestFcvVcf!.Name!.Contains(filter.FcvVcfName!));

                if (filter.GetPendingAlso == false)
                {
                    query = query.Where(x => x.BeneficiaryApproveStatus == BeneficiaryApproveStatus.Approved);
                }

                if (filter?.ForestCivilLocation is not null)
                {
                    // Forest Administration
                    query = query.WhereIf(filter.ForestCivilLocation.HasForestCircleId, x => x.ForestCircleId == filter.ForestCivilLocation.ForestCircleId);
                    query = query.WhereIf(filter.ForestCivilLocation.HasForestDivisionId, x => x.ForestDivisionId == filter.ForestCivilLocation.ForestDivisionId);
                    query = query.WhereIf(filter.ForestCivilLocation.HasForestRangeId, x => x.ForestRangeId == filter.ForestCivilLocation.ForestRangeId);
                    query = query.WhereIf(filter.ForestCivilLocation.HasForestBeatId, x => x.ForestBeatId == filter.ForestCivilLocation.ForestBeatId);
                    query = query.WhereIf(filter.ForestCivilLocation.HasForestFcvVcfId, x => x.ForestFcvVcfId == filter.ForestCivilLocation.ForestFcvVcfId);

                    // Civil Administration
                    query = query.WhereIf(filter.ForestCivilLocation.HasDivisionId, x => x.PresentDivisionId == filter.ForestCivilLocation.PresentDivisionId);
                    query = query.WhereIf(filter.ForestCivilLocation.HasDistrictId, x => x.PresentDistrictId == filter.ForestCivilLocation.PresentDistrictId);
                    query = query.WhereIf(filter.ForestCivilLocation.HasUpazillaId, x => x.PresentUpazillaId == filter.ForestCivilLocation.PresentUpazillaId);
                    query = query.WhereIf(filter.ForestCivilLocation.HasUnionId, x => x.PresentUnionNewId == filter.ForestCivilLocation.PresentUnionId);
                }

                if (filter?.ForestCivilLocation?.HasTake == true)
                {
                    query = query.Take(filter?.ForestCivilLocation?.Take ?? Defaults.Take);
                }

                var result = await query
                    .Include(x => x.ForestFcvVcf)
                    .Select(x =>
                        new SurveyEssentialVM()
                        {
                            Id = x.Id,

                            BeneficiaryName = x.BeneficiaryName,
                            BeneficiaryNameBn = x.BeneficiaryNameBn,
                            BeneficiaryNid = x.BeneficiaryNid,
                            BeneficiaryPhone = x.BeneficiaryPhone,
                            BeneficiaryPhoneBn = x.BeneficiaryPhoneBn,
                            BeneficiaryGender = x.BeneficiaryGender,
                            BeneficiaryGenderString = x.BeneficiaryGender.ToString(),
                            BeneficiaryEthnicityId = x.BeneficiaryEthnicityId,
                            BeneficiaryEthnicityTxt = x.BeneficiaryEthnicityTxt,
                            ForestFcvVcf = new ForestFcvVcfVM { Name = x.ForestFcvVcf.Name, NameBn = x.ForestFcvVcf.NameBn, Id = x.ForestFcvVcf.Id },
                            BeneficiaryAge = x.BeneficiaryAge,
                            BeneficiaryAgeBn = x.BeneficiaryAgeBn,
                            BeneficiaryFatherName = x.BeneficiaryFatherName,
                            BeneficiaryFatherNameBn = x.BeneficiaryFatherNameBn,
                            BeneficiaryMotherName = x.BeneficiaryMotherName,
                            BeneficiaryMotherNameBn = x.BeneficiaryMotherNameBn,
                            BeneficiarySpouseName = x.BeneficiarySpouseName,
                            BeneficiarySpouseNameBn = x.BeneficiarySpouseNameBn,
                            HeadOfHouseholdName = x.HeadOfHouseholdName,
                            HeadOfHouseholdNameBn = x.HeadOfHouseholdNameBn,
                            HeadOfHouseholdGender = x.HeadOfHouseholdGender,
                            PresentVillageName = x.PresentVillageName,
                            PresentVillageNameBn = x.PresentVillageNameBn,
                            PresentPostOfficeName = x.PresentPostOfficeName,
                            PresentPostOfficeNameBn = x.PresentPostOfficeNameBn,
                            PresentDivisionId = x.PresentDivisionId,
                            PresentDistrictId = x.PresentDistrictId,
                            PresentUpazillaId = x.PresentUpazillaId,
                            PresentUnion = x.PresentUnion,
                            IsPermanentSameAsPresent = x.IsPermanentSameAsPresent,
                            PermanentVillageName = x.PermanentVillageName,
                            PermanentVillageNameBn = x.PermanentVillageNameBn,
                            PermanentPostOfficeName = x.PermanentPostOfficeName,
                            PermanentPostOfficeNameBn = x.PermanentPostOfficeNameBn,
                            PermanentDivisionId = x.PermanentDivisionId,
                            PermanentDistrictId = x.PermanentDistrictId,
                            PermanentUpazillaId = x.PermanentUpazillaId,
                            PermanentUnion = x.PermanentUnion,
                            PermanentUnionBn = x.PermanentUnionBn,
                            BeneficiaryLatitude = x.BeneficiaryLatitude,
                            BeneficiaryLongitude = x.BeneficiaryLongitude,
                            BeneficiaryAltitude = x.BeneficiaryAltitude,
                            BeneficiaryPrecision = x.BeneficiaryPrecision,
                            BeneficiaryHouseFrontImage = x.BeneficiaryHouseFrontImage,
                            BeneficiaryHouseFrontImageURL = x.BeneficiaryHouseFrontImageURL,
                            BeneficiaryHouseType = x.BeneficiaryHouseType,
                            BeneficiaryHouseTypeString = x.BeneficiaryHouseType.GetEnumDisplayName(),
                            GrandTotalLivestockCost = x.GrandTotalLivestockCost,
                            GrandTotalAssetsCost = x.GrandTotalAssetsCost,
                            GrandTotalImmovableAnnualReturn = x.GrandTotalImmovableAnnualReturn,
                            GrandTotalEnergyUsesMonthly = x.GrandTotalEnergyUsesMonthly,
                            GrandTotalNetIncomeAgriculture = x.GrandTotalNetIncomeAgriculture,
                            GrandTotalLandArea = x.GrandTotalLandArea,
                            GrandTotalGrossMarginAgriculture = x.GrandTotalGrossMarginAgriculture,
                            BeneficiaryApproveStatus = x.BeneficiaryApproveStatus,
                            BeneficiaryApproveStatusString = x.BeneficiaryApproveStatus.ToString()
                        }
                    )
                    .ToListAsync();



                return (ExecutionState.Retrieved, new PaginationResutl<SurveyEssentialVM>
                {
                    aaData = result,
                    iTotalDisplayRecords = await queryTotal.CountAsync(),
                    iTotalRecords = await queryTotal.CountAsync(),
                }, "Data returned successfully.");



                // return (ExecutionState.Retrieved, result, "Data returned successfully.");
            }
            catch (Exception ex)
            {
                return (ExecutionState.Success, new PaginationResutl<SurveyEssentialVM>()!, "Unexpected error occurred.");
            }
        }

        public override async Task<(ExecutionState executionState, Survey entity, string message)> CreateAsync(Survey entity)
        {
            try
            {
                (ExecutionState executionState, Survey entity, string message) defaultResponse =
                    (ExecutionState.Success, null!, "Unexpected error occurred.");

                entity.GenerateBeneficiaryID();
                entity.BeneficiaryApproveStatus = Common.Enum.Beneficiary.BeneficiaryApproveStatus.Pending;

                #region Validation
                if (entity.ForestCircleId < 1)
                {
                    defaultResponse.message = "Forest circle is not valid.";
                    return defaultResponse;
                }
                if (entity.ForestDivisionId < 1)
                {
                    defaultResponse.message = "Forest division is not valid.";
                    return defaultResponse;
                }
                if (entity.ForestRangeId < 1)
                {
                    defaultResponse.message = "Forest range is not valid.";
                    return defaultResponse;
                }
                if (entity.ForestBeatId < 1)
                {
                    defaultResponse.message = "Forest beat is not valid.";
                    return defaultResponse;
                }
                if (entity.ForestFcvVcfId < 1)
                {
                    defaultResponse.message = "Forest FCV/VCF is not valid.";
                    return defaultResponse;
                }
                if (string.IsNullOrEmpty(entity.BeneficiaryHouseholdSerialNo))
                {
                    defaultResponse.message = "Invalid Household serial no.";
                    return defaultResponse;
                }
                if (entity.BeneficiaryHouseholdSerialNo.Length != 3)
                {
                    defaultResponse.message = "Household serial no must be 3 characters long.";
                    return defaultResponse;
                }
                if (entity.BeneficiaryHouseholdSerialNo.All(char.IsDigit) == false)
                {
                    defaultResponse.message = "Household serial no must contain only numbers from 0 to 9.";
                    return defaultResponse;
                }
                #endregion

                #region Asynchronous Validation
                var surveyContext = _readOnlyContext.Set<Survey>();

                var beneficiaryIdCount = await surveyContext.CountAsync(x => x.BeneficiaryId == entity.BeneficiaryId);
                if (beneficiaryIdCount > 0)
                {
                    defaultResponse.message = "Beneficiary Id already exists.";
                    return defaultResponse;
                }
                #endregion

                #region Transform entity && initialize property if necessary
                // Ignore permanent address if permanent address is same as present
                if (entity.IsPermanentSameAsPresent)
                {
                    entity.PermanentDistrictId = entity.PresentDistrictId;
                    entity.PermanentDivisionId = entity.PresentDivisionId;
                    entity.PermanentUpazillaId = entity.PresentUpazillaId;
                    entity.PermanentPostOfficeName = entity.PresentPostOfficeName;
                    entity.PermanentPostOfficeNameBn = entity.PresentPostOfficeNameBn;
                    entity.PermanentUnion = entity.PresentUnion;
                    entity.PermanentUnionNewId = entity.PresentUnionNewId;

                    //entity.PermanentUnionBn = entity.PresentUnionBn;

                    entity.PermanentVillageName = entity.PresentVillageName;
                    entity.PermanentVillageNameBn = entity.PresentVillageNameBn;
                }
                entity.SurveyDate = DateTime.Now;
                #endregion

                #region Calculation
                entity.CalculcateGrandTotals();
                #endregion

                return await base.CreateAsync(entity);
            }
            catch (Exception ex)
            {
                return (ExecutionState.Success, null!, "Unexpected error occurred.");
            }
        }

        public override async Task<(ExecutionState executionState, Survey entity, string message)> UpdateAsync(Survey entity)
        {
            (ExecutionState executionState, Survey entity, string message) defaultResponse =
                (ExecutionState.Success, null!, "Unexpected error occurred.");

            var doesExists = await _readOnlyContext.Set<Survey>().AnyAsync(x => x.Id == entity.Id);
            if (doesExists == false)
            {
                defaultResponse.message = "Survey item not found";
                return defaultResponse;
            }

            var currentData = await _readOnlyContext.Set<Survey>()
                .Where(x => x.Id == entity.Id)
                .Select(x => new
                {
                    x.GrandTotalLandOccupancy,
                    x.GrandTotalLivestockCost,
                    x.GrandTotalAssetsCost,
                    x.GrandTotalEnergyUsesMonthly,
                    x.GrandTotalImmovableAnnualReturn,
                    x.GrandTotalGrossMarginAgriculture,
                    x.GrandTotalAnnualPhysicalIncome,
                    x.GrandTotalWildResourceIncome,
                    x.GrandTotalOtherIncome,
                    x.GrandTotalBusinessIncome,
                    x.GrandTotalHouseholdExpenditure,
                    x.BeneficiaryApproveStatus
                })
                .FirstOrDefaultAsync();

            entity.GenerateBeneficiaryID();
            entity.BeneficiaryApproveStatus = currentData?.BeneficiaryApproveStatus ?? Common.Enum.Beneficiary.BeneficiaryApproveStatus.Pending;

            #region Validation
            if (entity.ForestCircleId < 1)
            {
                defaultResponse.message = "Forest circle is not valid.";
                return defaultResponse;
            }
            if (entity.ForestDivisionId < 1)
            {
                defaultResponse.message = "Forest division is not valid.";
                return defaultResponse;
            }
            if (entity.ForestRangeId < 1)
            {
                defaultResponse.message = "Forest range is not valid.";
                return defaultResponse;
            }
            if (entity.ForestBeatId < 1)
            {
                defaultResponse.message = "Forest beat is not valid.";
                return defaultResponse;
            }
            if (entity.ForestFcvVcfId < 1)
            {
                defaultResponse.message = "Forest FCV/VCF is not valid.";
                return defaultResponse;
            }
            if (string.IsNullOrEmpty(entity.BeneficiaryHouseholdSerialNo))
            {
                defaultResponse.message = "Invalid Household serial no.";
                return defaultResponse;
            }
            if (entity.BeneficiaryHouseholdSerialNo.Length != 3)
            {
                defaultResponse.message = "Household serial no must be 3 characters long.";
                return defaultResponse;
            }
            if (entity.BeneficiaryHouseholdSerialNo.All(char.IsDigit) == false)
            {
                defaultResponse.message = "Household serial no must contain only numbers from 0 to 9.";
                return defaultResponse;
            }
            #endregion

            #region Asynchronous Validation
            var surveyContext = _readOnlyContext.Set<Survey>();

            var beneficiaryIdCount = await surveyContext.CountAsync(x => x.BeneficiaryId == entity.BeneficiaryId && x.Id != entity.Id);
            if (beneficiaryIdCount > 0)
            {
                defaultResponse.message = "Beneficiary Id already exists.";
                return defaultResponse;
            }
            #endregion

            #region Transform entity && initialize property if necessary
            // Ignore permanent address if permanent address is same as present
            if (entity.IsPermanentSameAsPresent)
            {
                entity.PermanentDistrictId = entity.PresentDistrictId;
                entity.PermanentDivisionId = entity.PresentDivisionId;
                entity.PermanentUpazillaId = entity.PresentUpazillaId;
                entity.PermanentPostOfficeName = entity.PresentPostOfficeName;
                entity.PermanentPostOfficeNameBn = entity.PresentPostOfficeNameBn;
                entity.PermanentUnion = entity.PresentUnion;
                entity.PermanentUnionNewId = entity.PresentUnionNewId;

                //entity.PermanentUnionBn = entity.PresentUnionBn;

                entity.PermanentVillageName = entity.PresentVillageName;
                entity.PermanentVillageNameBn = entity.PresentVillageNameBn;
            }
            entity.SurveyDate = DateTime.Now;
            #endregion

            #region Calculation
            entity.CalculcateGrandTotals(
                    currentData?.GrandTotalLandOccupancy ?? 0,
                    currentData?.GrandTotalLivestockCost ?? 0,
                    currentData?.GrandTotalAssetsCost ?? 0,
                    currentData?.GrandTotalEnergyUsesMonthly ?? 0,
                    currentData?.GrandTotalImmovableAnnualReturn ?? 0,
                    currentData?.GrandTotalGrossMarginAgriculture ?? 0,
                    currentData?.GrandTotalAnnualPhysicalIncome ?? 0,
                    currentData?.GrandTotalWildResourceIncome ?? 0,
                    currentData?.GrandTotalOtherIncome ?? 0,
                    currentData?.GrandTotalBusinessIncome ?? 0,
                    currentData?.GrandTotalHouseholdExpenditure ?? 0);
            #endregion

            #region Child IsDeleted and IsActive
            if (entity.HouseholdMembers != null && entity.HouseholdMembers.Count > 0)
            {
                foreach (var item in entity.HouseholdMembers)
                {
                    item.IsActive = !entity.IsDeleted;
                    item.IsDeleted = entity.IsDeleted;
                }
            }
            if (entity.ExistingSkills != null && entity.ExistingSkills.Count > 0)
            {
                foreach (var item in entity.ExistingSkills)
                {
                    item.IsActive = !entity.IsDeleted;
                    item.IsDeleted = entity.IsDeleted;
                }
            }
            if (entity.AnnualHouseholdExpenditures != null && entity.AnnualHouseholdExpenditures.Count > 0)
            {
                foreach (var item in entity.AnnualHouseholdExpenditures)
                {
                    item.IsActive = !entity.IsDeleted;
                    item.IsDeleted = entity.IsDeleted;
                }
            }
            if (entity.FoodSecurityItems != null && entity.FoodSecurityItems.Count > 0)
            {
                foreach (var item in entity.FoodSecurityItems)
                {
                    item.IsActive = !entity.IsDeleted;
                    item.IsDeleted = entity.IsDeleted;
                }
            }
            if (entity.VulnerabilitySituations != null && entity.VulnerabilitySituations.Count > 0)
            {
                foreach (var item in entity.VulnerabilitySituations)
                {
                    item.IsActive = !entity.IsDeleted;
                    item.IsDeleted = entity.IsDeleted;
                }
            }
            if (entity.GrossMarginIncomeAndCostStatuses != null && entity.GrossMarginIncomeAndCostStatuses.Count > 0)
            {
                foreach (var item in entity.GrossMarginIncomeAndCostStatuses)
                {
                    item.IsActive = !entity.IsDeleted;
                    item.IsDeleted = entity.IsDeleted;
                }
            }
            if (entity.ManualPhysicalWorks != null && entity.ManualPhysicalWorks.Count > 0)
            {
                foreach (var item in entity.ManualPhysicalWorks)
                {
                    item.IsActive = !entity.IsDeleted;
                    item.IsDeleted = entity.IsDeleted;
                }
            }
            if (entity.NaturalResourcesIncomeAndCostStatuses != null && entity.NaturalResourcesIncomeAndCostStatuses.Count > 0)
            {
                foreach (var item in entity.NaturalResourcesIncomeAndCostStatuses)
                {
                    item.IsActive = !entity.IsDeleted;
                    item.IsDeleted = entity.IsDeleted;
                }
            }
            if (entity.OtherIncomeSources != null && entity.OtherIncomeSources.Count > 0)
            {
                foreach (var item in entity.OtherIncomeSources)
                {
                    item.IsActive = !entity.IsDeleted;
                    item.IsDeleted = entity.IsDeleted;
                }
            }
            if (entity.Businesses != null && entity.Businesses.Count > 0)
            {
                foreach (var item in entity.Businesses)
                {
                    item.IsActive = !entity.IsDeleted;
                    item.IsDeleted = entity.IsDeleted;
                }
            }
            if (entity.LandOccupancy != null && entity.LandOccupancy.Count > 0)
            {
                foreach (var item in entity.LandOccupancy)
                {
                    item.IsActive = !entity.IsDeleted;
                    item.IsDeleted = entity.IsDeleted;
                }
            }
            if (entity.LiveStocks != null && entity.LiveStocks.Count > 0)
            {
                foreach (var item in entity.LiveStocks)
                {
                    item.IsActive = !entity.IsDeleted;
                    item.IsDeleted = entity.IsDeleted;
                }
            }
            if (entity.Assets != null && entity.Assets.Count > 0)
            {
                foreach (var item in entity.Assets)
                {
                    item.IsActive = !entity.IsDeleted;
                    item.IsDeleted = entity.IsDeleted;
                }
            }
            if (entity.ImmovableAssets != null && entity.ImmovableAssets.Count > 0)
            {
                foreach (var item in entity.ImmovableAssets)
                {
                    item.IsActive = !entity.IsDeleted;
                    item.IsDeleted = entity.IsDeleted;
                }
            }
            if (entity.EnergyUses != null && entity.EnergyUses.Count > 0)
            {
                foreach (var item in entity.EnergyUses)
                {
                    item.IsActive = !entity.IsDeleted;
                    item.IsDeleted = entity.IsDeleted;
                }
            }
            #endregion

            #region Delete child
            try
            {

                using (var transaction = _readOnlyContext.Database.BeginTransaction())
                {
                    if (entity.SurveyDocuments?.Count > 0)
                    {
                        // Remove documents if newly added
                        var surveyDocuments = await _readOnlyContext.Set<SurveyDocument>().Where(x => x.SurveyId == entity.Id).ToListAsync();
                        foreach (var doc in surveyDocuments)
                        {
                            doc.IsActive = false;
                            doc.IsDeleted = true;
                        }
                        _writeOnlyCtx.Set<SurveyDocument>().UpdateRange(surveyDocuments);
                    }

                    if (entity.DeletedVulnerabilitySituations != null)
                    {
                        foreach (var item in entity.DeletedVulnerabilitySituations)
                        {
                            var data = await _readOnlyContext.Set<VulnerabilitySituation>().Where(x => x.Id == item).FirstOrDefaultAsync();

                            if (data != null)
                            {
                                data.IsActive = false;
                                data.IsDeleted = true;

                                _writeOnlyCtx.Set<VulnerabilitySituation>().Update(data);
                            }
                        }
                    }

                    if (entity.DeletedFoodSecurityItems != null)
                    {
                        foreach (var item in entity.DeletedFoodSecurityItems)
                        {
                            var data = await _readOnlyContext.Set<FoodSecurityItem>().Where(x => x.Id == item).FirstOrDefaultAsync();

                            if (data != null)
                            {
                                data.IsActive = false;
                                data.IsDeleted = true;

                                _writeOnlyCtx.Set<FoodSecurityItem>().Update(data);
                            }
                        }
                    }
                    if (entity.DeletedAnnualHouseholdExpenditures != null)
                    {
                        foreach (var item in entity.DeletedAnnualHouseholdExpenditures)
                        {
                            var data = await _readOnlyContext.Set<AnnualHouseholdExpenditure>().Where(x => x.Id == item).FirstOrDefaultAsync();

                            if (data != null)
                            {
                                data.IsActive = false;
                                data.IsDeleted = true;

                                _writeOnlyCtx.Set<AnnualHouseholdExpenditure>().Update(data);
                            }
                        }
                    }
                    if (entity.DeletedBusinesses != null)
                    {
                        foreach (var item in entity.DeletedBusinesses)
                        {
                            var data = await _readOnlyContext.Set<Common.Entity.Beneficiary.Business>().Where(x => x.Id == item).FirstOrDefaultAsync();

                            if (data != null)
                            {
                                data.IsActive = false;
                                data.IsDeleted = true;

                                _writeOnlyCtx.Set<Common.Entity.Beneficiary.Business>().Update(data);
                            }
                        }
                    }
                    if (entity.DeletedOtherIncomeSources != null)
                    {
                        foreach (var item in entity.DeletedOtherIncomeSources)
                        {
                            var data = await _readOnlyContext.Set<OtherIncomeSource>().Where(x => x.Id == item).FirstOrDefaultAsync();

                            if (data != null)
                            {
                                data.IsActive = false;
                                data.IsDeleted = true;

                                _writeOnlyCtx.Set<OtherIncomeSource>().Update(data);
                            }
                        }
                    }
                    if (entity.DeletedNaturalResourcesIncomeAndCostStatuses != null)
                    {
                        foreach (var item in entity.DeletedNaturalResourcesIncomeAndCostStatuses)
                        {
                            var data = await _readOnlyContext.Set<NaturalResourcesIncomeAndCostStatus>().Where(x => x.Id == item).FirstOrDefaultAsync();

                            if (data != null)
                            {
                                data.IsActive = false;
                                data.IsDeleted = true;

                                _writeOnlyCtx.Set<NaturalResourcesIncomeAndCostStatus>().Update(data);
                            }
                        }
                    }
                    if (entity.DeletedManualPhysicalWorks != null)
                    {
                        foreach (var item in entity.DeletedManualPhysicalWorks)
                        {
                            var data = await _readOnlyContext.Set<ManualPhysicalWork>().Where(x => x.Id == item).FirstOrDefaultAsync();

                            if (data != null)
                            {
                                data.IsActive = false;
                                data.IsDeleted = true;

                                _writeOnlyCtx.Set<ManualPhysicalWork>().Update(data);
                            }
                        }
                    }
                    if (entity.DeletedGrossMarginIncomeAndCostStatuses != null)
                    {
                        foreach (var item in entity.DeletedGrossMarginIncomeAndCostStatuses)
                        {
                            var data = await _readOnlyContext.Set<GrossMarginIncomeAndCostStatus>().Where(x => x.Id == item).FirstOrDefaultAsync();

                            if (data != null)
                            {
                                data.IsActive = false;
                                data.IsDeleted = true;

                                _writeOnlyCtx.Set<GrossMarginIncomeAndCostStatus>().Update(data);
                            }
                        }
                    }
                    if (entity.DeletedExistingSkills != null)
                    {
                        foreach (var item in entity.DeletedExistingSkills)
                        {
                            var data = await _readOnlyContext.Set<ExistingSkill>().Where(x => x.Id == item).FirstOrDefaultAsync();

                            if (data != null)
                            {
                                data.IsActive = false;
                                data.IsDeleted = true;

                                _writeOnlyCtx.Set<ExistingSkill>().Update(data);
                            }
                        }
                    }
                    if (entity.DeletedEnergyUses != null)
                    {
                        foreach (var item in entity.DeletedEnergyUses)
                        {
                            var data = await _readOnlyContext.Set<EnergyUse>().Where(x => x.Id == item).FirstOrDefaultAsync();

                            if (data != null)
                            {
                                data.IsActive = false;
                                data.IsDeleted = true;

                                _writeOnlyCtx.Set<EnergyUse>().Update(data);
                            }
                        }
                    }
                    if (entity.DeletedImmovableAssets != null)
                    {
                        foreach (var item in entity.DeletedImmovableAssets)
                        {
                            var data = await _readOnlyContext.Set<ImmovableAsset>().Where(x => x.Id == item).FirstOrDefaultAsync();

                            if (data != null)
                            {
                                data.IsActive = false;
                                data.IsDeleted = true;

                                _writeOnlyCtx.Set<ImmovableAsset>().Update(data);
                            }
                        }
                    }
                    if (entity.DeletedAssets != null)
                    {
                        foreach (var item in entity.DeletedAssets)
                        {
                            var data = await _readOnlyContext.Set<Asset>().Where(x => x.Id == item).FirstOrDefaultAsync();

                            if (data != null)
                            {
                                data.IsActive = false;
                                data.IsDeleted = true;

                                _writeOnlyCtx.Set<Asset>().Update(data);
                            }
                        }
                    }
                    if (entity.DeletedLiveStocks != null)
                    {
                        foreach (var item in entity.DeletedLiveStocks)
                        {
                            var data = await _readOnlyContext.Set<LiveStock>().Where(x => x.Id == item).FirstOrDefaultAsync();

                            if (data != null)
                            {
                                data.IsActive = false;
                                data.IsDeleted = true;

                                _writeOnlyCtx.Set<LiveStock>().Update(data);
                            }
                        }
                    }
                    if (entity.DeletedLandOccupancy != null)
                    {
                        foreach (var item in entity.DeletedLandOccupancy)
                        {
                            var data = await _readOnlyContext.Set<LandOccupancy>().Where(x => x.Id == item).FirstOrDefaultAsync();

                            if (data != null)
                            {
                                data.IsActive = false;
                                data.IsDeleted = true;

                                _writeOnlyCtx.Set<LandOccupancy>().Update(data);
                            }
                        }
                    }
                    if (entity.DeletedHouseholdMembers != null)
                    {
                        foreach (var item in entity.DeletedHouseholdMembers)
                        {
                            var data = await _readOnlyContext.Set<HouseholdMember>().Where(x => x.Id == item).FirstOrDefaultAsync();

                            if (data != null)
                            {
                                data.IsActive = false;
                                data.IsDeleted = true;

                                _writeOnlyCtx.Set<HouseholdMember>().Update(data);
                            }
                        }
                    }

                    await _writeOnlyCtx.SaveChangesAsync();
                    transaction.Commit();
                }
            }
            catch (Exception ex)
            {
                return defaultResponse;
            }
            #endregion

            #region Household Member many to many map
            if (entity.HouseholdMembers != null)
            {
                try
                {
                    using (var transaction = _unitOfWork.Begin())
                    {
                        foreach (var member in entity.HouseholdMembers)
                        {
                            // BFD Association
                            var result = await _unitOfWork.BFDAssociationHouseholdMembersMapRepo.List(new QueryOptions<BFDAssociationHouseholdMembersMap>
                            {
                                FilterExpression = e => e.HouseholdMemberId == member.Id,
                            });
                            var bfdMaps = result.entity != null ? result.entity.ToList() : new List<BFDAssociationHouseholdMembersMap>();

                            if (bfdMaps != null && member.BFDAssociationHouseholdMembers != null)
                            {
                                foreach (var bfdMap in bfdMaps)
                                {
                                    if (member.BFDAssociationHouseholdMembers
                                        .FindIndex(x => x.BFDAssociationId == bfdMap.BFDAssociationId && x.HouseholdMemberId == bfdMap.HouseholdMemberId) == -1)
                                    {
                                        var bfdToDelete = await _unitOfWork.GetAsync<BFDAssociationHouseholdMembersMap>(bfdMap.Id);
                                        if (bfdToDelete.entity != null)
                                        {
                                            bfdToDelete.entity.IsDeleted = true;
                                            bfdToDelete.entity.IsActive = false;

                                            await _unitOfWork.UpdateAsync(bfdToDelete.entity);
                                        }
                                    }
                                }

                                foreach (var uiBfd in member.BFDAssociationHouseholdMembers)
                                {
                                    var found = bfdMaps.Find(x => x.BFDAssociationId == uiBfd.BFDAssociationId && x.HouseholdMemberId == uiBfd.HouseholdMemberId);
                                    if (found != null)
                                    {
                                        uiBfd.Id = found.Id;
                                        uiBfd.IsActive = true;
                                        uiBfd.IsDeleted = false;
                                    }
                                }
                            }

                            // Disability
                            var result2 = await _unitOfWork.DisabilityTypeHouseholdMembersMapRepo.List(new QueryOptions<DisabilityTypeHouseholdMembersMap>
                            {
                                FilterExpression = e => e.HouseholdMemberId == member.Id,
                            });
                            var disabilityMaps = result2.entity != null ? result2.entity.ToList() : new List<DisabilityTypeHouseholdMembersMap>();

                            if (disabilityMaps != null && member.DisabilityTypeHouseholdMembers != null)
                            {
                                foreach (var map in disabilityMaps)
                                {
                                    if (member.DisabilityTypeHouseholdMembers
                                        .FindIndex(x => x.DisabilityTypeId == map.DisabilityTypeId && x.HouseholdMemberId == map.HouseholdMemberId) == -1)
                                    {
                                        var disabilityToDelete = await _unitOfWork.GetAsync<DisabilityTypeHouseholdMembersMap>(map.Id);
                                        if (disabilityToDelete.entity != null)
                                        {
                                            disabilityToDelete.entity.IsDeleted = true;
                                            disabilityToDelete.entity.IsActive = false;

                                            await _unitOfWork.UpdateAsync(disabilityToDelete.entity);
                                        }
                                    }
                                }

                                foreach (var ui in member.DisabilityTypeHouseholdMembers)
                                {
                                    var found = disabilityMaps.Find(x => x.DisabilityTypeId == ui.DisabilityTypeId && x.HouseholdMemberId == ui.HouseholdMemberId);
                                    if (found != null)
                                    {
                                        ui.Id = found.Id;
                                        ui.IsActive = true;
                                        ui.IsDeleted = false;
                                    }
                                }
                            }
                        }

                        await _unitOfWork.SaveAsync(transaction);
                        transaction.Commit();
                    }
                }
                catch (Exception ex)
                {
                    return defaultResponse;
                }
            }
            #endregion

            try
            {
                _writeOnlyCtx.Set<Survey>().Update(entity);
                await _writeOnlyCtx.SaveChangesAsync();
                return (ExecutionState.Updated, entity, "Updated successfully");
            }
            catch (Exception ex)
            {
                var innerException = ex.InnerException?.Message ?? string.Empty;
                return (ExecutionState.Failure, null!, string.IsNullOrEmpty(innerException) ? ex.Message : innerException);
            }
        }

        public async Task<(ExecutionState executionState, BeneficiaryVM entity, string message)> GetTotalBeneficiary(ForestCivilLocationFilter filter)
        {
            IQueryable<Survey> surveyQuery = _readOnlyContext.Set<Survey>();
            IQueryable<CommunityTrainingParticipentsMap> communityTrainingQuery = _readOnlyContext.Set<CommunityTrainingParticipentsMap>();
            IQueryable<AIGBasicInformation> aigQuery = _readOnlyContext.Set<AIGBasicInformation>();

            // Survey filter
            surveyQuery = surveyQuery.WhereIf(filter.HasForestCircleId, x => x.ForestCircleId == filter.ForestCircleId);
            surveyQuery = surveyQuery.WhereIf(filter.HasForestDivisionId, x => x.ForestDivisionId == filter.ForestDivisionId);
            surveyQuery = surveyQuery.WhereIf(filter.HasForestRangeId, x => x.ForestRangeId == filter.ForestRangeId);
            surveyQuery = surveyQuery.WhereIf(filter.HasForestBeatId, x => x.ForestBeatId == filter.ForestBeatId);
            surveyQuery = surveyQuery.WhereIf(filter.HasForestFcvVcfId, x => x.ForestFcvVcfId == filter.ForestFcvVcfId);

            surveyQuery = surveyQuery.WhereIf(filter.HasDistrictId, x => x.PresentDistrictId == filter.DistrictId);
            surveyQuery = surveyQuery.WhereIf(filter.HasDivisionId, x => x.PresentDivisionId == filter.DivisionId);
            surveyQuery = surveyQuery.WhereIf(filter.HasUpazillaId, x => x.PresentUpazillaId == filter.UpazillaId);
            surveyQuery = surveyQuery.WhereIf(filter.HasUnionId, x => x.PresentUnionNewId == filter.UnionId);

            var totalBeneficiary = await surveyQuery.CountAsync();
            var totalEthnicityBeneficiary = totalBeneficiary == 0 ? 0 : await surveyQuery.Where(x => x.BeneficiaryEthnicityId != null).CountAsync();
            var totalMale = totalBeneficiary == 0 ? 0 : await surveyQuery.Where(x => x.BeneficiaryGender == Gender.Male).CountAsync();
            var totalFemale = totalBeneficiary == 0 ? 0 : await surveyQuery.Where(x => x.BeneficiaryGender == Gender.Female).CountAsync();

            // Community training filter
            communityTrainingQuery = communityTrainingQuery.WhereIf(filter.HasForestCircleId, x => x.Survey!.ForestCircleId == filter.ForestCircleId);
            communityTrainingQuery = communityTrainingQuery.WhereIf(filter.HasForestDivisionId, x => x.Survey!.ForestDivisionId == filter.ForestDivisionId);
            communityTrainingQuery = communityTrainingQuery.WhereIf(filter.HasForestRangeId, x => x.Survey!.ForestRangeId == filter.ForestRangeId);
            communityTrainingQuery = communityTrainingQuery.WhereIf(filter.HasForestBeatId, x => x.Survey!.ForestBeatId == filter.ForestBeatId);
            communityTrainingQuery = communityTrainingQuery.WhereIf(filter.HasForestFcvVcfId, x => x.Survey!.ForestFcvVcfId == filter.ForestFcvVcfId);

            communityTrainingQuery = communityTrainingQuery.WhereIf(filter.HasDistrictId, x => x.Survey!.PresentDistrictId == filter.DistrictId);
            communityTrainingQuery = communityTrainingQuery.WhereIf(filter.HasDivisionId, x => x.Survey!.PresentDivisionId == filter.DivisionId);
            communityTrainingQuery = communityTrainingQuery.WhereIf(filter.HasUpazillaId, x => x.Survey!.PresentUpazillaId == filter.UpazillaId);
            communityTrainingQuery = communityTrainingQuery.WhereIf(filter.HasUnionId, x => x.Survey!.PresentUnionNewId == filter.UnionId);

            var totalGotTraining = await communityTrainingQuery.CountAsync();

            // AIG filter
            aigQuery = aigQuery.WhereIf(filter.HasForestCircleId, x => x.Survey!.ForestCircleId == filter.ForestCircleId);
            aigQuery = aigQuery.WhereIf(filter.HasForestDivisionId, x => x.Survey!.ForestDivisionId == filter.ForestDivisionId);
            aigQuery = aigQuery.WhereIf(filter.HasForestRangeId, x => x.Survey!.ForestRangeId == filter.ForestRangeId);
            aigQuery = aigQuery.WhereIf(filter.HasForestBeatId, x => x.Survey!.ForestBeatId == filter.ForestBeatId);
            aigQuery = aigQuery.WhereIf(filter.HasForestFcvVcfId, x => x.Survey!.ForestFcvVcfId == filter.ForestFcvVcfId);

            aigQuery = aigQuery.WhereIf(filter.HasDistrictId, x => x.Survey!.PresentDistrictId == filter.DistrictId);
            aigQuery = aigQuery.WhereIf(filter.HasDivisionId, x => x.Survey!.PresentDivisionId == filter.DivisionId);
            aigQuery = aigQuery.WhereIf(filter.HasUpazillaId, x => x.Survey!.PresentUpazillaId == filter.UpazillaId);
            aigQuery = aigQuery.WhereIf(filter.HasUnionId, x => x.Survey!.PresentUnionNewId == filter.UnionId);

            var totalGotLoan = totalBeneficiary == 0 ? 0 : await aigQuery
                .GroupBy(x => x.SurveyId)
                .Select(x => new
                {
                    ColumnName = x.Key,
                    Count = x.Count()
                })
                .CountAsync();

            var totalRegularWealth = totalBeneficiary == 0 ? 0 : await aigQuery
                .Where(x => x.BadLoanType == BadLoanType.Regular)
                .GroupBy(x => x.SurveyId)
                .Select(x => new
                {
                    ColumnName = x.Key,
                    Count = x.Count()
                })
                .CountAsync();

            var totalEvilWealth = totalBeneficiary == 0 ? 0 : await aigQuery
                .Where(x => x.BadLoanType == BadLoanType.EvilLoan)
                .GroupBy(x => x.SurveyId)
                .Select(x => new
                {
                    ColumnName = x.Key,
                    Count = x.Count()
                })
                .CountAsync();

            double totalMalePercentage = totalBeneficiary == 0 ? 0 : Math.Round(((double)totalMale / totalBeneficiary) * 100);
            double totalFemalePercentage = totalBeneficiary == 0 ? 0 : Math.Round(((double)totalFemale / totalBeneficiary) * 100);
            double totalEthnicityPercentage = totalBeneficiary == 0 ? 0 : Math.Round((double)totalEthnicityBeneficiary / totalBeneficiary * 100, 0);
            double totalGotTrainingPercentage = totalBeneficiary == 0 ? 0 : Math.Round(((double)totalGotTraining / totalBeneficiary) * 100, 1);

            double totalGotLoanPercentage = totalBeneficiary == 0 ? 0 : Math.Round(((double)totalGotLoan / totalBeneficiary) * 100, 2);
            double totalRegularWealthPercentage = totalBeneficiary == 0 ? 0 : Math.Round(((double)totalRegularWealth / totalGotLoan) * 100, 1);
            double totalEvilWealthPercentage = totalBeneficiary == 0 ? 0 : Math.Round(((double)totalEvilWealth / totalGotLoan) * 100, 1);

            var beneficiaryVM = new BeneficiaryVM()
            {
                TotalBeneficiary = double.IsNaN(totalBeneficiary) ? 0 : totalBeneficiary,
                TotalEthnicityInPercentage = double.IsNaN(totalEthnicityPercentage) ? 0 : totalEthnicityPercentage,

                TotalMale = double.IsNaN(totalMale) ? 0 : totalMale,
                TotalMalePercentage = double.IsNaN(totalMalePercentage) ? 0 : totalMalePercentage,
                TotalFemale = double.IsNaN(totalFemale) ? 0 : totalFemale,
                TotalFemalePercentage = double.IsNaN(totalFemalePercentage) ? 0 : totalFemalePercentage,

                TotalGotTraining = double.IsNaN(totalGotTraining) ? 0 : totalGotTraining,
                TotalGotTrainingPercentage = double.IsNaN(totalGotTrainingPercentage) ? 0 : totalGotTrainingPercentage,

                TotalGotLoan = double.IsNaN(totalGotLoan) ? 0 : totalGotLoan,
                TotalGotLoanPercentage = double.IsNaN(totalGotLoanPercentage) ? 0 : totalGotLoanPercentage,

                TotalLoanRepayment = double.IsNaN(totalRegularWealth) ? 0 : totalRegularWealth,
                TotalLoanRepaymentPercentage = double.IsNaN(totalRegularWealthPercentage) ? 0 : totalRegularWealthPercentage,

                TotalEvilWealth = double.IsNaN(totalEvilWealth) ? 0 : totalEvilWealth,
                TotalEvilWealthPercentage = double.IsNaN(totalEvilWealthPercentage) ? 0 : totalEvilWealthPercentage,
            };

            return (executionState: ExecutionState.Success, entity: beneficiaryVM, message: "Success");
        }

        public Task<(ExecutionState executionState, SocioEconomicStatusModel entity, string message)> LoadSocioEconomicStatus(long surveyId)
        {
            throw new NotImplementedException();
        }

        public async Task<(ExecutionState executionState, SurveyChilds entity, string message)> LoadAllChilds(long surveyId)
        {
            var result = new SurveyChilds();

            result.HouseholdMembers = await _readOnlyContext.Set<HouseholdMember>()
                .Where(x => x.SurveyId == surveyId)
                .Include(x => x.RelationWithHeadHouseHoldType)
                .Include(x => x.MainOccupation)
                .Include(x => x.SecondaryOccupation)
                .Include(x => x.SafetyNetType)
                .Include(x => x.BFDAssociationHouseholdMembers!).ThenInclude(x => x.BFDAssociation!)
                .Include(x => x.DisabilityTypeHouseholdMembers!).ThenInclude(x => x.DisabilityType!)
                .ToListAsync();

            result.LandOccupancies = await _readOnlyContext.Set<LandOccupancy>()
                .Where(x => x.SurveyId == surveyId)
                .ToListAsync();

            result.LiveStocks = await _readOnlyContext.Set<LiveStock>()
                .Where(x => x.SurveyId == surveyId)
                .Include(x => x.LiveStockType)
                .ToListAsync();

            result.Assets = await _readOnlyContext.Set<Asset>()
                .Where(x => x.SurveyId == surveyId)
                .Include(x => x.AssetType)
                .ToListAsync();

            result.ImmovableAssets = await _readOnlyContext.Set<ImmovableAsset>()
                .Where(x => x.SurveyId == surveyId)
                .Include(x => x.ImmovableAssetType)
                .ToListAsync();

            result.EnergyUses = await _readOnlyContext.Set<EnergyUse>()
                .Where(x => x.SurveyId == surveyId)
                .Include(x => x.EnergyType)
                .ToListAsync();

            result.ExistingSkills = await _readOnlyContext.Set<ExistingSkill>()
                .Where(x => x.SurveyId == surveyId)
                .ToListAsync();

            result.GrossMarginIncomeAndCosts = await _readOnlyContext.Set<GrossMarginIncomeAndCostStatus>()
                .Where(x => x.SurveyId == surveyId)
                .ToListAsync();

            result.ManualPhysicalWorks = await _readOnlyContext.Set<ManualPhysicalWork>()
                .Where(x => x.SurveyId == surveyId)
                .Include(x => x.ManualIncomeSourceType)
                .ToListAsync();

            result.NaturalResourcesIncomeAndCosts = await _readOnlyContext.Set<NaturalResourcesIncomeAndCostStatus>()
                .Where(x => x.SurveyId == surveyId)
                .Include(x => x.NaturalIncomeSourceType)
                .ToListAsync();

            result.OtherIncomeSources = await _readOnlyContext.Set<OtherIncomeSource>()
                .Where(x => x.SurveyId == surveyId)
                .Include(x => x.OtherIncomeSourceType)
                .ToListAsync();

            result.Businesses = await _readOnlyContext.Set<Common.Entity.Beneficiary.Business>()
                .Where(x => x.SurveyId == surveyId)
                .Include(x => x.BusinessIncomeSourceType)
                .ToListAsync();

            result.AnnualHouseholdExpenditures = await _readOnlyContext.Set<AnnualHouseholdExpenditure>()
                .Where(x => x.SurveyId == surveyId)
                .Include(x => x.ExpenditureType)
                .ToListAsync();

            result.FoodSecurityItems = await _readOnlyContext.Set<FoodSecurityItem>()
                .Where(x => x.SurveyId == surveyId)
                .Include(x => x.FoodItem)
                .ToListAsync();

            result.VulnerabilitySituations = await _readOnlyContext.Set<VulnerabilitySituation>()
                .Where(x => x.SurveyId == surveyId)
                .Include(x => x.VulnerabilitySituationType)
                .ToListAsync();

            return (executionState: ExecutionState.Success, entity: result, message: "Successfully retrieved lists");
        }

        public async Task<(ExecutionState executionState, Survey? entity, string message)> GetByIdWithChilds(long surveyId)
        {
            var survey = await GetDetailsAsync(surveyId);
            var childs = await LoadAllChilds(surveyId);

            if (survey.entity is null) return (ExecutionState.Success, null, "Not data found");
            if (childs.entity is not null)
            {
                var surveyEntity = survey.entity;
                var child = childs.entity;

                surveyEntity.HouseholdMembers = child.HouseholdMembers;
                surveyEntity.HouseholdMembers = child.HouseholdMembers;
                surveyEntity.LandOccupancy = child.LandOccupancies;
                surveyEntity.LiveStocks = child.LiveStocks;
                surveyEntity.Assets = child.Assets;
                surveyEntity.ImmovableAssets = child.ImmovableAssets;
                surveyEntity.EnergyUses = child.EnergyUses;
                surveyEntity.ExistingSkills = child.ExistingSkills;
                surveyEntity.GrossMarginIncomeAndCostStatuses = child.GrossMarginIncomeAndCosts;
                surveyEntity.ManualPhysicalWorks = child.ManualPhysicalWorks;
                surveyEntity.NaturalResourcesIncomeAndCostStatuses = child.NaturalResourcesIncomeAndCosts;
                surveyEntity.OtherIncomeSources = child.OtherIncomeSources;
                surveyEntity.Businesses = child.Businesses;
                surveyEntity.AnnualHouseholdExpenditures = child.AnnualHouseholdExpenditures;
                surveyEntity.FoodSecurityItems = child.FoodSecurityItems;
                surveyEntity.VulnerabilitySituations = child.VulnerabilitySituations;

                return (ExecutionState.Success, surveyEntity, "Data Retrieved successfully");
            }

            return (ExecutionState.Success, survey.entity, "Data Retrieved successfully");
        }

        public async Task<(ExecutionState executionState, IList<SurveyEssentialVM> entity, string message)> ListNotHasAccountIncluding(ForestCivilLocationFilter filter, long? surveyId)
        {
            try
            {
                var users = await _readOnlyContext.Set<User>()
                    .Where(x => x.SurveyId > 0)
                    .FilterUser(filter)
                    .Select(x => x.SurveyId)
                    .ToListAsync();

                var surveys = await _readOnlyContext.Set<Survey>()
                    //.Where(x => x.Id == surveyId)
                    .Where(x => x.Id == surveyId || users.Contains(x.Id) == false)
                    .FilterSurvey(filter)
                    .Select(x => new SurveyEssentialVM(x))
                    .ToListAsync();

                return (ExecutionState.Retrieved, surveys, "Data returned successfully");
            }
            catch (Exception)
            {
                return (ExecutionState.Success, new List<SurveyEssentialVM>(), "Unexpected error occurred.");
            }
        }

        public async Task<(ExecutionState executionState, SurveyDashboard entity, string message)> BeneficiaryDashboardData(long? surveyId)
        {
            var result = new SurveyDashboard();

            try
            {
                // survey
                var survey = await _readOnlyContext.Set<Survey>()
                    .Where(x => x.Id == surveyId)
                    .Select(x => new { x.BeneficiaryName, x.BeneficiaryPhone, x.BeneficiaryNid, x.BeneficiaryGender })
                    .FirstOrDefaultAsync();
                if (survey is null)
                    return (ExecutionState.Success, result, "Survey not found");

                result.SurveyId = surveyId ?? 0;
                result.BeneficiaryName = survey?.BeneficiaryName;
                result.NidNo = survey?.BeneficiaryNid;
                result.Gender = survey?.BeneficiaryGender ?? Gender.Male;

                // AIG
                var aigLoan = await _readOnlyContext.Set<AIGBasicInformation>()
                    .Where(x => x.SurveyId == surveyId)
                    .Include(x => x.RepaymentLDFs)
                    .ToListAsync();

                var totalLoan = 0d;
                var totalAigRepayment = 0d;
                foreach (var aig in aigLoan)
                {
                    totalLoan += aig.TotalAllocatedLoanAmount;
                    totalAigRepayment += aig.RepaymentLDFs?
                        .Where(x => x.IsPaymentCompleted)
                        .Sum(x => x.FirstSixtyPercentRepaymentAmount) ?? 0
                        + aig.RepaymentLDFs?
                            .Where(x => x.IsPaymentCompleted)
                            .Sum(x => x.SecondFortyPercentRepaymentAmount) ?? 0;
                }
                result.AIGBasicInformations = aigLoan;
                result.TotalAIGLoanTaken = totalLoan;
                result.TotalAIGLoanRepayment = totalAigRepayment;

                // savings
                var savings = await _readOnlyContext.Set<SavingsAccount>()
                    .Where(x => x.SurveyId == surveyId)
                    .Include(x => x.SavingsAmountInformations)
                    .ToListAsync();

                // Meeting participations
                var meetings = await _readOnlyContext.Set<MeetingParticipantsMap>()
                    .Where(x => x.SurveyId == surveyId)
                    .GroupBy(x => x.MeetingId)
                    .Select(x => new
                    {
                        ColumnName = x.Key,
                        Count = x.Count()
                    })
                    .CountAsync();
                result.TotalMeetingParticipations = meetings;

                // Community training
                var communityTrainings = await _readOnlyContext.Set<CommunityTrainingParticipentsMap>()
                    .Where(x => x.SurveyId == surveyId)
                    .GroupBy(x => x.CommunityTrainingId)
                    .Select(x => new
                    {
                        ColumnName = x.Key,
                        Count = x.Count()
                    })
                    .CountAsync();
                result.TotalTrainingParticipations = communityTrainings;

                return (ExecutionState.Retrieved, result, "Data returned successfully");
            }
            catch (Exception)
            {
                return (ExecutionState.Success, result, "Unexpected error occurred.");
            }
        }

        public async Task<(ExecutionState executionState, bool entity, string message)> ApproveStatus(long surveyId, long approvedByUserId)
        {
            try
            {
                var rowsEffected = await _writeOnlyCtx.Set<Survey>()
                    .Where(x => x.Id == surveyId)
                    .ExecuteUpdateAsync(x => x
                        .SetProperty(y => y.BeneficiaryApproveStatus, BeneficiaryApproveStatus.Approved)
                        .SetProperty(y => y.BeneficiaryApproveStatusById, approvedByUserId));

                if (rowsEffected > 0)
                    return (ExecutionState.Updated, true, "Successfully set approve status");
                return (ExecutionState.Success, false, "Unable to set status");
            }
            catch (Exception)
            {
                return (ExecutionState.Success, false, "Unexpected error occurred.");
            }
        }

        public async Task<(ExecutionState executionState, bool entity, string message)> Deactivate(long surveyId, long deactivatedBy)
        {
            try
            {
                var rowsEffected = await _writeOnlyCtx.Set<Survey>()
                    .Where(x => x.Id == surveyId)
                    .ExecuteUpdateAsync(x => x
                        .SetProperty(y => y.IsActive, false)
                        .SetProperty(y => y.ModifiedBy, deactivatedBy)
                        .SetProperty(y => y.UpdatedAt, DateTime.Now));

                if (rowsEffected > 0)
                    return (ExecutionState.Updated, true, "Successfully set deactivate status");
                return (ExecutionState.Success, false, "Unable to set status");
            }
            catch (Exception)
            {
                return (ExecutionState.Success, false, "Unexpected error occurred.");
            }
        }

        public async Task<(ExecutionState executionState, bool entity, string message)> Activate(long surveyId, long activatedBy)
        {
            try
            {
                var rowsEffected = await _writeOnlyCtx.Set<Survey>()
                    .Where(x => x.Id == surveyId)
                    .ExecuteUpdateAsync(x => x
                        .SetProperty(y => y.IsActive, true)
                        .SetProperty(y => y.ModifiedBy, activatedBy)
                        .SetProperty(y => y.UpdatedAt, DateTime.Now));

                if (rowsEffected > 0)
                    return (ExecutionState.Updated, true, "Successfully set deactivate status");
                return (ExecutionState.Success, false, "Unable to set status");
            }
            catch (Exception)
            {
                return (ExecutionState.Success, false, "Unexpected error occurred.");
            }
        }

        public async Task<(ExecutionState executionState, bool entity, string message)> RejectStatus(long surveyId, long rejectedByUserId)
        {
            try
            {
                var rowsEffected = await _writeOnlyCtx.Set<Survey>()
                    .Where(x => x.Id == surveyId)
                    .ExecuteUpdateAsync(x => x
                        .SetProperty(y => y.BeneficiaryApproveStatus, BeneficiaryApproveStatus.Rejected)
                        .SetProperty(y => y.BeneficiaryApproveStatusById, rejectedByUserId));

                if (rowsEffected > 0)
                    return (ExecutionState.Updated, true, "Successfully set reject status");
                return (ExecutionState.Success, false, "Unable to set status");
            }
            catch (Exception)
            {
                return (ExecutionState.Success, false, "Unexpected error occurred.");
            }
        }




        public async Task<(ExecutionState executionState, bool entity, string message)> PendingStatus(long surveyId, long pendingByUserId)
        {
            try
            {
                var rowsEffected = await _writeOnlyCtx.Set<Survey>()
                    .Where(x => x.Id == surveyId)
                    .ExecuteUpdateAsync(x => x
                        .SetProperty(y => y.BeneficiaryApproveStatus, BeneficiaryApproveStatus.Pending)
                        .SetProperty(y => y.BeneficiaryApproveStatusById, pendingByUserId));

                if (rowsEffected > 0)
                    return (ExecutionState.Updated, true, "Successfully set pending status");
                return (ExecutionState.Success, false, "Unable to set status");
            }
            catch (Exception)
            {
                return (ExecutionState.Success, false, "Unexpected error occurred.");
            }
        }

        public async Task<(ExecutionState executionState, SurveyDropdownLocation entity, string message)> DropdownLocation()
        {
            var result = new SurveyDropdownLocation();

            result.ForestLocations = await _readOnlyContext.Set<ForestCircle>()
                .Include(x => x.ForestDivisions!)
                .ThenInclude(x => x.ForestRanges!)
                .ThenInclude(x => x.ForestBeats!)
                .ThenInclude(x => x.ForestFcvVcfs!)
                .Select(fc => new ForestCircleDropdown
                {
                    Id = fc.Id,
                    Name = fc.Name,
                    ForestDivisions = fc.ForestDivisions!.Select(fd => new ForestDivisionDropdown
                    {
                        Id = fd.Id,
                        Name = fd.Name,
                        ForestCircleId = fd.ForestCircleId,
                        ForestRanges = fd.ForestRanges!.Select(fr => new ForestRangeDropdown
                        {
                            Id = fr.Id,
                            Name = fr.Name,
                            ForestDivisionId = fr.ForestDivisionId,
                            ForestBeats = fr.ForestBeats!.Select(fb => new ForestBeatDropdown
                            {
                                Id = fb.Id,
                                Name = fb.Name,
                                ForestRangeId = fb.ForestRangeId,
                                ForestForestFcvVcfs = fb.ForestFcvVcfs!.Select(fcv => new ForestFcvVcfDropdown
                                {
                                    Id = fcv.Id,
                                    Name = fcv.Name,
                                    ForestBeatId = fcv.ForestBeatId
                                })
                            })
                        })
                    })
                })
                .ToListAsync();

            result.CivilLocations = await _readOnlyContext.Set<Division>()
                .Include(x => x.Districts!)
                .ThenInclude(x => x.Upazillas!)
                .ThenInclude(x => x.Unions!)
                .Select(x => new DivisionDropdown
                {
                    Id = x.Id,
                    Name = x.Name,
                    Districts = x.Districts!.Select(y => new DistrictDropdown
                    {
                        Id = y.Id,
                        Name = y.Name,
                        DivisionId = y.DivisionId,
                        Upazillas = y.Upazillas!.Select(z => new UpazillaDropdown
                        {
                            Id = z.Id,
                            Name = z.Name,
                            DistrictId = z.DistrictId,
                            Unions = z.Unions!.Select(a => new UnionDropdown
                            {
                                Id = a.Id,
                                Name = a.Name,
                                UpazillaId = a.UpazillaId
                            })
                        })
                    })
                })
                .ToListAsync();

            return (ExecutionState.Retrieved, result, "Retrieved successfully");
        }

        public async Task<(ExecutionState executionState, SurveyDropdownOthers entity, string message)> DropdownOthers()
        {
            var result = new SurveyDropdownOthers();

            result.Ngo = await _readOnlyContext.Set<Ngo>().Select(x => new DropdownLongVM { Id = x.Id, Name = x.Name }).ToListAsync();
            result.Gender = EnumHelper.GetEnumDropdowns<Gender>();
            result.Ethnicity = await _readOnlyContext.Set<Ethnicity>().Select(x => new DropdownLongVM { Id = x.Id, Name = x.Name }).ToListAsync();
            result.RelationWithHeadHouseHoldType = await _readOnlyContext.Set<RelationWithHeadHouseHoldType>().Select(x => new DropdownLongVM { Id = x.Id, Name = x.Name }).ToListAsync();
            result.MaritalStatus = EnumHelper.GetEnumDropdowns<MaritalStatus>();
            result.EducationLevel = EnumHelper.GetEnumDropdowns<EducationLevel>();
            result.Occupation = await _readOnlyContext.Set<Occupation>().Select(x => new DropdownLongVM { Id = x.Id, Name = x.Name }).ToListAsync();
            result.BFDAssociation = await _readOnlyContext.Set<BFDAssociation>().Select(x => new DropdownLongVM { Id = x.Id, Name = x.Name }).ToListAsync();
            result.DisabilityType = await _readOnlyContext.Set<DisabilityType>().Select(x => new DropdownLongVM { Id = x.Id, Name = x.Name }).ToListAsync();
            result.SafetyNet = await _readOnlyContext.Set<SafetyNet>().Select(x => new DropdownLongVM { Id = x.Id, Name = x.Name }).ToListAsync();
            result.LandClassification = EnumHelper.GetEnumDropdowns<LandClassification>();
            result.BeneficiaryHouseType = EnumHelper.GetEnumDropdowns<HouseType>();
            result.LiveStockType = await _readOnlyContext.Set<LiveStockType>().Select(x => new DropdownLongVM { Id = x.Id, Name = x.Name }).ToListAsync();
            result.AssetType = await _readOnlyContext.Set<AssetType>().Select(x => new DropdownLongVM { Id = x.Id, Name = x.Name }).ToListAsync();
            result.ImmovableAssetType = await _readOnlyContext.Set<ImmovableAssetType>().Select(x => new DropdownLongVM { Id = x.Id, Name = x.Name }).ToListAsync();
            result.EnergyType = await _readOnlyContext.Set<EnergyType>().Select(x => new DropdownLongVM { Id = x.Id, Name = x.Name }).ToListAsync();
            result.DrinkingWaterResource = EnumHelper.GetEnumDropdowns<DrinkingWaterResource>();
            result.EducationalInstituteAccessibility = EnumHelper.GetEnumDropdowns<EducationalInstituteAccessibility>();
            result.SanitationFacilities = EnumHelper.GetEnumDropdowns<SanitationFacilities>();
            result.SkillLevel = EnumHelper.GetEnumDropdowns<SkillLevel>();
            result.SatisfactionLevel = EnumHelper.GetEnumDropdowns<SatisfactionLevel>();
            result.ForestDependency = EnumHelper.GetEnumDropdowns<ForestDependency>();
            result.GenderMF = EnumHelper.GetEnumDropdowns<GenderMf>();
            result.ManualIncomeSourceType = await _readOnlyContext.Set<ManualIncomeSourceType>().Select(x => new DropdownLongVM { Id = x.Id, Name = x.Name }).ToListAsync();
            result.NaturalIncomeSourceType = await _readOnlyContext.Set<NaturalIncomeSourceType>().Select(x => new DropdownLongVM { Id = x.Id, Name = x.Name }).ToListAsync();
            result.OtherIncomeSourceType = await _readOnlyContext.Set<OtherIncomeSourceType>().Select(x => new DropdownLongVM { Id = x.Id, Name = x.Name }).ToListAsync();
            result.BusinessIncomeSourceType = await _readOnlyContext.Set<BusinessIncomeSourceType>().Select(x => new DropdownLongVM { Id = x.Id, Name = x.Name }).ToListAsync();
            result.ExpenditureType = await _readOnlyContext.Set<ExpenditureType>().Select(x => new DropdownLongVM { Id = x.Id, Name = x.Name }).ToListAsync();
            result.FoodCondition = EnumHelper.GetEnumDropdowns<FoodCondition>();
            result.FoodyPersonInFoodCrisis = EnumHelper.GetEnumDropdowns<FamilyMemberType>();
            result.FoodItem = await _readOnlyContext.Set<FoodItem>().Select(x => new DropdownLongVM { Id = x.Id, Name = x.Name }).ToListAsync();
            result.VulnerabilitySituationType = await _readOnlyContext.Set<VulnerabilitySituationType>().Select(x => new DropdownLongVM { Id = x.Id, Name = x.Name }).ToListAsync();

            return (ExecutionState.Retrieved, result, "Retrieved successfully");
        }

        public async Task<(ExecutionState executionState, bool entity, string message)> UploadFiles(
            long surveyId,
            string profileUrl,
            List<SurveyDocument> documents,
            string beneficiaryHouseFrontImageUrl,
            string beneficiaryNidFrontImageUrl,
            string beneficiaryNidBackImageUrl,
            string notesImageUrl)
        {
            try
            {
                var current = await _writeOnlyCtx.Set<Survey>()
                    .Where(x => x.Id == surveyId)
                    .Select(x => new
                    {
                        x.BeneficiaryProfileURL,
                        x.BeneficiaryHouseFrontImageURL,
                        x.BeneficiaryNIDFrontURL,
                        x.BeneficiaryNIDBackURL,
                        x.NotesImageUrl
                    })
                    .FirstOrDefaultAsync();
                var currentProfileUrl = current?.BeneficiaryProfileURL ?? string.Empty;
                currentProfileUrl = string.IsNullOrEmpty(profileUrl) ? currentProfileUrl : profileUrl;

                var currentBeneficiaryHouseFrontImageURL = current?.BeneficiaryHouseFrontImageURL ?? string.Empty;
                currentBeneficiaryHouseFrontImageURL = string.IsNullOrEmpty(beneficiaryHouseFrontImageUrl) ? currentBeneficiaryHouseFrontImageURL : beneficiaryHouseFrontImageUrl;

                var currentBeneficiaryNidFrontImageURL = current?.BeneficiaryNIDFrontURL ?? string.Empty;
                currentBeneficiaryNidFrontImageURL = string.IsNullOrEmpty(beneficiaryNidFrontImageUrl) ? currentBeneficiaryNidFrontImageURL : beneficiaryNidFrontImageUrl;

                var currentBeneficiaryNidBackImageURL = current?.BeneficiaryNIDBackURL ?? string.Empty;
                currentBeneficiaryNidBackImageURL = string.IsNullOrEmpty(beneficiaryNidBackImageUrl) ? currentBeneficiaryNidBackImageURL : beneficiaryNidBackImageUrl;

                var currentNotesImageUrl = current?.NotesImageUrl ?? string.Empty;
                currentNotesImageUrl = string.IsNullOrEmpty(notesImageUrl) ? currentNotesImageUrl : notesImageUrl;

                var rowsEffected = await _writeOnlyCtx.Set<Survey>()
                    .Where(x => x.Id == surveyId)
                    .ExecuteUpdateAsync(x =>
                        x
                        .SetProperty(y => y.BeneficiaryProfileURL, currentProfileUrl)
                        .SetProperty(y => y.BeneficiaryHouseFrontImageURL, currentBeneficiaryHouseFrontImageURL)
                        .SetProperty(y => y.BeneficiaryNIDFrontURL, currentBeneficiaryNidFrontImageURL)
                        .SetProperty(y => y.BeneficiaryNIDBackURL, currentBeneficiaryNidBackImageURL)
                        .SetProperty(y => y.NotesImageUrl, currentNotesImageUrl));
                await _writeOnlyCtx.Set<SurveyDocument>()
                    .AddRangeAsync(documents);
                await _writeOnlyCtx.SaveChangesAsync();

                var isSaved = rowsEffected > 0;

                return (isSaved ? ExecutionState.Success : ExecutionState.Failure, isSaved, isSaved ? "Saved successfully" : "Failed to save");
            }
            catch (Exception ex)
            {
                return (ExecutionState.Success, false, "Unexpected error occurred");
            }
        }
    }
}
