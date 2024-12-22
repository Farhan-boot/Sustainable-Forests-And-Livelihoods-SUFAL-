using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Business.BaseBusinesses;
using PTSL.GENERIC.Business.Businesses.Interface.SocialForestryMeeting;
using PTSL.GENERIC.Common.Entity;
using PTSL.GENERIC.Common.Entity.SocialForestryMeeting;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Helper;
using PTSL.GENERIC.Common.Model.EntityViewModels.SocialForestryTraining;
using PTSL.GENERIC.Common.QuerySerialize.Implementation;
using PTSL.GENERIC.DAL.UnitOfWork;

namespace PTSL.GENERIC.Business.Businesses.Implementation.SocialForestryMeeting
{
    public class  SocialForestryMeetingBusiness : BaseBusiness<Common.Entity.SocialForestryMeeting.SocialForestryMeeting>, ISocialForestryMeetingBusiness
    {
        private readonly GENERICUnitOfWork _unitOfWork;
        private readonly GENERICReadOnlyCtx _readOnlyCtx;
        public  SocialForestryMeetingBusiness(GENERICUnitOfWork unitOfWork, GENERICReadOnlyCtx readOnlyCtx)
            : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _readOnlyCtx = readOnlyCtx;
        }

        public override async Task<(ExecutionState executionState, Common.Entity.SocialForestryMeeting.SocialForestryMeeting entity, string message)> GetAsync(long id)
        {
            var filterOptions = new FilterOptions<Common.Entity.SocialForestryMeeting.SocialForestryMeeting>
            {
                FilterExpression = x => x.Id == id,
                IncludeExpression = x => x
                    .Include(y => y.SocialForestryMeetingParticipentsMaps!)
                        .ThenInclude(ab => ab.SocialForestryMeetingMember)
                    .Include(y => y.SocialForestryMeetingFiles!)
                    .Include(y => y.Ngo!)
                    .Include(y => y.MeetingTypeForSocialForestryMeeting!)
            };

            var result = await base.GetAsync(filterOptions);

            if (result.entity != null && result.entity.SocialForestryMeetingParticipentsMaps != null)
            {
                result.entity.SocialForestryMeetingParticipentsMaps =
                    result.entity.SocialForestryMeetingParticipentsMaps
                        .Where(x => x.IsActive && x.IsDeleted == false)
                        .Where(x =>
                             x.SocialForestryMeetingMember != null
                            )
                        .ToList();
            }
            return result;
        }

        public override Task<(ExecutionState executionState, IQueryable<Common.Entity.SocialForestryMeeting.SocialForestryMeeting> entity, string message)> List(QueryOptions<Common.Entity.SocialForestryMeeting.SocialForestryMeeting> queryOptions = null)
        {
            queryOptions = new QueryOptions<Common.Entity.SocialForestryMeeting.SocialForestryMeeting>()
            {
                IncludeExpression = x => x.Include(y => y.MeetingTypeForSocialForestryMeeting!)
                .Include(y => y.Ngo!),
                SortingExpression = x => x.OrderByDescending(y => y.Id),
            };

            return base.List(queryOptions);
        }

        public override Task<(ExecutionState executionState, Common.Entity.SocialForestryMeeting.SocialForestryMeeting entity, string message)> CreateAsync(Common.Entity.SocialForestryMeeting.SocialForestryMeeting entity)
        {
            var total = entity.SocialForestryMeetingParticipentsMaps?.Count ?? 0;
            var totalMale = entity.SocialForestryMeetingParticipentsMaps?.Where(x => x.SocialForestryMeetingMember?.MemberGender == Gender.Male).Count() ?? 0;
            var totalFemale = entity.SocialForestryMeetingParticipentsMaps?.Where(x => x.SocialForestryMeetingMember?.MemberGender == Gender.Female).Count() ?? 0;

            entity.TotalMembers = total;
            entity.TotalFemale = totalFemale;
            entity.TotalMale = totalMale;

            return base.CreateAsync(entity);
        }


        public async Task<(ExecutionState executionState, bool isDeleted, string message)> DeleteParticipant(long SocialForestryMeetingParticipentsMapId)
        {
            (ExecutionState executionState, bool isDeleted, string message) returnResponse;

            try
            {
                var trainingParticipentsMap = await _unitOfWork.GetAsync(new FilterOptions<SocialForestryMeetingParticipentsMap>()
                {
                    FilterExpression = x => x.Id == SocialForestryMeetingParticipentsMapId,
                    IncludeExpression = x => x.Include(y => y.SocialForestryMeetingMember!)
                });
                if (trainingParticipentsMap.entity == null)
                {
                    returnResponse = (ExecutionState.Failure, false, "Invalid id");
                    return returnResponse;
                }

                var training = await _unitOfWork.GetAsync(new FilterOptions<Common.Entity.SocialForestryMeeting.SocialForestryMeeting>()
                {
                    FilterExpression = x => x.Id == trainingParticipentsMap.entity.SocialForestryMeetingId,
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

                    if (trainingParticipentsMap.entity.SocialForestryMeetingMember?.MemberGender == Gender.Male)
                        training.entity.TotalMale -= 1;
                    if (trainingParticipentsMap.entity.SocialForestryMeetingMember?.MemberGender == Gender.Female)
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

        public override Task<(ExecutionState executionState, Common.Entity.SocialForestryMeeting.SocialForestryMeeting entity, string message)> UpdateAsync(Common.Entity.SocialForestryMeeting.SocialForestryMeeting entity)
        {
            var total = entity.SocialForestryMeetingParticipentsMaps?.Count ?? 0;
            var totalMale = entity.SocialForestryMeetingParticipentsMaps?.Where(x => x.SocialForestryMeetingMember?.MemberGender == Gender.Male).Count() ?? 0;
            var totalFemale = entity.SocialForestryMeetingParticipentsMaps?.Where(x => x.SocialForestryMeetingMember?.MemberGender == Gender.Female).Count() ?? 0;

            entity.TotalMembers = total;
            entity.TotalFemale = totalFemale;
            entity.TotalMale = totalMale;

            if (entity.SocialForestryMeetingParticipentsMaps != null)
            {
                foreach (var map in entity.SocialForestryMeetingParticipentsMaps)
                {
                    map.IsActive = !entity.IsDeleted;
                    map.IsDeleted = entity.IsDeleted;

                    if (map.SocialForestryMeetingMember != null)
                    {
                        map.SocialForestryMeetingMember.IsActive = !entity.IsDeleted;
                        map.SocialForestryMeetingMember.IsDeleted = entity.IsDeleted;
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

        //public async Task<(ExecutionState executionState, IList<Common.Entity.SocialForestryMeeting.SocialForestryMeeting> entity, string message)> GetByFilterVM(SocialForestryMeetingFilterVM filter)
        //{
        //    try
        //    {
        //        IQueryable<Common.Entity.SocialForestryMeeting.SocialForestryMeeting> query = _readOnlyCtx.Set<Common.Entity.SocialForestryMeeting.SocialForestryMeeting>()
        //            .OrderByDescending(x => x.Id);

        //        query = query.WhereIf(filter.HasFinancialYearId, x => x.FinancialYearForTrainingId == filter.FinancialYearForTrainingId);
        //        query = query.WhereIf(filter.HasEventTypeId, x => x.EventTypeForTrainingId == filter.EventTypeForTrainingId);

        //        query = query.WhereIf(filter.HasStartDate, x => x.StartDate >= filter.StartDate);
        //        query = query.WhereIf(filter.HasEndDate, x => x.EndDate <= filter.EndDate);

        //        query = query
        //            .Include(x => x.FinancialYearForTraining!);

        //        var result = await query.ToListAsync();

        //        return (ExecutionState.Retrieved, result, "Data returned successfully.");
        //    }
        //    catch (Exception)
        //    {
        //        return (ExecutionState.Failure, null!, "Unexpected error occurred.");
        //    }
        //}


    }
}