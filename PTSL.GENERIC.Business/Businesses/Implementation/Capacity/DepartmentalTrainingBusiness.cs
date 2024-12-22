using Microsoft.EntityFrameworkCore;
using PTSL.GENERIC.Business.BaseBusinesses;
using PTSL.GENERIC.Business.Businesses.Interface.Capacity;
using PTSL.GENERIC.Common.Entity.Capacity;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.QuerySerialize.Implementation;
using PTSL.GENERIC.DAL.UnitOfWork;
using System.Threading.Tasks;
using System.Linq;
using System;
using PTSL.GENERIC.Common.Model.EntityViewModels.Capacity;
using PTSL.GENERIC.Common.Entity;
using PTSL.GENERIC.Common.Helper;
using System.Collections.Generic;
using PTSL.GENERIC.Common.Model.CustomModel;

namespace PTSL.GENERIC.Business.Businesses.Implementation.Capacity
{
    public class DepartmentalTrainingBusiness : BaseBusiness<DepartmentalTraining>, IDepartmentalTrainingBusiness
    {
        private readonly GENERICUnitOfWork _unitOfWork;
        private readonly GENERICReadOnlyCtx _readOnlyCtx;

        public DepartmentalTrainingBusiness(GENERICUnitOfWork unitOfWork, GENERICReadOnlyCtx readOnlyCtx)
            : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _readOnlyCtx = readOnlyCtx;
        }

        public override Task<(ExecutionState executionState, IQueryable<DepartmentalTraining> entity, string message)> List(QueryOptions<DepartmentalTraining> queryOptions = null)
        {
            queryOptions = new QueryOptions<DepartmentalTraining>()
            {
                IncludeExpression = x => x.Include(y => y.FinancialYear!),
                SortingExpression = x => x.OrderByDescending(y => y.Id),
            };

            return base.List(queryOptions);
        }

        public Task<(ExecutionState executionState, IQueryable<DepartmentalTraining> entity, string message)> GetByFilter(long finalYearId)
        {
            var queryOptions = new QueryOptions<DepartmentalTraining>()
            {
                SortingExpression = x => x.OrderByDescending(y => y.Id),
                FilterExpression = x => x.FinancialYearId == finalYearId,
                //IncludeExpression = x => x.Include(y => y.DepartmentalTrainingParticipentsMaps!).ThenInclude(x => x.DepartmentalTrainingMember!)
            };

            return base.List(queryOptions);
        }

        public async Task<(ExecutionState executionState, PaginationResutl<DepartmentalTraining> entity, string message)> GetByFilterVM(DepartmentalTrainingFilterVM filter)
        {
            try
            {


                if (filter.sSearch != null)
                {
                    IQueryable<DepartmentalTraining> queryTotalSearch = _readOnlyCtx.Set<DepartmentalTraining>()
                   .OrderByDescending(x => x.Id);
                    IQueryable<DepartmentalTraining> querySearch = _readOnlyCtx.Set<DepartmentalTraining>()
                                     .Include(x => x.FinancialYear)
                                     .OrderByDescending(x => x.Id);

                    querySearch = querySearch.Where(x => x.TrainingTitle.Contains(filter.sSearch) || x.FinancialYear.Name.Contains(filter.sSearch) || x.Location.Contains(filter.sSearch));
                    var resultSearch = await querySearch.ToListAsync();
                    return (ExecutionState.Retrieved, new PaginationResutl<DepartmentalTraining>
                    {
                        aaData = resultSearch,
                        iTotalDisplayRecords = await queryTotalSearch.CountAsync(),
                        iTotalRecords = await queryTotalSearch.CountAsync(),
                    }, "Data returned successfully.");
                }



                //IQueryable<DepartmentalTraining> query = _readOnlyCtx.Set<DepartmentalTraining>()
                    //.OrderByDescending(x => x.Id);


                IQueryable<DepartmentalTraining> query;
                if (filter.iDisplayStart != null || filter.iDisplayLength != null)
                {
                    query = _readOnlyCtx.Set<DepartmentalTraining>()
                                      .OrderByDescending(x => x.Id)
                                      .Skip(filter.iDisplayStart ?? 0)
                                      .Take(filter.iDisplayLength ?? 0);
                }
                else
                {
                    query = _readOnlyCtx.Set<DepartmentalTraining>()
                                       .OrderByDescending(x => x.Id);
                }
                IQueryable<DepartmentalTraining> queryTotal = _readOnlyCtx.Set<DepartmentalTraining>()
               .OrderByDescending(x => x.Id);



                query = query.WhereIf(filter.HasFinancialYearId, x => x.FinancialYearId == filter.FinancialYearId);
                query = query.WhereIf(filter.HasEventTypeId, x => x.EventTypeId == filter.EventTypeId);

                query = query.WhereIf(filter.HasStartDate, x => x.StartDate >= filter.StartDate);
                query = query.WhereIf(filter.HasEndDate, x => x.EndDate <= filter.EndDate);

                query = query
                    .Include(x => x.FinancialYear!);

                var result = await query.ToListAsync();



                return (ExecutionState.Retrieved, new PaginationResutl<DepartmentalTraining>
                {
                    aaData = result,
                    iTotalDisplayRecords = await queryTotal.CountAsync(),
                    iTotalRecords = await queryTotal.CountAsync(),
                }, "Data returned successfully.");


                //return (ExecutionState.Retrieved, result, "Data returned successfully.");
            }
            catch (Exception)
            {
                return (ExecutionState.Failure, null!, "Unexpected error occurred.");
            }
        }

        public override async Task<(ExecutionState executionState, DepartmentalTraining entity, string message)> GetAsync(long id)
        {
            var filterOptions = new FilterOptions<DepartmentalTraining>
            {
                FilterExpression = x => x.Id == id,
                IncludeExpression = x => x
                    .Include(y => y.DepartmentalTrainingParticipentsMaps!)
                        .ThenInclude(ab => ab.DepartmentalTrainingMember)
                    .Include(y => y.DepartmentalTrainingFiles!)
                    .Include(y => y.FinancialYear!)
                    .Include(y => y.EventType!)
                    .Include(y => y.DepartmentalTrainingType!)
                    .Include(y => y.TrainingOrganizer!)
            };

            var result = await base.GetAsync(filterOptions);

            if (result.entity != null && result.entity.DepartmentalTrainingParticipentsMaps != null)
            {
                result.entity.DepartmentalTrainingParticipentsMaps =
                    result.entity.DepartmentalTrainingParticipentsMaps
                        .Where(x => x.IsActive && x.IsDeleted == false)
                        .Where(x =>
                             x.DepartmentalTrainingMember != null
                            )
                        .ToList();
            }

            return result;
        }

        public async Task<(ExecutionState executionState, bool isDeleted, string message)> DeleteParticipant(long DepartmentalTrainingParticipentsMapId)
        {
            (ExecutionState executionState, bool isDeleted, string message) returnResponse;

            try
            {
                var trainingParticipentsMap = await _unitOfWork.GetAsync(new FilterOptions<DepartmentalTrainingParticipentsMap>()
                {
                    FilterExpression = x => x.Id == DepartmentalTrainingParticipentsMapId,
                    IncludeExpression = x => x.Include(y => y.DepartmentalTrainingMember!)
                });
                if (trainingParticipentsMap.entity == null)
                {
                    returnResponse = (ExecutionState.Failure, false, "Invalid id");
                    return returnResponse;
                }

                var training = await _unitOfWork.GetAsync(new FilterOptions<DepartmentalTraining>()
                {
                    FilterExpression = x => x.Id == trainingParticipentsMap.entity.DepartmentalTrainingId,
                });
                if (training.entity == null)
                {
                    returnResponse = (ExecutionState.Failure, false, "Invalid id");
                    return returnResponse;
                }

                using (var transaction = _unitOfWork.Begin())
                {
                    trainingParticipentsMap.entity.IsDeleted = true;
                    trainingParticipentsMap.entity.IsActive = false;

                    if (trainingParticipentsMap.entity.DepartmentalTrainingMember?.MemberGender == Gender.Male)
                        training.entity.TotalMale -= 1;
                    if (trainingParticipentsMap.entity.DepartmentalTrainingMember?.MemberGender == Gender.Female)
                        training.entity.TotalFemale -= 1;
                    training.entity.TotalMembers -= 1;

                    await _unitOfWork.UpdateAsync(training.entity);
                    await _unitOfWork.UpdateAsync(trainingParticipentsMap.entity);
                    await _unitOfWork.SaveAsync(transaction);

                    await transaction.CommitAsync();
                }

                returnResponse = (ExecutionState.Success, true, "Deleted successfully");
                return returnResponse;
            }
            catch (Exception ex)
            {
                returnResponse = (ExecutionState.Failure, false, "Unexpected error occurred");
                return returnResponse;
            }
        }

        public override Task<(ExecutionState executionState, DepartmentalTraining entity, string message)> UpdateAsync(DepartmentalTraining entity)
        {
            var total = entity.DepartmentalTrainingParticipentsMaps?.Count ?? 0;
            var totalMale = entity.DepartmentalTrainingParticipentsMaps?.Where(x => x.DepartmentalTrainingMember?.MemberGender == Gender.Male).Count() ?? 0;
            var totalFemale = entity.DepartmentalTrainingParticipentsMaps?.Where(x => x.DepartmentalTrainingMember?.MemberGender == Gender.Female).Count() ?? 0;

            entity.TotalMembers = total;
            entity.TotalFemale = totalFemale;
            entity.TotalMale = totalMale;

            if (entity.DepartmentalTrainingParticipentsMaps != null)
            {
                foreach (var map in entity.DepartmentalTrainingParticipentsMaps)
                {
                    map.IsActive = !entity.IsDeleted;
                    map.IsDeleted = entity.IsDeleted;

                    if (map.DepartmentalTrainingMember != null)
                    {
                        map.DepartmentalTrainingMember.IsActive = !entity.IsDeleted;
                        map.DepartmentalTrainingMember.IsDeleted = entity.IsDeleted;
                    }
                }
            }

            if (entity.DepartmentalTrainingTypeId is null)
            {
                entity.DepartmentalTrainingTypeId = default(long?);
                entity.DepartmentalTrainingTypeId = null;
            }

            return base.UpdateAsync(entity);
        }

        public override Task<(ExecutionState executionState, DepartmentalTraining entity, string message)> CreateAsync(DepartmentalTraining entity)
        {
            var total = entity.DepartmentalTrainingParticipentsMaps?.Count ?? 0;
            var totalMale = entity.DepartmentalTrainingParticipentsMaps?.Where(x => x.DepartmentalTrainingMember?.MemberGender == Gender.Male).Count() ?? 0;
            var totalFemale = entity.DepartmentalTrainingParticipentsMaps?.Where(x => x.DepartmentalTrainingMember?.MemberGender == Gender.Female).Count() ?? 0;

            entity.TotalMembers = total;
            entity.TotalFemale = totalFemale;
            entity.TotalMale = totalMale;

            return base.CreateAsync(entity);
        }
    }
}
