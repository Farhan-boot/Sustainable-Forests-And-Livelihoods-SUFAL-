using Microsoft.EntityFrameworkCore;
using PTSL.GENERIC.Business.BaseBusinesses;
using PTSL.GENERIC.Business.Businesses.Interface.Capacity;
using PTSL.GENERIC.Common.Entity;
using PTSL.GENERIC.Common.Entity.AIG;
using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Entity.Capacity;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Enum.Capacity;
using PTSL.GENERIC.Common.Helper;
using PTSL.GENERIC.Common.Model.EntityViewModels;
using PTSL.GENERIC.Common.Model.EntityViewModels.AIG;
using PTSL.GENERIC.Common.Model.EntityViewModels.Capacity;
using PTSL.GENERIC.Common.Model.EntityViewModels.Common;
using PTSL.GENERIC.Common.QuerySerialize.Implementation;
using PTSL.GENERIC.DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PTSL.GENERIC.Common.Model.CustomModel;

namespace PTSL.GENERIC.Business.Businesses.Implementation.Capacity
{
    public class CommunityTrainingBusiness : BaseBusiness<CommunityTraining>, ICommunityTrainingBusiness
    {
        public readonly GENERICUnitOfWork _unitOfWork;
        public readonly GENERICWriteOnlyCtx _context;
        private readonly GENERICReadOnlyCtx _readOnlyCtx;

        public CommunityTrainingBusiness(GENERICUnitOfWork unitOfWork, GENERICWriteOnlyCtx context, GENERICReadOnlyCtx readOnlyCtx)
            : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _context = context;
            _readOnlyCtx = readOnlyCtx;
        }

        public override Task<(ExecutionState executionState, IQueryable<CommunityTraining> entity, string message)> List(QueryOptions<CommunityTraining> queryOptions = null)
        {
            queryOptions = new QueryOptions<CommunityTraining>
            {
                SortingExpression = x => x.OrderByDescending(y => y.Id),
                IncludeExpression = e => e.Include(x => x.EventType!).Include(x => x.TrainingOrganizer!)
            };

            return base.List(queryOptions);
        }

        public async Task<(ExecutionState executionState, PaginationResutl<CommunityTraining> entity, string message)> GetTrainingByFilter(CommunityTrainingFilterVM filter)
        {
            try
            {
                if (filter is null) return (ExecutionState.Retrieved, new PaginationResutl<CommunityTraining>(), "Data returned successfully.");

                if (filter.sSearch != null)
                {
                    IQueryable<CommunityTraining> queryTotalSearch = _readOnlyCtx.Set<CommunityTraining>()
                   .OrderByDescending(x => x.Id);
                    IQueryable<CommunityTraining> querySearch = _readOnlyCtx.Set<CommunityTraining>()
                                     .Include(x => x.EventType)
                                     .Include(x => x.TrainingOrganizer)
                                     .OrderByDescending(x => x.Id);

                    querySearch = querySearch.Where(x => x.TrainingTitle.Contains(filter.sSearch) || x.TrainingOrganizer.Name.Contains(filter.sSearch) || x.EventType.Name.Contains(filter.sSearch) || x.TrainingDuration.Contains(filter.sSearch) || x.Location.Contains(filter.sSearch));
                    var resultSearch = await querySearch.ToListAsync();
                    return (ExecutionState.Retrieved, new PaginationResutl<CommunityTraining>
                    {
                        aaData = resultSearch,
                        iTotalDisplayRecords = await queryTotalSearch.CountAsync(),
                        iTotalRecords = await queryTotalSearch.CountAsync(),
                    }, "Data returned successfully.");
                }


                //IQueryable<CommunityTraining> query = _context.Set<CommunityTraining>()
                // .OrderByDescending(x => x.Id);

                IQueryable<CommunityTraining> query;
                if (filter.iDisplayStart != null || filter.iDisplayLength != null)
                {
                    query = _readOnlyCtx.Set<CommunityTraining>()
                                     //.Include(x => x.EventType!)
                                     //.Include(x => x.TrainingOrganizer!)
                                     .OrderByDescending(x => x.Id)
                                     .Skip(filter.iDisplayStart ?? 0)
                                     .Take(filter.iDisplayLength ?? 0);
                }
                else
                {
                    query = _readOnlyCtx.Set<CommunityTraining>()
                                       //.Include(x => x.EventType!)
                                       //.Include(x => x.TrainingOrganizer!)
                                       .OrderByDescending(x => x.Id);
                }
                IQueryable<CommunityTraining> queryTotal = _readOnlyCtx.Set<CommunityTraining>()
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
                query = query.WhereIf(filter.HasTrainingOrganizerId, x => x.TrainingOrganizerId == filter.TrainingOrganizerId);
                query = query.WhereIf(filter.HasStartDate, x => x.StartDate >= filter.StartDate);
                query = query.WhereIf(filter.HasEndDate, x => x.EndDate <= filter.EndDate);
                query = query.WhereIf(filter.HasEventTypeId, x => x.EventTypeId == filter.EventTypeId);


                var result = new List<CommunityTraining>();
                if (query.Any(x=>x.EventTypeId == null) || query.Any(x=>x.TrainingOrganizerId == null) )
                {
                    result = await query
                       .ToListAsync();
                }
                else
                {
                    result = await query
                                     .Include(x => x.EventType)
                                     .Include(x => x.TrainingOrganizer)
                                     .ToListAsync();
                }




                return (ExecutionState.Retrieved, new PaginationResutl<CommunityTraining>
                {
                    aaData = result,
                    iTotalDisplayRecords = await queryTotal.CountAsync(),
                    iTotalRecords = await queryTotal.CountAsync(),
                }, "Data returned successfully.");


                //return (ExecutionState.Retrieved, result, "Data returned successfully.");
            }
            catch (Exception ex)
            {
                return (ExecutionState.Failure, new PaginationResutl<CommunityTraining>()!, "Unexpected error occurred.");
            }
        }

        public async Task<(ExecutionState executionState, bool isDeleted, string message)> DeleteParticipant(long communityTrainingParticipentsMapId)
        {
            (ExecutionState executionState, bool isDeleted, string message) returnResponse;

            try
            {
                var trainingParticipentsMap = await _unitOfWork.GetAsync(new FilterOptions<CommunityTrainingParticipentsMap>()
                {
                    FilterExpression = x => x.Id == communityTrainingParticipentsMapId,
                });

                if (trainingParticipentsMap.entity == null)
                {
                    returnResponse = (ExecutionState.Failure, false, "Invalid id");
                    return returnResponse;
                }

                using (var transaction = _unitOfWork.Begin())
                {
                    trainingParticipentsMap.entity.IsDeleted = true;
                    trainingParticipentsMap.entity.IsActive = false;

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

        public override async Task<(ExecutionState executionState, CommunityTraining entity, string message)> GetAsync(long id)
        {
            var result = await _readOnlyCtx.Set<CommunityTraining>()
                .Include(x => x.ForestCircle)
                .Include(x => x.ForestDivision)
                .Include(x => x.ForestRange)
                .Include(x => x.ForestBeat)
                .Include(x => x.ForestFcvVcf)
                .Include(x => x.Division)
                .Include(x => x.District)
                .Include(x => x.Upazilla)
                .Include(x => x.Union)
                .Include(x => x.EventType)
                .Include(x => x.CommunityTrainingType)
                .Include(x => x.TrainingOrganizer)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (result == null) return (ExecutionState.Failure, null!, "Not found");

            var participants = await _readOnlyCtx.Set<CommunityTrainingParticipentsMap>()
                .Where(x => x.CommunityTrainingId == id)
                .Include(x => x.Survey)
                .Include(x => x.CommunityTrainingMember)
                .ToListAsync();

            var files = await _readOnlyCtx.Set<CommunityTrainingFile>()
                .Where(x => x.CommunityTrainingId == id)
                .ToListAsync();

            result.CommunityTrainingParticipentsMaps = participants;
            result.CommunityTrainingFiles = files;

            //if (result != null && result.CommunityTrainingParticipentsMaps != null)
            //{
            //    result.CommunityTrainingParticipentsMaps =
            //        result.CommunityTrainingParticipentsMaps
            //            .Where(x => x.IsActive && x.IsDeleted == false)
            //            .Where(x => 
            //                (x.ParticipentType == ParticipentType.Member && x.CommunityTrainingMember != null)
            //                || (x.ParticipentType == ParticipentType.Beneficiary && x.Survey != null)
            //                )
            //            .ToList();
            //}

            return (ExecutionState.Retrieved, result!, "Retrieved successfully");
        }

        public override async Task<(ExecutionState executionState, CommunityTraining entity, string message)> CreateAsync(CommunityTraining entity)
        {
            await SetMaleFemale(entity);

            AddParticipantType(ref entity);

            return await base.CreateAsync(entity);
        }

        public override async Task<(ExecutionState executionState, CommunityTraining entity, string message)> UpdateAsync(CommunityTraining entity)
        {
            await SetMaleFemale(entity);

            if (entity.CommunityTrainingParticipentsMaps != null)
            {
                foreach (var map in entity.CommunityTrainingParticipentsMaps)
                {
                    map.IsActive = !entity.IsDeleted;
                    map.IsDeleted = entity.IsDeleted;

                    if (map.CommunityTrainingMember != null)
                    {
                        map.CommunityTrainingMember.IsActive = !entity.IsDeleted;
                        map.CommunityTrainingMember.IsDeleted = entity.IsDeleted;
                    }
                }
            }

            AddParticipantType(ref entity);

            return await base.UpdateAsync(entity);
        }

        private async Task SetMaleFemale(CommunityTraining entity)
        {
            var surveyIds = entity.CommunityTrainingParticipentsMaps?.Select(x => x.SurveyId).ToList() ?? new List<long?>();
            var surveyGenders = await _readOnlyCtx.Set<Survey>().Where(x => surveyIds.Contains(x.Id)).Select(x => x.BeneficiaryGender).ToListAsync();

            var surveyTotalMale = surveyGenders.Count(x => x == Gender.Male);
            var surveyTotalFemale = surveyGenders.Count(x => x == Gender.Female);
            var otherTotalMale = entity.CommunityTrainingParticipentsMaps?.Where(x => x.CommunityTrainingMember?.MemberGender == Gender.Male).Count() ?? 0;
            var otherTotalFemale = entity.CommunityTrainingParticipentsMaps?.Where(x => x.CommunityTrainingMember?.MemberGender == Gender.Female).Count() ?? 0;

            var total = entity.CommunityTrainingParticipentsMaps?.Count ?? 0;

            entity.TotalParticipants = total;
            entity.TotalMale = otherTotalMale + surveyTotalMale;
            entity.TotalFemale = otherTotalFemale + surveyTotalFemale;
        }

        private void AddParticipantType(ref CommunityTraining entity)
        {
            if (entity.CommunityTrainingParticipentsMaps == null)
                return;

            entity.CommunityTrainingParticipentsMaps =
                entity.CommunityTrainingParticipentsMaps
                    .Where(x => x.CommunityTrainingMember != null || (x.SurveyId != null && x.SurveyId > 0))
                    .ToList();

            if (entity.CommunityTrainingParticipentsMaps != null && entity.CommunityTrainingParticipentsMaps.Count > 0)
            {
                foreach (var participentsMap in entity.CommunityTrainingParticipentsMaps)
                {
                    if (participentsMap.SurveyId != null && participentsMap.SurveyId > 0)
                    {
                        participentsMap.ParticipentType = ParticipentType.Beneficiary;
                    }
                    else
                    {
                        participentsMap.ParticipentType = ParticipentType.Member;
                    }
                }
            }
        }

        /*
        public async Task<(ExecutionState executionState, CommunityTraining entity, string message)> BeneficiarySkillPercentage(ForestCivilLocationFilter filter)
        {

        }
        */
    }
}
