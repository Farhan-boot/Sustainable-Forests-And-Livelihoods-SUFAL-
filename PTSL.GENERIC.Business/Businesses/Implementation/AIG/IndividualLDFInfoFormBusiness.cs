using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Business.BaseBusinesses;
using PTSL.GENERIC.Business.Businesses.Interface.AIG;
using PTSL.GENERIC.Common.Entity;
using PTSL.GENERIC.Common.Entity.AIG;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Enum.AIG;
using PTSL.GENERIC.Common.Helper;
using PTSL.GENERIC.Common.Model.CustomModel;
using PTSL.GENERIC.Common.Model.EntityViewModels.AIG;
using PTSL.GENERIC.Common.Model.EntityViewModels.Beneficiary;
using PTSL.GENERIC.Common.QuerySerialize.Implementation;
using PTSL.GENERIC.DAL.UnitOfWork;

namespace PTSL.GENERIC.Business.Businesses.Implementation.AIG
{
    public class IndividualLDFInfoFormBusiness : BaseBusiness<IndividualLDFInfoForm>, IIndividualLDFInfoFormBusiness
    {
        private readonly GENERICUnitOfWork _unitOfWork;
        private readonly GENERICReadOnlyCtx _readOnlyCtx;
        private readonly GENERICWriteOnlyCtx _writeOnlyCtx;

        public IndividualLDFInfoFormBusiness(
            GENERICUnitOfWork unitOfWork,
            GENERICReadOnlyCtx readOnlyCtx,
            GENERICWriteOnlyCtx writeOnlyCtx)
            : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _readOnlyCtx = readOnlyCtx;
            _writeOnlyCtx = writeOnlyCtx;
        }

        public override async Task<(ExecutionState executionState, IndividualLDFInfoForm entity, string message)> CreateAsync(IndividualLDFInfoForm entity)
        {
            var allIndividualLdfs = await _readOnlyCtx.Set<IndividualLDFInfoForm>()
                .Where(x => x.SurveyId == entity.SurveyId)
                .ToListAsync();

            var maxLdf = allIndividualLdfs.Count == 0 ? 0 : allIndividualLdfs.Max(x => x.LDFCount);
            var newLDFCount = maxLdf + 1;

            entity.SubmittedDate = DateTime.Now;
            entity.LDFCount = newLDFCount;

            return await base.CreateAsync(entity);
        }

        public override Task<(ExecutionState executionState, IQueryable<IndividualLDFInfoForm> entity, string message)> List(QueryOptions<IndividualLDFInfoForm> queryOptions = null)
        {
            return base.List(new QueryOptions<IndividualLDFInfoForm>
            {
                IncludeExpression = e => e.Include(x => x.Survey!).Include(x => x.Ngo!),
                SortingExpression = e => e.OrderByDescending(x => x.Id)
            });
        }

        public async Task<(ExecutionState executionState, PaginationResutl<IndividualLDFInfoForm> entity, string message)> ListByFilter(IndividualLDFFilterVM filter)
        {
            try
            {
                //IQueryable<IndividualLDFInfoForm> query = _readOnlyCtx.Set<IndividualLDFInfoForm>()
                //    .OrderByDescending(x => x.Id);


                if (filter.sSearch != null)
                {
                    IQueryable<IndividualLDFInfoForm> queryTotalSearch = _readOnlyCtx.Set<IndividualLDFInfoForm>()
                    .Include(x => x.Survey)
                    .Include(x => x.Ngo)
                   .OrderByDescending(x => x.Id);
                    IQueryable<IndividualLDFInfoForm> querySearch = _readOnlyCtx.Set<IndividualLDFInfoForm>()
                                      .Include(x => x.Survey)
                                      .Include(x => x.Ngo)
                                      .OrderByDescending(x => x.Id);

                    querySearch = querySearch.Where(x => x.Survey.BeneficiaryName.Contains(filter.sSearch) || x.Survey.BeneficiaryPhone.Contains(filter.sSearch) || x.Survey.BeneficiaryNid.Contains(filter.sSearch) || x.Ngo.Name.Contains(filter.sSearch));
                    var resultSearch = await querySearch.ToListAsync();
                    return (ExecutionState.Retrieved, new PaginationResutl<IndividualLDFInfoForm>
                    {
                        aaData = resultSearch,
                        iTotalDisplayRecords = await queryTotalSearch.CountAsync(),
                        iTotalRecords = await queryTotalSearch.CountAsync(),
                    }, "Data returned successfully.");
                }



                IQueryable<IndividualLDFInfoForm> query;
                if (filter.iDisplayStart != null || filter.iDisplayLength != null)
                {
                    query = _readOnlyCtx.Set<IndividualLDFInfoForm>()
                                      .OrderByDescending(x => x.Id)
                                      .Skip(filter.iDisplayStart ?? 0)
                                      .Take(filter.iDisplayLength ?? 0);
                }
                else
                {
                    query = _readOnlyCtx.Set<IndividualLDFInfoForm>()
                                       .OrderByDescending(x => x.Id);
                }
                IQueryable<IndividualLDFInfoForm> queryTotal = _readOnlyCtx.Set<IndividualLDFInfoForm>()
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
                query = query.WhereIf(filter.HasGender, x => x.Survey!.BeneficiaryGender == filter.Gender);
                query = query.WhereIf(filter.HasPhoneNumber, x => x.Survey!.BeneficiaryPhone == filter.PhoneNumber);
                query = query.WhereIf(filter.HasNID, x => x.Survey!.BeneficiaryNid == filter.NID);
                query = query.WhereIf(filter.HasNgoId, x => x.NgoId == filter.NgoId);

                if (filter.HasTake)
                {
                    query = query.Take(filter.Take ?? Defaults.Take);
                }

                var result = await query
                    .Include(x => x.Survey)
                    .Include(x => x.Ngo)
                    .ToListAsync();




                return (ExecutionState.Retrieved, new PaginationResutl<IndividualLDFInfoForm>
                {
                    aaData = result,
                    iTotalDisplayRecords = await queryTotal.CountAsync(),
                    iTotalRecords = await queryTotal.CountAsync(),
                }, "Data returned successfully.");


                // return (ExecutionState.Retrieved, result, "Data returned successfully.");
            }
            catch (Exception ex)
            {
                return (ExecutionState.Failure, new PaginationResutl<IndividualLDFInfoForm>()!, "Unexpected error occurred.");
            }
        }
        public async Task<(ExecutionState executionState, List<IndividualLDFInfoForm> entity, string message)> ListByFilterBasic(IndividualLDFFilterVM filter)
        {
            try
            {
                //IQueryable<IndividualLDFInfoForm> query = _readOnlyCtx.Set<IndividualLDFInfoForm>()
                //    .OrderByDescending(x => x.Id);


                if (filter.sSearch != null)
                {
                    IQueryable<IndividualLDFInfoForm> queryTotalSearch = _readOnlyCtx.Set<IndividualLDFInfoForm>()
                    .Include(x => x.Survey)
                    .Include(x => x.Ngo)
                   .OrderByDescending(x => x.Id);
                    IQueryable<IndividualLDFInfoForm> querySearch = _readOnlyCtx.Set<IndividualLDFInfoForm>()
                                      .Include(x => x.Survey)
                                      .Include(x => x.Ngo)
                                      .OrderByDescending(x => x.Id);

                    querySearch = querySearch.Where(x => x.Survey.BeneficiaryName.Contains(filter.sSearch) || x.Survey.BeneficiaryPhone.Contains(filter.sSearch) || x.Survey.BeneficiaryNid.Contains(filter.sSearch) || x.Ngo.Name.Contains(filter.sSearch));
                    var resultSearch = await querySearch.ToListAsync();
                    return (ExecutionState.Retrieved, resultSearch, "Data returned successfully.");
                }



                IQueryable<IndividualLDFInfoForm> query;
                if (filter.iDisplayStart != null || filter.iDisplayLength != null)
                {
                    query = _readOnlyCtx.Set<IndividualLDFInfoForm>()
                                      .OrderByDescending(x => x.Id)
                                      .Skip(filter.iDisplayStart ?? 0)
                                      .Take(filter.iDisplayLength ?? 0);
                }
                else
                {
                    query = _readOnlyCtx.Set<IndividualLDFInfoForm>()
                                       .OrderByDescending(x => x.Id);
                }
                IQueryable<IndividualLDFInfoForm> queryTotal = _readOnlyCtx.Set<IndividualLDFInfoForm>()
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
                query = query.WhereIf(filter.HasGender, x => x.Survey!.BeneficiaryGender == filter.Gender);
                query = query.WhereIf(filter.HasPhoneNumber, x => x.Survey!.BeneficiaryPhone == filter.PhoneNumber);
                query = query.WhereIf(filter.HasNID, x => x.Survey!.BeneficiaryNid == filter.NID);
                query = query.WhereIf(filter.HasNgoId, x => x.NgoId == filter.NgoId);

                if (filter.HasTake)
                {
                    query = query.Take(filter.Take ?? Defaults.Take);
                }

                var result = await query
                    .Include(x => x.Survey)
                    .Include(x => x.Ngo)
                    .ToListAsync();




                return (ExecutionState.Retrieved, result, "Data returned successfully.");


                // return (ExecutionState.Retrieved, result, "Data returned successfully.");
            }
            catch (Exception ex)
            {
                return (ExecutionState.Failure, new List<IndividualLDFInfoForm>()!, "Unexpected error occurred.");
            }
        }

        public async Task<(ExecutionState executionState, IList<SurveyDropdownVM> entity, string message)> ListByFilterBeneficiary(IndividualLDFFilterVM filter)
        {
            try
            {
                IQueryable<IndividualLDFInfoForm> query = _readOnlyCtx.Set<IndividualLDFInfoForm>()
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
                query = query.WhereIf(filter.HasGender, x => x.Survey!.BeneficiaryGender == filter.Gender);
                query = query.WhereIf(filter.HasPhoneNumber, x => x.Survey!.BeneficiaryPhone == filter.PhoneNumber);
                query = query.WhereIf(filter.HasNID, x => x.Survey!.BeneficiaryNid == filter.NID);
                query = query.WhereIf(filter.HasNgoId, x => x.NgoId == filter.NgoId);

                if (filter.HasTake)
                {
                    query = query.Take(filter.Take ?? Defaults.Take);
                }

                var result = await query
                    .Select(x => new SurveyDropdownVM(x.Survey, x))
                    .ToListAsync();

                return (ExecutionState.Retrieved, result, "Data returned successfully.");
            }
            catch (Exception ex)
            {
                return (ExecutionState.Failure, new List<SurveyDropdownVM>()!, "Unexpected error occurred.");
            }
        }

        public async Task<(ExecutionState executionState, double amount, string message)> GetLDFAmountForBeneficiary(long beneficiaryId)
        {
            var result = await _readOnlyCtx.Set<IndividualLDFInfoForm>()
                .Where(x => x.SurveyId == beneficiaryId)
                .OrderByDescending(x => x.Id)
                .Select(x => x.ApprovedLoanAmount)
                .FirstOrDefaultAsync();

            return (ExecutionState.Success, result, "Data retrieved successfully");
        }

        public override Task<(ExecutionState executionState, IndividualLDFInfoForm entity, string message)> GetAsync(long key)
        {
            return base.GetAsync(new FilterOptions<IndividualLDFInfoForm>
            {
                FilterExpression = e => e.Id == key,
                IncludeExpression = e => e
                    .Include(x => x.ForestCircle)
                    .Include(x => x.ForestDivision)
                    .Include(x => x.ForestRange)
                    .Include(x => x.ForestBeat)
                    .Include(x => x.ForestFcvVcf!)
                    .Include(x => x.Upazilla!)
                    .Include(x => x.Union!)
                    .Include(x => x.District!)
                    .Include(x => x.Division!)
                    .Include(x => x.Ngo!)
                    .Include(x => x.Survey!)
            });
        }

        public async Task<(ExecutionState executionState, bool entity, string message)> ApproveLDF(long ldfId, double approvedLoanAmount)
        {
            var ldf = await _readOnlyCtx.Set<IndividualLDFInfoForm>().FirstOrDefaultAsync(x => x.Id == ldfId);
            if (ldf is null)
            {
                return (ExecutionState.Failure, false, "LDF not found.");
            }

            ldf.IndividualLDFInfoStatus = IndividualLDFInfoStatus.Approved;
            ldf.StatusDate = DateTime.Now;
            ldf.ApprovedLoanAmount = approvedLoanAmount;

            _writeOnlyCtx.Set<IndividualLDFInfoForm>().Update(ldf);
            await _writeOnlyCtx.SaveChangesAsync();

            return (ExecutionState.Success, true, "Successfully approved");
        }

        public async Task<(ExecutionState executionState, bool entity, string message)> RejectLDF(long ldfId)
        {
            var ldf = await _readOnlyCtx.Set<IndividualLDFInfoForm>().FirstOrDefaultAsync(x => x.Id == ldfId);
            if (ldf is null)
            {
                return (ExecutionState.Failure, false, "LDF not found.");
            }

            ldf.IndividualLDFInfoStatus = IndividualLDFInfoStatus.Rejected;
            ldf.StatusDate = DateTime.Now;

            _writeOnlyCtx.Set<IndividualLDFInfoForm>().Update(ldf);
            await _writeOnlyCtx.SaveChangesAsync();

            return (ExecutionState.Success, true, "Successfully rejected");
        }
    }
}