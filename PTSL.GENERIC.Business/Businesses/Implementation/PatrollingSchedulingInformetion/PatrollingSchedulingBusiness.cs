using Microsoft.EntityFrameworkCore;
using PTSL.GENERIC.Business.BaseBusinesses;
using PTSL.GENERIC.Business.Businesses.Interface.Capacity;
using PTSL.GENERIC.Business.Businesses.Interface.PatrollingSchedulingInformetion;
using PTSL.GENERIC.Common.Entity;
using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Entity.Capacity;
using PTSL.GENERIC.Common.Entity.Labour;
using PTSL.GENERIC.Common.Entity.PatrollingSchedulingInformetion;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Enum.Capacity;
using PTSL.GENERIC.Common.Helper;
using PTSL.GENERIC.Common.Model.CustomModel;
using PTSL.GENERIC.Common.Model.EntityViewModels.Capacity;
using PTSL.GENERIC.Common.Model.EntityViewModels.PatrollingSchedulingInformetion;
using PTSL.GENERIC.Common.QuerySerialize.Implementation;
using PTSL.GENERIC.DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTSL.GENERIC.Business.Businesses.Implementation.PatrollingSchedulingInformetion
{
    public class PatrollingSchedulingBusiness : BaseBusiness<PatrollingScheduling>, IPatrollingSchedulingBusiness
    {
        public readonly GENERICUnitOfWork _unitOfWork;
        public readonly GENERICWriteOnlyCtx _context;
        private readonly GENERICReadOnlyCtx _readOnlyCtx;

        public PatrollingSchedulingBusiness(GENERICUnitOfWork unitOfWork, GENERICWriteOnlyCtx context, GENERICReadOnlyCtx readOnlyCtx)
            : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _context = context;
            _readOnlyCtx = readOnlyCtx;
        }

        public override Task<(ExecutionState executionState, IQueryable<PatrollingScheduling> entity, string message)> List(QueryOptions<PatrollingScheduling> queryOptions = null)
        {
            queryOptions = new QueryOptions<PatrollingScheduling>
            {
                SortingExpression = x => x.OrderByDescending(y => y.Id)
            };

            return base.List(queryOptions);
        }

        public async Task<(ExecutionState executionState, PaginationResutl<PatrollingScheduling> entity, string message)> GetTrainingByFilter(PatrollingSchedulingFilterVM filter)
        {
            try
            {
                if (filter is null) return (ExecutionState.Retrieved, new PaginationResutl<PatrollingScheduling>(), "Data returned successfully.");

                //IQueryable<PatrollingScheduling> query = _context.Set<PatrollingScheduling>()
                //    .OrderByDescending(x => x.Id);

                if (filter.sSearch != null)
                {
                    IQueryable<PatrollingScheduling> queryTotalSearch = _readOnlyCtx.Set<PatrollingScheduling>()
                   .OrderByDescending(x => x.Id);
                    IQueryable<PatrollingScheduling> querySearch = _readOnlyCtx.Set<PatrollingScheduling>()
                                     .OrderByDescending(x => x.Id);

                    querySearch = querySearch.Where(x => x.PatrollingArea.Contains(filter.sSearch));
                    var resultSearch = await querySearch.ToListAsync();
                    return (ExecutionState.Retrieved, new PaginationResutl<PatrollingScheduling>
                    {
                        aaData = resultSearch,
                        iTotalDisplayRecords = await queryTotalSearch.CountAsync(),
                        iTotalRecords = await queryTotalSearch.CountAsync(),
                    }, "Data returned successfully.");
                }


                IQueryable<PatrollingScheduling> query;
                if (filter.iDisplayStart != null || filter.iDisplayLength != null)
                {
                    query = _readOnlyCtx.Set<PatrollingScheduling>()
                                      .OrderByDescending(x => x.Id)
                                      .Skip(filter.iDisplayStart ?? 0)
                                      .Take(filter.iDisplayLength ?? 0);
                }
                else
                {
                    query = _readOnlyCtx.Set<PatrollingScheduling>()
                                       .OrderByDescending(x => x.Id);
                }
                IQueryable<PatrollingScheduling> queryTotal = _readOnlyCtx.Set<PatrollingScheduling>()
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

                //Extra Filter
                if (filter?.NgoId > 0)
                {
                    query = query.Where(x => x.NgoId == filter.NgoId);
                }


                // Others
                //if (filter?.EventTypeId != null && filter?.EventTypeId > 0)
                //{
                //    query = query.Where(x => x.EventTypeId == filter.EventTypeId);
                //}
                //if (filter?.CommunityTrainingTypeId != null && filter?.CommunityTrainingTypeId > 0)
                //{
                //    query = query.Where(x => x.CommunityTrainingTypeId == filter.CommunityTrainingTypeId);
                //}
                //if (filter?.TrainingOrganizerId != null && filter?.TrainingOrganizerId > 0)
                //{
                //    query = query.Where(x => x.TrainingOrganizerId == filter.TrainingOrganizerId);
                //}

                //if (filter?.StartDate != null)
                //{
                //    query = query.Where(x => x.StartDate >= filter.StartDate);
                //}
                //if (filter?.EndDate != null)
                //{
                //    query = query.Where(x => x.EndDate <= filter.EndDate);
                //}

                var result = await query.ToListAsync();



                return (ExecutionState.Retrieved, new PaginationResutl<PatrollingScheduling>
                {
                    aaData = result,
                    iTotalDisplayRecords = await queryTotal.CountAsync(),
                    iTotalRecords = await queryTotal.CountAsync(),
                }, "Data returned successfully.");


                //return (ExecutionState.Retrieved, result, "Data returned successfully.");
            }
            catch (Exception ex)
            {
                return (ExecutionState.Failure, new PaginationResutl<PatrollingScheduling>()!, "Unexpected error occurred.");
            }
        }

        public async Task<(ExecutionState executionState, bool isDeleted, string message)> DeleteParticipant(long patrollingSchedulingParticipentsMapId)
        {
            (ExecutionState executionState, bool isDeleted, string message) returnResponse;

            try
            {
                var trainingParticipentsMap = await _unitOfWork.GetAsync(new FilterOptions<PatrollingSchedulingParticipentsMap>()
                {
                    FilterExpression = x => x.Id == patrollingSchedulingParticipentsMapId,
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

        public override async Task<(ExecutionState executionState, PatrollingScheduling entity, string message)> GetAsync(long id)
        {
            var filterOptions = new FilterOptions<PatrollingScheduling>
            {
                FilterExpression = x => x.Id == id,
                IncludeExpression = x => x
                    .Include(x => x.ForestCircle)
                    .Include(x => x.ForestDivision)
                    .Include(x => x.ForestRange)
                    .Include(x => x.ForestBeat)
                    .Include(x => x.ForestFcvVcf)
                    .Include(x => x.Division)
                    .Include(x => x.District)
                    .Include(x => x.Upazilla)
                    .Include(x => x.Union)
                    .Include(x=>x.Ngos)
                    .Include(y => y.PatrollingSchedulingParticipentsMaps!)
                        .ThenInclude(ab => ab.Survey)
                    .Include(y => y.PatrollingSchedulingParticipentsMaps!)
                        .ThenInclude(ab => ab.PatrollingSchedulingMember)
                    .Include(y => y.PatrollingSchedulingFiles!)
            };

            var result = await base.GetAsync(filterOptions);

            if (result.entity != null && result.entity.PatrollingSchedulingParticipentsMaps != null)
            {
                result.entity.PatrollingSchedulingParticipentsMaps =
                    result.entity.PatrollingSchedulingParticipentsMaps
                        .Where(x => x.IsActive && x.IsDeleted == false)
                        .Where(x => 
                            (x.ParticipentType == ParticipentType.Member && x.PatrollingSchedulingMember != null)
                            || (x.ParticipentType == ParticipentType.Beneficiary && x.Survey != null)
                            )
                        .ToList();
            }

            return result;
        }

        public override async Task<(ExecutionState executionState, PatrollingScheduling entity, string message)> CreateAsync(PatrollingScheduling entity)
        {
            await SetMaleFemale(entity);

            AddParticipantType(ref entity);

            return await base.CreateAsync(entity);
        }

        public override async Task<(ExecutionState executionState, PatrollingScheduling entity, string message)> UpdateAsync(PatrollingScheduling entity)
        {
            await SetMaleFemale(entity);

            if (entity.PatrollingSchedulingParticipentsMaps != null)
            {
                foreach (var map in entity.PatrollingSchedulingParticipentsMaps)
                {
                    map.IsActive = !entity.IsDeleted;
                    map.IsDeleted = entity.IsDeleted;

                    if (map.PatrollingSchedulingMember != null)
                    {
                        map.PatrollingSchedulingMember.IsActive = !entity.IsDeleted;
                        map.PatrollingSchedulingMember.IsDeleted = entity.IsDeleted;
                    }
                }
            }

            AddParticipantType(ref entity);

            return await base.UpdateAsync(entity);
        }

        private async Task SetMaleFemale(PatrollingScheduling entity)
        {
            var surveyIds = entity.PatrollingSchedulingParticipentsMaps?.Select(x => x.SurveyId).ToList() ?? new List<long?>();
            var surveyGenders = await _readOnlyCtx.Set<Survey>().Where(x => surveyIds.Contains(x.Id)).Select(x => x.BeneficiaryGender).ToListAsync();

            var surveyTotalMale = surveyGenders.Count(x => x == Gender.Male);
            var surveyTotalFemale = surveyGenders.Count(x => x == Gender.Female);
            var otherTotalMale = entity.PatrollingSchedulingParticipentsMaps?.Where(x => x.PatrollingSchedulingMember?.MemberGender == Gender.Male).Count() ?? 0;
            var otherTotalFemale = entity.PatrollingSchedulingParticipentsMaps?.Where(x => x.PatrollingSchedulingMember?.MemberGender == Gender.Female).Count() ?? 0;

            var total = entity.PatrollingSchedulingParticipentsMaps?.Count ?? 0;

            entity.TotalParticipants = total;
            entity.TotalMale = otherTotalMale + surveyTotalMale;
            entity.TotalFemale = otherTotalFemale + surveyTotalFemale;
        }

        private void AddParticipantType(ref PatrollingScheduling entity)
        {
            if (entity.PatrollingSchedulingParticipentsMaps == null)
                return;

            entity.PatrollingSchedulingParticipentsMaps =
                entity.PatrollingSchedulingParticipentsMaps
                    .Where(x => x.PatrollingSchedulingMember != null || (x.SurveyId != null && x.SurveyId > 0))
                    .ToList();

            if (entity.PatrollingSchedulingParticipentsMaps != null && entity.PatrollingSchedulingParticipentsMaps.Count > 0)
            {
                foreach (var participentsMap in entity.PatrollingSchedulingParticipentsMaps)
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
    }
}
