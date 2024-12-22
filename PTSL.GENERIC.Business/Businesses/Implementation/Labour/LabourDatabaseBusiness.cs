using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Business.BaseBusinesses;
using PTSL.GENERIC.Business.Businesses.Interface.Labour;
using PTSL.GENERIC.Common.Entity;
using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Entity.Labour;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Helper;
using PTSL.GENERIC.Common.Model.CustomModel;
using PTSL.GENERIC.Common.Model.EntityViewModels.Labour;
using PTSL.GENERIC.Common.QuerySerialize.Implementation;
using PTSL.GENERIC.DAL.UnitOfWork;

namespace PTSL.GENERIC.Business.Businesses.Implementation.Labour
{
    public class LabourDatabaseBusiness : BaseBusiness<LabourDatabase>, ILabourDatabaseBusiness
    {
        private readonly GENERICReadOnlyCtx _readOnlyCtx;

        public LabourDatabaseBusiness(GENERICUnitOfWork unitOfWork, GENERICReadOnlyCtx readOnlyCtx)
            : base(unitOfWork)
        {
            _readOnlyCtx = readOnlyCtx;
        }

        public override Task<(ExecutionState executionState, IQueryable<LabourDatabase> entity, string message)> List(QueryOptions<LabourDatabase> queryOptions = null)
        {
            return base.List(new QueryOptions<LabourDatabase>
            {
                IncludeExpression = e => e.OrderByDescending(x => x.Id)
                                         .Include(x => x.OtherLabourMember)
                                         .Include(x => x.Survey!)
            });
        }

        public override async Task<(ExecutionState executionState, LabourDatabase entity, string message)> GetAsync(long id)
        {
            return await base.GetAsync(new FilterOptions<LabourDatabase>
            {
                FilterExpression = e => e.Id == id,
                IncludeExpression = e => e
                    .Include(x => x.ForestCircle)
                    .Include(x => x.ForestDivision)
                    .Include(x => x.ForestRange)
                    .Include(x => x.ForestBeat)
                    .Include(x => x.ForestFcvVcf)
                    .Include(x => x.Division)
                    .Include(x => x.District)
                    .Include(x => x.Upazilla)
                    .Include(x => x.Union)
                    .Include(x => x.Survey).ThenInclude(x => x.BeneficiaryEthnicity)
                    .Include(x => x.OtherLabourMember).ThenInclude(x => x.Ethnicity)
                    .Include(y => y.LabourDatabaseFiles!)
            });
        }

        public async Task<(ExecutionState executionState, PaginationResutl<LabourDatabase> entity, string message)> GetByFilter(LabourDatabaseFilterVM filter)
        {
            try
            {
                //var query = _readOnlyCtx.Set<LabourDatabase>()
                //    .OrderByDescending(x => x.Id)
                //    .AsQueryable();
                if (filter.sSearch != null)
                {
                    IQueryable<LabourDatabase> queryTotalSearch = _readOnlyCtx.Set<LabourDatabase>()
                   .OrderByDescending(x => x.Id);
                    IQueryable<LabourDatabase> querySearch = _readOnlyCtx.Set<LabourDatabase>()
                                     .Include(x=>x.Survey)
                                     .Include(x=>x.OtherLabourMember)
                                     .OrderByDescending(x => x.Id);

                    querySearch = querySearch.Where(x => x.Survey.BeneficiaryName.Contains(filter.sSearch) || x.Survey.BeneficiaryNid.Contains(filter.sSearch) || x.Survey.Phonenumber.Contains(filter.sSearch) || x.Address.Contains(filter.sSearch) || x.OtherLabourMember.FullName.Contains(filter.sSearch) || x.OtherLabourMember.NID.Contains(filter.sSearch) || x.OtherLabourMember.PhoneNumber.Contains(filter.sSearch));
                    var resultSearch = await querySearch.ToListAsync();
                    return (ExecutionState.Retrieved, new PaginationResutl<LabourDatabase>
                    {
                        aaData = resultSearch,
                        iTotalDisplayRecords = await queryTotalSearch.CountAsync(),
                        iTotalRecords = await queryTotalSearch.CountAsync(),
                    }, "Data returned successfully.");
                }




                IQueryable<LabourDatabase> query;
                if (filter.iDisplayStart != null || filter.iDisplayLength != null)
                {
                    query = _readOnlyCtx.Set<LabourDatabase>()
                                      .OrderByDescending(x => x.Id)
                                      .Skip(filter.iDisplayStart ?? 0)
                                      .Take(filter.iDisplayLength ?? 0);
                }
                else
                {
                    query = _readOnlyCtx.Set<LabourDatabase>()
                                       .OrderByDescending(x => x.Id);
                }
                IQueryable<LabourDatabase> queryTotal = _readOnlyCtx.Set<LabourDatabase>()
               .OrderByDescending(x => x.Id);


                // Forest Administration
                query = query.WhereIf(filter.HasForestCircleId, x => x.ForestCircleId == filter.ForestCircleId);
                query = query.WhereIf(filter.HasForestDivisionId, x => x.ForestDivisionId == filter.ForestDivisionId);
                query = query.WhereIf(filter.HasForestRangeId, x => x.ForestRangeId == filter.ForestRangeId);
                query = query.WhereIf(filter.HasForestBeatId, x => x.ForestBeatId == filter.ForestBeatId);

                // Civil Administration
                query = query.WhereIf(filter.HasDivisionId, x => x.DivisionId == filter.DivisionId);
                query = query.WhereIf(filter.HasDistrictId, x => x.DistrictId == filter.DistrictId);
                query = query.WhereIf(filter.HasUpazillaId, x => x.UpazillaId == filter.UpazillaId);
                query = query.WhereIf(filter.HasUnionId, x => x.UnionId == filter.UnionId);

                query = query.Include(x => x.OtherLabourMember)
                    .Include(x => x.Survey);
                query = query.IncludeIf(filter.ReturnLabourWorks, x => x.LabourWorks);

                if (filter.Take is int toTake)
                {
                    query = query.Take(toTake);
                }

                var result = await query
                    .ToListAsync();



                return (ExecutionState.Retrieved, new PaginationResutl<LabourDatabase>
                {
                    aaData = result,
                    iTotalDisplayRecords = await queryTotal.CountAsync(),
                    iTotalRecords = await queryTotal.CountAsync(),
                }, "Data returned successfully.");


                //return (ExecutionState.Retrieved, result, "Data returned successfully.");
            }
            catch (Exception)
            {
                return (ExecutionState.Failure, new PaginationResutl<LabourDatabase>()!, "Unexpected error occurred.");
            }
        }

        public override Task<(ExecutionState executionState, LabourDatabase entity, string message)> UpdateAsync(LabourDatabase entity)
        {
            if (entity.LabourDatabaseFiles is not null && entity.LabourDatabaseFiles.Count > 0)
            {
                var files = _readOnlyCtx.Set<LabourDatabaseFile>().Where(x => x.LabourDatabaseId == entity.Id).ToList();
                foreach (var file in files)
                {
                    file.IsDeleted = true;
                    file.IsActive = false;
                }

                entity.LabourDatabaseFiles = entity.LabourDatabaseFiles.Concat(files).ToList();
            }

            if (entity.SurveyId is not null && entity.SurveyId > 0)
            {
                entity.OtherLabourMember = null;
            }

            return base.UpdateAsync(entity);
        }

        public override Task<(ExecutionState executionState, LabourDatabase entity, string message)> CreateAsync(LabourDatabase entity)
        {
            if (entity.SurveyId is not null && entity.SurveyId > 0)
            {
                entity.OtherLabourMember = null;
            }

            return base.CreateAsync(entity);
        }


    }
}
