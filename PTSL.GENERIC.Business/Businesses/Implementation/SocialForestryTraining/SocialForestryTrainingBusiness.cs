using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Business.BaseBusinesses;
using PTSL.GENERIC.Business.Businesses.Interface.SocialForestryTraining;
using PTSL.GENERIC.Common.Entity;
using PTSL.GENERIC.Common.Entity.Capacity;
using PTSL.GENERIC.Common.Entity.SocialForestryTraining;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Helper;
using PTSL.GENERIC.Common.Model.EntityViewModels.SocialForestryTraining;
using PTSL.GENERIC.Common.QuerySerialize.Implementation;
using PTSL.GENERIC.DAL.UnitOfWork;

namespace PTSL.GENERIC.Business.Businesses.Implementation.SocialForestryTraining
{
    public class SocialForestryTrainingBusiness : BaseBusiness<Common.Entity.SocialForestryTraining.SocialForestryTraining>, ISocialForestryTrainingBusiness
    {
        private readonly GENERICUnitOfWork _unitOfWork;
        private readonly GENERICReadOnlyCtx _readOnlyCtx;
        public SocialForestryTrainingBusiness(GENERICUnitOfWork unitOfWork, GENERICReadOnlyCtx readOnlyCtx)
            : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _readOnlyCtx = readOnlyCtx;
        }

        public override async Task<(ExecutionState executionState, Common.Entity.SocialForestryTraining.SocialForestryTraining entity, string message)> GetAsync(long id)
        {
            var filterOptions = new FilterOptions<Common.Entity.SocialForestryTraining.SocialForestryTraining>
            {
                FilterExpression = x => x.Id == id,
                IncludeExpression = x => x
                    .Include(y => y.SocialForestryTrainingParticipentsMaps!)
                        .ThenInclude(ab => ab.SocialForestryTrainingMember)
                    .Include(y => y.SocialForestryTrainingFiles!)
                    .Include(y => y.FinancialYearForTraining!)
                    .Include(y => y.EventTypeForTraining!)
                    .Include(y => y.TrainingOrganizerForTraining!)
            };

            var result = await base.GetAsync(filterOptions);

            if (result.entity != null && result.entity.SocialForestryTrainingParticipentsMaps != null)
            {
                result.entity.SocialForestryTrainingParticipentsMaps =
                    result.entity.SocialForestryTrainingParticipentsMaps
                        .Where(x => x.IsActive && x.IsDeleted == false)
                        .Where(x =>
                             x.SocialForestryTrainingMember != null
                            )
                        .ToList();
            }
            return result;
        }

        public override Task<(ExecutionState executionState, IQueryable<Common.Entity.SocialForestryTraining.SocialForestryTraining> entity, string message)> List(QueryOptions<Common.Entity.SocialForestryTraining.SocialForestryTraining> queryOptions = null)
        {
            queryOptions = new QueryOptions<Common.Entity.SocialForestryTraining.SocialForestryTraining>()
            {
                IncludeExpression = x => x.Include(y => y.FinancialYearForTraining!),
                SortingExpression = x => x.OrderByDescending(y => y.Id),
            };

            return base.List(queryOptions);
        }

        public override Task<(ExecutionState executionState, Common.Entity.SocialForestryTraining.SocialForestryTraining entity, string message)> CreateAsync(Common.Entity.SocialForestryTraining.SocialForestryTraining entity)
        {
            var total = entity.SocialForestryTrainingParticipentsMaps?.Count ?? 0;
            var totalMale = entity.SocialForestryTrainingParticipentsMaps?.Where(x => x.SocialForestryTrainingMember?.MemberGender == Gender.Male).Count() ?? 0;
            var totalFemale = entity.SocialForestryTrainingParticipentsMaps?.Where(x => x.SocialForestryTrainingMember?.MemberGender == Gender.Female).Count() ?? 0;

            entity.TotalMembers = total;
            entity.TotalFemale = totalFemale;
            entity.TotalMale = totalMale;

            return base.CreateAsync(entity);
        }

        public async Task<(ExecutionState executionState, bool isDeleted, string message)> DeleteParticipant(long SocialForestryTrainingParticipentsMapId)
        {
            (ExecutionState executionState, bool isDeleted, string message) returnResponse;

            try
            {
                var trainingParticipentsMap = await _unitOfWork.GetAsync(new FilterOptions<SocialForestryTrainingParticipentsMap>()
                {
                    FilterExpression = x => x.Id == SocialForestryTrainingParticipentsMapId,
                    IncludeExpression = x => x.Include(y => y.SocialForestryTrainingMember!)
                });
                if (trainingParticipentsMap.entity == null)
                {
                    returnResponse = (ExecutionState.Failure, false, "Invalid id");
                    return returnResponse;
                }

                var training = await _unitOfWork.GetAsync(new FilterOptions<Common.Entity.SocialForestryTraining.SocialForestryTraining>()
                {
                    FilterExpression = x => x.Id == trainingParticipentsMap.entity.SocialForestryTrainingId,
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

                    if (trainingParticipentsMap.entity.SocialForestryTrainingMember?.MemberGender == Gender.Male)
                        training.entity.TotalMale -= 1;
                    if (trainingParticipentsMap.entity.SocialForestryTrainingMember?.MemberGender == Gender.Female)
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

        public override Task<(ExecutionState executionState, Common.Entity.SocialForestryTraining.SocialForestryTraining entity, string message)> UpdateAsync(Common.Entity.SocialForestryTraining.SocialForestryTraining entity)
        {
            var total = entity.SocialForestryTrainingParticipentsMaps?.Count ?? 0;
            var totalMale = entity.SocialForestryTrainingParticipentsMaps?.Where(x => x.SocialForestryTrainingMember?.MemberGender == Gender.Male).Count() ?? 0;
            var totalFemale = entity.SocialForestryTrainingParticipentsMaps?.Where(x => x.SocialForestryTrainingMember?.MemberGender == Gender.Female).Count() ?? 0;

            entity.TotalMembers = total;
            entity.TotalFemale = totalFemale;
            entity.TotalMale = totalMale;

            if (entity.SocialForestryTrainingParticipentsMaps != null)
            {
                foreach (var map in entity.SocialForestryTrainingParticipentsMaps)
                {
                    map.IsActive = !entity.IsDeleted;
                    map.IsDeleted = entity.IsDeleted;

                    if (map.SocialForestryTrainingMember != null)
                    {
                        map.SocialForestryTrainingMember.IsActive = !entity.IsDeleted;
                        map.SocialForestryTrainingMember.IsDeleted = entity.IsDeleted;
                    }
                }
            }

            //if (entity.DepartmentalTrainingTypeId is null)
            //{
            //    entity.DepartmentalTrainingTypeId = default(long?);
            //    entity.DepartmentalTrainingTypeId = null;
            //}

            return base.UpdateAsync(entity);
        }

        public async Task<(ExecutionState executionState, IList<Common.Entity.SocialForestryTraining.SocialForestryTraining> entity, string message)> GetByFilterVM(SocialForestryTrainingFilterVM filter)
        {
            try
            {
                IQueryable<Common.Entity.SocialForestryTraining.SocialForestryTraining> query = _readOnlyCtx.Set<Common.Entity.SocialForestryTraining.SocialForestryTraining>()
                    .OrderByDescending(x => x.Id);

                query = query.WhereIf(filter.HasFinancialYearId, x => x.FinancialYearForTrainingId == filter.FinancialYearForTrainingId);
                query = query.WhereIf(filter.HasEventTypeId, x => x.EventTypeForTrainingId == filter.EventTypeForTrainingId);

                query = query.WhereIf(filter.HasStartDate, x => x.StartDate >= filter.StartDate);
                query = query.WhereIf(filter.HasEndDate, x => x.EndDate <= filter.EndDate);

                query = query
                    .Include(x => x.FinancialYearForTraining!);

                var result = await query.ToListAsync();

                return (ExecutionState.Retrieved, result, "Data returned successfully.");
            }
            catch (Exception)
            {
                return (ExecutionState.Failure, null!, "Unexpected error occurred.");
            }
        }


    }
}