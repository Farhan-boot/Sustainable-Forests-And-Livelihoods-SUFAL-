using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Business.BaseBusinesses;
using PTSL.GENERIC.Business.Businesses.Interface.Beneficiary;
using PTSL.GENERIC.Common.Entity;
using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Helper;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model.EntityViewModels.Beneficiary;
using PTSL.GENERIC.DAL.UnitOfWork;
using System.Diagnostics.Metrics;
using PTSL.GENERIC.Common.Model.CustomModel;
using PTSL.GENERIC.Common.Model.EntityViewModels.DashBoard;
using PTSL.GENERIC.Common.Model.EntityViewModels;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace PTSL.GENERIC.Business.Businesses.Implementation.Beneficiary
{
    public class CipBusiness : BaseBusiness<Cip>, ICipBusiness
    {
        private readonly GENERICReadOnlyCtx _readOnlyCtx;

        public CipBusiness(GENERICUnitOfWork unitOfWork, GENERICReadOnlyCtx readOnlyCtx)
            : base(unitOfWork)
        {
            _readOnlyCtx = readOnlyCtx;
        }

        public override async Task<(ExecutionState executionState, Cip entity, string message)> GetAsync(long id)
        {
            var result = await _readOnlyCtx.Set<Cip>()
                .Where(x => x.Id == id)
                .Include(x => x.ApprovalLogForCfms!)
                .ThenInclude(x => x.Sender!)
                .Include(x => x.ApprovalLogForCfms!)
                .ThenInclude(x => x.Receiver!)

                .Include(x => x.ForestCircle!)
                .Include(x => x.ForestDivision!)
                .Include(x => x.ForestRange!)
                .Include(x => x.ForestBeat!)
                .Include(x => x.ForestFcvVcf!)
                .Include(x => x.District!)
                .Include(x => x.Division!)
                .Include(x => x.Upazilla!)
                .Include(x => x.Union!)
                .Include(x => x.Ethnicity!)
                .Include(x => x.CipFiles!)
                .Include(x => x.TypeOfHouseNew!)
                .AsSplitQuery()
                .FirstOrDefaultAsync();

            if (result is null)
            {
                return (ExecutionState.Failure, null!, "Not found");
            }

            return (ExecutionState.Retrieved, result, "Not found");
        }

        public async Task<(ExecutionState executionState, PaginationResutl<Cip> entity, string message)> ListByFilter(CipFilterVM filter)
        {
            try
            {


                if (filter.sSearch != null)
                {
                    IQueryable<Cip> queryTotalSearch = _readOnlyCtx.Set<Cip>()
                   .OrderByDescending(x => x.Id);
                    IQueryable<Cip> querySearch = _readOnlyCtx.Set<Cip>()
                                     .OrderByDescending(x => x.Id);

                    querySearch = querySearch.Where(x => x.BeneficiaryName.Contains(filter.sSearch) 
                    || x.NID.Contains(filter.sSearch)
                    || x.MobileNumber.Contains(filter.sSearch)
                    );
                    var resultSearch = await querySearch.ToListAsync();
                    return (ExecutionState.Retrieved, new PaginationResutl<Cip>
                    {
                        aaData = resultSearch,
                        iTotalDisplayRecords = await queryTotalSearch.CountAsync(),
                        iTotalRecords = await queryTotalSearch.CountAsync(),
                    }, "Data returned successfully.");
                }






                IQueryable<Cip> query;
                if (filter.iDisplayStart != null || filter.iDisplayLength != null)
                {
                    query= _readOnlyCtx.Set<Cip>()
                                      .OrderByDescending(x => x.Id)
                                      .Skip(filter.iDisplayStart ?? 0)
                                      .Take(filter.iDisplayLength ?? 0);
                }
                else
                {
                    query = _readOnlyCtx.Set<Cip>()
                                       .OrderByDescending(x => x.Id);
                }
              
                IQueryable<Cip> queryTotal = _readOnlyCtx.Set<Cip>()
                   .OrderByDescending(x => x.Id);


                // Forest Administration
                query = query.WhereIf(filter.HasForestCircleId, x => x.ForestCircleId == filter.ForestCircleId);
                query = query.WhereIf(filter.HasForestDivisionId, x => x.ForestDivisionId == filter.ForestDivisionId);
                query = query.WhereIf(filter.HasForestRangeId, x => x.ForestRangeId == filter.ForestRangeId);
                query = query.WhereIf(filter.HasForestBeatId, x => x.ForestBeatId == filter.ForestBeatId);
                query = query.WhereIf(filter.HasForestFcvVcfId, x => x.ForestFcvVcfId == filter.ForestFcvVcfId);

                // Civil Administration
                query = query.WhereIf(filter.HasDivisionId, x => x.DivisionId == filter.DivisionId);
                query = query.WhereIf(filter.HasDistrictId, x => x.DistrictId == filter.DistrictId);
                query = query.WhereIf(filter.HasUpazillaId, x => x.UpazillaId == filter.UpazillaId);
                query = query.WhereIf(filter.HasUnionId, x => x.UnionId == filter.UnionId);

                // Others
                query = query.WhereIf(filter.HasGender, x => x.Gender == filter.Gender);
                query = query.WhereIf(filter.HasCipWealth, x => x.CipWealth == filter.CipWealth);
                query = query.WhereIf(filter.HasNID, x => x.NID == filter.NID);
                query = query.WhereIf(filter.HasEthnicityId, x => x.EthnicityId == filter.EthnicityId);

                var result = await query
                    .ToListAsync();

                return (ExecutionState.Retrieved, new PaginationResutl<Cip>
                {
                    aaData = result,
                    iTotalDisplayRecords = await queryTotal.CountAsync(),
                    iTotalRecords = await queryTotal.CountAsync(),
                }, "Data returned successfully.");
            }
            catch (Exception)
            {
                return (ExecutionState.Failure, null!, "Unexpected error occurred.");
            }
        }



        public async Task<(ExecutionState executionState, IList<Cip> entity, string message)> ListByFilterForBeneficiary(CipFilterVM filter)
        {
            if (filter.HasForestFcvVcfId == false)
            {
                return (ExecutionState.Success, new List<Cip>()!, "Please provide Forest administration data.");
            }

            try
            {
                IQueryable<Cip> query = _readOnlyCtx.Set<Cip>();

                query = query.WhereIf(filter.HasForestCircleId, x => x.ForestCircleId == filter.ForestCircleId);
                query = query.WhereIf(filter.HasForestDivisionId, x => x.ForestDivisionId == filter.ForestDivisionId);
                query = query.WhereIf(filter.HasForestRangeId, x => x.ForestRangeId == filter.ForestRangeId);
                query = query.WhereIf(filter.HasForestBeatId, x => x.ForestBeatId == filter.ForestBeatId);
                query = query.WhereIf(filter.HasForestFcvVcfId, x => x.ForestFcvVcfId == filter.ForestFcvVcfId);

                query = query
                    .GroupJoin(
                        _readOnlyCtx.Set<Survey>(),
                        a => a.CipGeneratedId,
                        b => b.BeneficiaryId,
                        (a, b) => new { Cip = a, Survey = b })
                    .Where(x => !x.Survey.Any())
                    .Select(x => x.Cip);

                var result = await query
                    .ToListAsync();

                return (ExecutionState.Retrieved, result, "Data returned successfully.");
            }
            catch (Exception)
            {
                return (ExecutionState.Failure, new List<Cip>()!, "Unexpected error occurred.");
            }
        }

        public override async Task<(ExecutionState executionState, Cip entity, string message)> CreateAsync(Cip entity)
        {
            if (Validate(ref entity, out var errorMessage) == false)
            {
                return (ExecutionState.Success, null!, errorMessage);
            }

            entity.CipGeneratedId = GenerateId(entity);

            // Validate for CIP id
            var isCipIdAlreadyExists = await IsCipIdAlreadyExists(entity.CipGeneratedId);
            if (isCipIdAlreadyExists)
            {
                return (ExecutionState.Success, null!, "CIP already exists.");
            }

            return await base.CreateAsync(entity);
        }
        
        public async Task<(ExecutionState executionState, CIPDetailsVM entity, string message)> GetCipDetails(ForestCivilLocationFilter filter)
        {
            try
            {
                IQueryable<Cip> query = _readOnlyCtx.Set<Cip>();

                query = query.WhereIf(filter.HasForestCircleId, x => x.ForestCircleId == filter.ForestCircleId);
                query = query.WhereIf(filter.HasForestDivisionId, x => x.ForestDivisionId == filter.ForestDivisionId);
                query = query.WhereIf(filter.HasForestRangeId, x => x.ForestRangeId == filter.ForestRangeId);
                query = query.WhereIf(filter.HasForestBeatId, x => x.ForestBeatId == filter.ForestBeatId);
                query = query.WhereIf(filter.HasForestFcvVcfId, x => x.ForestFcvVcfId == filter.ForestFcvVcfId);

                query = query.WhereIf(filter.HasDivisionId, x => x.DivisionId == filter.DivisionId);
                query = query.WhereIf(filter.HasDistrictId, x => x.DistrictId == filter.DistrictId);
                query = query.WhereIf(filter.HasUpazillaId, x => x.UpazillaId == filter.UpazillaId);
                query = query.WhereIf(filter.HasUnionId, x => x.UnionId == filter.UnionId);

                var totalCount = await query.CountAsync();

                var totalMale = await query.Where(x => x.Gender == Gender.Male).CountAsync();
                var totalFemale = await query.Where(x => x.Gender == Gender.Female).CountAsync();
                var totalOthers = await query.Where(x => x.Gender == Gender.Others).CountAsync();

                return (ExecutionState.Retrieved, new CIPDetailsVM
                {
                    TotalCip = totalCount,
                    TotalMale = totalMale,
                    TotalFemale = totalFemale,
                    TotalOthersGender = totalOthers,
                }, "Success");
            }
            catch (Exception ex)
            {
                return (ExecutionState.Retrieved, new CIPDetailsVM(), ex.Message);
            }
        }

        public override async Task<(ExecutionState executionState, Cip entity, string message)> UpdateAsync(Cip entity)
        {
            if (Validate(ref entity, out var errorMessage) == false)
            {
                return (ExecutionState.Success, null!, errorMessage);
            }

            var cipId = GenerateId(entity);
            var currentCipId = await _readOnlyCtx.Set<Cip>()
                .Where(x => x.Id == entity.Id)
                .Select(x => x.CipGeneratedId)
                .FirstOrDefaultAsync();

            // Validate for CIP id
            var isCipIdAlreadyExists = await IsCipIdAlreadyExists(cipId, currentCipId);
            if (isCipIdAlreadyExists)
            {
                return (ExecutionState.Success, null!, "CIP already exists.");
            }

            entity.CipGeneratedId = cipId;

            return await base.UpdateAsync(entity);
        }

        #region Private methods
        private string GenerateId(Cip cip)
        {
            return $"{cip.ForestDivisionId}-{cip.ForestRangeId}-{cip.ForestBeatId}-{cip.ForestFcvVcfId}-{cip.HouseholdSerialNo}";
        }

        private bool Validate(ref Cip entity, out string errorMessage)
        {
            if (string.IsNullOrEmpty(entity.HouseholdSerialNo) || entity.HouseholdSerialNo.Length != 3)
            {
                errorMessage = "Household serial no must be 3 characters long";
                return false;
            }
            if (entity.ForestCircleId < 1)
            {
                errorMessage = "Forest circle is not valid.";
                return false;
            }
            if (entity.ForestDivisionId < 1)
            {
                errorMessage = "Forest division is not valid.";
                return false;
            }
            if (entity.ForestRangeId < 1)
            {
                errorMessage = "Forest range is not valid.";
                return false;
            }
            if (entity.ForestBeatId < 1)
            {
                errorMessage = "Forest beat is not valid.";
                return false;
            }
            if (entity.ForestFcvVcfId < 1)
            {
                errorMessage = "Forest FCV/VCF is not valid.";
                return false;
            }

            errorMessage = string.Empty;
            return true;
        }

        private Task<bool> IsCipIdAlreadyExists(string cipId, string? currentCipId = null)
        {
            return _readOnlyCtx.Set<Cip>()
                .WhereIf(string.IsNullOrEmpty(currentCipId) == false, x => x.CipGeneratedId != currentCipId)
                .AnyAsync(x => x.CipGeneratedId == cipId);
        }
        #endregion
    }
}

