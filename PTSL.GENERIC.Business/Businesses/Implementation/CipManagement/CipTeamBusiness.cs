using System.Linq;
using System.Threading.Tasks;

using PTSL.GENERIC.Business.BaseBusinesses;
using PTSL.GENERIC.Business.Businesses.Interface.CipManagement;
using PTSL.GENERIC.Common.Entity.CipManagement;
using PTSL.GENERIC.Common.Entity.ForestManagement;
using PTSL.GENERIC.Common.QuerySerialize.Implementation;
using PTSL.GENERIC.DAL.UnitOfWork;
using PTSL.GENERIC.Common.Enum;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System;
using PTSL.GENERIC.Common.Model.EntityViewModels.ForestManagement;
using PTSL.GENERIC.Common.Entity;
using PTSL.GENERIC.Common.Model.CustomModel;
using PTSL.GENERIC.Common.Entity.InternalLoan;

namespace PTSL.GENERIC.Business.Businesses.Implementation.CipManagement
{
    public class CipTeamBusiness : BaseBusiness<CipTeam>, ICipTeamBusiness
    {
        public readonly GENERICUnitOfWork _unitOfWork;
        private readonly GENERICReadOnlyCtx _readOnlyContext;
        public CipTeamBusiness(GENERICUnitOfWork unitOfWork, GENERICReadOnlyCtx readOnlyContext)
            : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _readOnlyContext = readOnlyContext;
        }

        public override Task<(ExecutionState executionState, IQueryable<CipTeam> entity, string message)> List(QueryOptions<CipTeam> queryOptions = null)
        {
            return base.List(new QueryOptions<CipTeam>()
            {
                IncludeExpression = e => e.Include(x => x.CipTeamMembers!).Include(x=>x.Ngo!).Include(x=>x.ForestCircle!).Include(x=>x.ForestDivision!).Include(x=>x.ForestRange!).Include(x=>x.ForestBeat!).Include(x=>x.ForestFcvVcf!),
                SortingExpression = x => x.OrderByDescending(y => y.Id)
            });
        }

        public override Task<(ExecutionState executionState, CipTeam entity, string message)> GetAsync(long id)
        {
            var filterOptions = new FilterOptions<CipTeam>
            {
                IncludeExpression = x => x
                    .Include(x=>x.ApprovalLogForCfms!)
                    .ThenInclude(x=>x.Sender!)
                    .Include(x => x.ApprovalLogForCfms!)
                    .ThenInclude(x=>x.Receiver!)

                    .Include(x => x.ForestCircle!)
                    .Include(x => x.ForestDivision!)
                    .Include(x => x.ForestRange!)
                    .Include(x => x.ForestBeat!)
                    .Include(x => x.ForestFcvVcf)
                    .Include(x => x.Division!)
                    .Include(x => x.District!)
                    .Include(x => x.Upazilla!)
                    .Include(x => x.Union!)
                    .Include(x => x.Ngo!)
                    .Include(x => x.CipTeamMembers!)
                    .ThenInclude(x=>x.Cip!)
                    .Include(x=>x.CipTeamMembers)
                    .ThenInclude(x=>x.OtherCommitteeMember)
                    .Include(x=>x.ForestFcvVcf),

                FilterExpression = e => e.Id == id
            };

            return base.GetAsync(filterOptions);
        }



        public async Task<(ExecutionState executionState, PaginationResutl<CipTeam> entity, string message)> GetByFilter(ExecutiveCommitteeFilterVM filterData)
        {
            try
            {
                //var query = _readOnlyContext.Set<CipTeam>()
                //    .Where(x => x.IsActive && !x.IsDeleted)
                //    .OrderByDescending(x => x.Id)
                //    .AsQueryable();


                if (filterData.sSearch != null)
                {
                    IQueryable<CipTeam> queryTotalSearch = _readOnlyContext.Set<CipTeam>()
                   .OrderByDescending(x => x.Id);
                    IQueryable<CipTeam> querySearch = _readOnlyContext.Set<CipTeam>()
                                      .Include(x=>x.Ngo)
                                      .Include(x=>x.ForestCircle)
                                      .Include(x=>x.ForestDivision)
                                      .Include(x=>x.ForestRange)
                                      .Include(x=>x.ForestBeat)
                                      .Where(x => x.IsActive && !x.IsDeleted)
                                      .OrderByDescending(x => x.Id);

                    querySearch = querySearch.Where(x => x.TeamName.Contains(filterData.sSearch) || x.Ngo.Name.Contains(filterData.sSearch) || x.ForestCircle.Name.Contains(filterData.sSearch) || x.ForestDivision.Name.Contains(filterData.sSearch) || x.ForestRange.Name.Contains(filterData.sSearch) || x.ForestBeat.Name.Contains(filterData.sSearch));
                    var resultSearch = await querySearch.ToListAsync();
                    return (ExecutionState.Retrieved, new PaginationResutl<CipTeam>
                    {
                        aaData = resultSearch,
                        iTotalDisplayRecords = await queryTotalSearch.CountAsync(),
                        iTotalRecords = await queryTotalSearch.CountAsync(),
                    }, "Data returned successfully.");
                }


                IQueryable<CipTeam> query;
                if (filterData.iDisplayStart != null || filterData.iDisplayLength != null)
                {
                    query = _readOnlyContext.Set<CipTeam>()
                                      .Include(x => x.Ngo)
                                      .Include(x => x.ForestCircle)
                                      .Include(x => x.ForestDivision)
                                      .Include(x => x.ForestRange)
                                      .Include(x => x.ForestBeat)
                                      .OrderByDescending(x => x.Id)
                                      .Skip(filterData.iDisplayStart ?? 0)
                                      .Take(filterData.iDisplayLength ?? 0);
                }
                else
                {
                    query = _readOnlyContext.Set<CipTeam>()
                                       .Include(x => x.Ngo)
                                       .Include(x=>x.ForestCircle)
                                       .Include(x=>x.ForestDivision)
                                       .Include(x=>x.ForestRange)
                                       .Include(x=>x.ForestBeat)
                                       .OrderByDescending(x => x.Id);
                }

              IQueryable<CipTeam> queryTotal = _readOnlyContext.Set<CipTeam>()
              .Include(x => x.Ngo)
              .Include(x => x.ForestCircle)
              .Include(x=>x.ForestDivision)
              .Include(x=>x.ForestRange)
              .Include(x=>x.ForestBeat)
              .OrderByDescending(x => x.Id);



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

                query = query.Include(x => x.CipTeamMembers!).Include(x => x.Ngo!).Include(x => x.ForestCircle!).Include(x => x.ForestDivision!).Include(x => x.ForestRange!).Include(x => x.ForestBeat!).Include(x => x.ForestFcvVcf!).OrderByDescending(x => x.Id);



                var result = await query
                    .ToListAsync();



                return (ExecutionState.Retrieved, new PaginationResutl<CipTeam>
                {
                    aaData = result,
                    iTotalDisplayRecords = await queryTotal.CountAsync(),
                    iTotalRecords = await queryTotal.CountAsync(),
                }, "Data returned successfully.");





                //return (ExecutionState.Retrieved, result, "Data returned successfully.");
            }
            catch (Exception ex)
            {
                return (ExecutionState.Failure, new PaginationResutl<CipTeam>()!, "Unexpected error occurred.");
            }
        }


    }
}