using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Business.BaseBusinesses;
using PTSL.GENERIC.Business.Businesses.Interface.ForestManagement;
using PTSL.GENERIC.Common.Entity.ForestManagement;
using PTSL.GENERIC.Common.Entity.MeetingManagement;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.QuerySerialize.Implementation;
using PTSL.GENERIC.DAL.UnitOfWork;
using PTSL.GENERIC.Common.Model.EntityViewModels.ForestManagement;
using PTSL.GENERIC.Common.Entity;
using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Helper;
using PTSL.GENERIC.Common.Model.EntityViewModels.DashBoard;
using PTSL.GENERIC.Common.Enum.ForestManagement;
using PTSL.GENERIC.Common.Model.EntityViewModels;
using PTSL.GENERIC.Common.Model.CustomModel;

namespace PTSL.GENERIC.Business.Businesses.Implementation.ForestManagement
{
    public class CommitteeManagementBusiness : BaseBusiness<CommitteeManagement>, ICommitteeManagementBusiness
    {

        public readonly GENERICUnitOfWork _unitOfWork;
        private readonly GENERICReadOnlyCtx _readOnlyContext;
        public CommitteeManagementBusiness(GENERICUnitOfWork unitOfWork, GENERICReadOnlyCtx readOnlyContext)
            : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _readOnlyContext = readOnlyContext;
        }


        public override Task<(ExecutionState executionState, IQueryable<CommitteeManagement> entity, string message)> List(QueryOptions<CommitteeManagement> queryOptions = null)
        {
            return base.List(new QueryOptions<CommitteeManagement>()
            {
                FilterExpression = e => e.CommitteeApprovalStatus == 0 && e.ApprovalStatus == 1,
                IncludeExpression = e => e.Include(x => x.Ngo!)
                .Include(x => x.CommitteeTypeConfiguration!)
                .Include(x => x.CommitteesConfiguration!),
                SortingExpression = x => x.OrderByDescending(y => y.Id),
            }) ;
        }


        public override Task<(ExecutionState executionState, CommitteeManagement entity, string message)> GetAsync(long id)
        {
            var filterOptions = new FilterOptions<CommitteeManagement>
            {
                IncludeExpression = x => x
                    .Include(x=>x.ApprovalLogForCfms!)
                    .ThenInclude(x=>x.Sender!)
                    .Include(x=>x.ApprovalLogForCfms!)
                    .ThenInclude(x=>x.Receiver!)

                    .Include(x => x.ForestCircle!)
                    .Include(x => x.ForestDivision!)
                    .Include(x => x.ForestRange!)
                    .Include(x => x.ForestBeat!)
                    .Include(x => x.ForestFcvVcf!)
                    .Include(x => x.Division!)
                    .Include(x => x.District!)
                    .Include(x => x.Upazilla!)
                    .Include(x => x.Union!)
                    .Include(x => x.Ngo!)
                    .Include(x => x.CommitteeTypeConfiguration!)
                    .Include(x => x.CommitteesConfiguration!)
                    .Include(x => x.CommitteeDesignationsConfiguration!)
                    .Include(x=>x.CommitteeManagementMembers!)
                    .ThenInclude(x=>x.CommitteeDesignation!)
                     .Include(x => x.CommitteeManagementMembers!)
                    .ThenInclude(x => x.CommitteeDesignationsConfiguration!)
                    .Include(x => x.CommitteeManagementMembers!)
                    .ThenInclude(x => x.Survey!)
                    .Include(x => x.CommitteeManagementMembers!)
                    .ThenInclude(x => x.OtherCommitteeMember!)
                    .ThenInclude(x=>x.Ethnicity!),

                FilterExpression = e => e.Id == id
            };

            return base.GetAsync(filterOptions);
        }



        public async Task<(ExecutionState executionState, PaginationResutl<CommitteeManagement> entity, string message)> GetByFilter(ExecutiveCommitteeFilterVM filterData)
        {
            try
            {

                if (filterData.sSearch != null)
                {
                    IQueryable<CommitteeManagement> queryTotalSearch = _readOnlyContext.Set<CommitteeManagement>()
                   .OrderByDescending(x => x.Id);
                    IQueryable<CommitteeManagement> querySearch = _readOnlyContext.Set<CommitteeManagement>()
                                     .Where(x => x.IsActive && !x.IsDeleted)
                                     .Include(x => x.Ngo!)
                                     .Include(x => x.CommitteeTypeConfiguration!)
                                     .Include(x => x.CommitteesConfiguration!)
                                     .OrderByDescending(x => x.Id);

                    querySearch = querySearch.Where(x => x.Ngo.Name.Contains(filterData.sSearch) || x.CommitteeTypeConfiguration.CommitteeTypeName.Contains(filterData.sSearch));
                    var resultSearch = await querySearch.ToListAsync();
                    return (ExecutionState.Retrieved, new PaginationResutl<CommitteeManagement>
                    {
                        aaData = resultSearch,
                        iTotalDisplayRecords = await queryTotalSearch.CountAsync(),
                        iTotalRecords = await queryTotalSearch.CountAsync(),
                    }, "Data returned successfully.");
                }




                var query = _readOnlyContext.Set<CommitteeManagement>()
                    .Where(x => x.IsActive && !x.IsDeleted)
                    .Include(x => x.Ngo!)
                    .Include(x => x.CommitteeTypeConfiguration!)
                    .Include(x => x.CommitteesConfiguration!)
                    .OrderByDescending(x => x.Id)
                    .AsQueryable();


                IQueryable<CommitteeManagement> queryTotal = query;

                if (filterData.iDisplayStart != null || filterData.iDisplayLength != null)
                {
                    query = query
                        .Skip(filterData.iDisplayStart ?? 0)
                       .Take(filterData.iDisplayLength ?? 0);
                }
                else
                {
                    query = query
                        .OrderByDescending(x => x.Id);
                }


                // Forest Administration
                if (filterData?.ForestCircleId != null && filterData?.ForestCircleId > 0)
                {
                    query = query.Where(x => x.ForestCircleId == filterData.ForestCircleId);
                }
                if (filterData?.ForestDivisionId != null && filterData?.ForestDivisionId > 0)
                {
                    query = query.Where(x => x.ForestDivisionId == filterData.ForestDivisionId);
                }
                if (filterData?.ForestRangeId != null && filterData?.ForestRangeId > 0)
                {
                    query = query.Where(x => x.ForestRangeId == filterData.ForestRangeId);
                }
                if (filterData?.ForestBeatId != null && filterData?.ForestBeatId > 0)
                {
                    query = query.Where(x => x.ForestBeatId == filterData.ForestBeatId);
                }
               

                // Civil Administration
                if (filterData?.DivisionId != null && filterData?.DivisionId > 0)
                {
                    query = query.Where(x => x.DivisionId == filterData.DivisionId);
                }
                if (filterData?.DistrictId != null && filterData?.DistrictId > 0)
                {
                    query = query.Where(x => x.DistrictId == filterData.DistrictId);
                }
                if (filterData?.UpazillaId != null && filterData?.UpazillaId > 0)
                {
                    query = query.Where(x => x.UpazillaId == filterData.UpazillaId);
                }
                if (filterData?.UnionId != null && filterData?.UnionId > 0)
                {
                    query = query.Where(x => x.UnionId == filterData.UnionId);
                }


                ////Extra Filter

                //if (filterData?.Gender != null)
                //{
                //    query = query.Where(x => x.GenderId == (long)filterData.Gender);
                //}

                //if (filterData?.PhoneNumber != null)
                //{
                //    query = query.Where(x => x.CellNo == filterData.PhoneNumber);
                //}

                //if (filterData?.NID != null)
                //{
                //    query = query.Where(x => x.NidNo == filterData.NID);
                //}

                //if (filterData?.NgoId > 0)
                //{
                //    query = query.Where(x => x.NgoId == filterData.NgoId);
                //}

                 query = query.Include(y => y.Ngo).OrderByDescending(x => x.Id);
                
               

                var result = await query
                    .ToListAsync();



                return (ExecutionState.Retrieved, new PaginationResutl<CommitteeManagement>
                {
                    aaData = result,
                    iTotalDisplayRecords = await queryTotal.CountAsync(),
                    iTotalRecords = await queryTotal.CountAsync(),
                }, "Data returned successfully.");



                //return (ExecutionState.Retrieved, result, "Data returned successfully.");
            }
            catch (Exception ex)
            {
                return (ExecutionState.Failure, new PaginationResutl<CommitteeManagement>()!, "Unexpected error occurred.");
            }
        }

        public async Task<(ExecutionState executionState, CommitteeMemberCount entity, string message)> GetTotalFcvVcfAndExecutiveSubExecutive(ForestCivilLocationFilter filter)
        {
            try
            {
                IQueryable<ForestFcvVcf> fcvVcfQuery = _readOnlyContext.Set<ForestFcvVcf>();
                IQueryable<CommitteeManagementMember> executiveCommitteeQuery = _readOnlyContext.Set<CommitteeManagementMember>();

                executiveCommitteeQuery = executiveCommitteeQuery.WhereIf(filter.HasForestCircleId, x => x.CommitteeManagement!.ForestCircleId == filter.ForestCircleId);
                executiveCommitteeQuery = executiveCommitteeQuery.WhereIf(filter.HasForestDivisionId, x => x.CommitteeManagement!.ForestDivisionId == filter.ForestDivisionId);
                executiveCommitteeQuery = executiveCommitteeQuery.WhereIf(filter.HasForestRangeId, x => x.CommitteeManagement!.ForestRangeId == filter.ForestRangeId);
                executiveCommitteeQuery = executiveCommitteeQuery.WhereIf(filter.HasForestBeatId, x => x.CommitteeManagement!.ForestBeatId == filter.ForestBeatId);
                executiveCommitteeQuery = executiveCommitteeQuery.WhereIf(filter.HasForestFcvVcfId, x => x.CommitteeManagement!.ForestFcvVcfId == filter.ForestFcvVcfId);

                executiveCommitteeQuery = executiveCommitteeQuery.WhereIf(filter.HasDistrictId, x => x.CommitteeManagement!.DistrictId == filter.DistrictId);
                executiveCommitteeQuery = executiveCommitteeQuery.WhereIf(filter.HasDivisionId, x => x.CommitteeManagement!.DivisionId == filter.DivisionId);
                executiveCommitteeQuery = executiveCommitteeQuery.WhereIf(filter.HasUpazillaId, x => x.CommitteeManagement!.UpazillaId == filter.UpazillaId);

                var totalFcvVcf = await fcvVcfQuery
                    .WhereIf(filter.HasForestCircleId, x => x.ForestBeat!.ForestRange!.ForestDivision!.ForestCircleId == filter.ForestCircleId)
                    .WhereIf(filter.HasForestDivisionId, x => x.ForestBeat!.ForestRange!.ForestDivisionId == filter.ForestDivisionId)
                    .WhereIf(filter.HasForestRangeId, x => x.ForestBeat!.ForestRangeId == filter.ForestRangeId)
                    .WhereIf(filter.HasForestBeatId, x => x.ForestBeatId == filter.ForestRangeId)
                    .WhereIf(filter.HasForestFcvVcfId, x => x.Id == filter.ForestFcvVcfId)
                    .CountAsync();

                var committeeMembers = await executiveCommitteeQuery
                    .GroupBy(x => new
                    {
                        x.CommitteeManagement!.CommitteeTypeId,
                        BeneficiaryGender = x.Survey != null ? x.Survey.BeneficiaryGender : Gender.Others,
                        Gender = x.OtherCommitteeMember != null ? x.OtherCommitteeMember.Gender : Gender.Others
                    })
                    .Select(g => new
                    {
                        g.Key.CommitteeTypeId,
                        g.Key.BeneficiaryGender,
                        OtherCommitteeMemberGender = g.Key.Gender,
                        Count = g.Count()
                    })
                    .ToListAsync();

                var committeeCounts = committeeMembers
                    .GroupBy(x => x.CommitteeTypeId)
                    .ToDictionary(
                        g => g.Key,
                        g => new CommitteeCounts
                        {
                            Total = g.Sum(x => x.Count),
                            Male = g.Sum(x => x.BeneficiaryGender == Gender.Male || x.OtherCommitteeMemberGender == Gender.Male ? x.Count : 0),
                            Female = g.Sum(x => x.BeneficiaryGender == Gender.Female || x.OtherCommitteeMemberGender == Gender.Female ? x.Count : 0),
                        }
                    );

                int totalMale = committeeCounts.Values.Sum(counts => counts.Male);
                int totalFemale = committeeCounts.Values.Sum(counts => counts.Female);

                var fcvVcfCounts = new
                {
                    TotalMaleFemale = totalMale + totalFemale,
                    Male = totalMale,
                    Female = totalFemale
                };
                var executiveCounts = committeeCounts.GetValueOrDefault(CommitteeType.ExecutiveCommittee) ?? new CommitteeCounts();
                var subExecutiveCounts = committeeCounts.GetValueOrDefault(CommitteeType.SubExecutiveCommittee) ?? new CommitteeCounts();
                var coordinationCounts = committeeCounts.GetValueOrDefault(CommitteeType.CoordinationCommittee) ?? new CommitteeCounts();

                var committeeMemberCount = new CommitteeMemberCount
                {
                    TotalFcvVcf = totalFcvVcf,
                    TotalFcvVcfMaleFemale = fcvVcfCounts.TotalMaleFemale,
                    TotalFcvVcfMaleInPercentage = Math.Round(CalculatePercentage(fcvVcfCounts.Male, fcvVcfCounts.TotalMaleFemale)),
                    TotalFcvVcfFemaleInPercentage = Math.Round(CalculatePercentage(fcvVcfCounts.Female, fcvVcfCounts.TotalMaleFemale)),

                    TotalExecutiveMember = executiveCounts.Total,
                    TotalExecutiveMemberMaleInPercentage = Math.Round(CalculatePercentage(executiveCounts.Male, executiveCounts.Total)),
                    TotalExecutiveMemberFemaleInPercentage = Math.Round(CalculatePercentage(executiveCounts.Female, executiveCounts.Total)),

                    TotalSubExecutiveMember = subExecutiveCounts.Total,
                    TotalSubExecutiveMemberMaleInPercentage = Math.Round(CalculatePercentage(subExecutiveCounts.Male, subExecutiveCounts.Total)),
                    TotalSubExecutiveMemberFemaleInPercentage = Math.Round(CalculatePercentage(subExecutiveCounts.Female, subExecutiveCounts.Total)),

                    TotalCoOrdinationMember = coordinationCounts.Total,
                    TotalCoOrdinationMemberMaleInPercentage = Math.Round(CalculatePercentage(coordinationCounts.Male, coordinationCounts.Total)),
                    TotalCoOrdinationMemberFemaleInPercentage = Math.Round(CalculatePercentage(coordinationCounts.Female, coordinationCounts.Total)),
                };

                return (executionState: ExecutionState.Success, entity: committeeMemberCount, message: "Success");
            }
            catch (Exception e)
            {
                return (ExecutionState.Failure, null!, "Unexpected");
            }
        }

        private static double CalculatePercentage(int count, int total)
            => total == 0 ? 0.0 : (double)count / total * 100;
    }
}

// Class to represent committee counts
public class CommitteeCounts
{
    public int Total { get; set; }
    public int Male { get; set; }
    public int Female { get; set; }
}
