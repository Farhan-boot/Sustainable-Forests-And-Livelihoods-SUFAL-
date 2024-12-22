using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Business.BaseBusinesses;
using PTSL.GENERIC.Business.Businesses.Interface;
using PTSL.GENERIC.Common.Entity;
using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Entity.Labour;
using PTSL.GENERIC.Common.Entity.MeetingManagement;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Enum.Capacity;
using PTSL.GENERIC.Common.Helper;
using PTSL.GENERIC.Common.Model.CustomModel;
using PTSL.GENERIC.Common.Model.EntityViewModels.Capacity;
using PTSL.GENERIC.Common.QuerySerialize.Implementation;
using PTSL.GENERIC.DAL.UnitOfWork;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTSL.GENERIC.Business.Businesses.Implementation
{
    public class MeetingBusiness : BaseBusiness<Meeting>, IMeetingBusiness
    {
        public readonly GENERICUnitOfWork _unitOfWork;
        private readonly GENERICReadOnlyCtx _readOnlyCtx;

        public MeetingBusiness(GENERICUnitOfWork unitOfWork, GENERICReadOnlyCtx context)
            : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _readOnlyCtx = context;
        }

        public override Task<(ExecutionState executionState, IQueryable<Meeting> entity, string message)> List(QueryOptions<Meeting> queryOptions = null)
        {
            return base.List(new QueryOptions<Meeting>()
            {
                IncludeExpression = e => e.Include(x => x.MeetingType!),
                SortingExpression = x => x.OrderByDescending(y => y.Id)
            });
        }

        public async Task<(ExecutionState executionState, PaginationResutl<Meeting> entity, string message)> GetMeetingByFilter(MeetingFilterVM filter)
        {
            try
            {

                if (filter.sSearch != null)
                {
                    IQueryable<Meeting> queryTotalSearch = _readOnlyCtx.Set<Meeting>()
                   .OrderByDescending(x => x.Id);
                    IQueryable<Meeting> querySearch = _readOnlyCtx.Set<Meeting>()
                                     .Include(x => x.MeetingType!)
                                     .OrderByDescending(x => x.Id);

                    querySearch = querySearch.Where(x => x.MeetingTitle.Contains(filter.sSearch) || x.MeetingType.Name.Contains(filter.sSearch));
                    var resultSearch = await querySearch.ToListAsync();
                    return (ExecutionState.Retrieved, new PaginationResutl<Meeting>
                    {
                        aaData = resultSearch,
                        iTotalDisplayRecords = await queryTotalSearch.CountAsync(),
                        iTotalRecords = await queryTotalSearch.CountAsync(),
                    }, "Data returned successfully.");
                }



                //IQueryable<Meeting> query = _readOnlyCtx.Set<Meeting>().OrderByDescending(x => x.Id);

                IQueryable<Meeting> query;
                if (filter.iDisplayStart != null || filter.iDisplayLength != null)
                {
                    query = _readOnlyCtx.Set<Meeting>()
                                      .Include(x => x.MeetingType!)
                                      .OrderByDescending(x => x.Id)
                                      .Skip(filter.iDisplayStart ?? 0)
                                      .Take(filter.iDisplayLength ?? 0);
                }
                else
                {
                    query = _readOnlyCtx.Set<Meeting>()
                                       .Include(x => x.MeetingType!)
                                       .OrderByDescending(x => x.Id);
                }
                IQueryable<Meeting> queryTotal = _readOnlyCtx.Set<Meeting>()
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
                query = query.WhereIf(filter.HasNgoId, x => x.NgoId == filter.NgoId);
                query = query.WhereIf(filter.HasMeetingDate, x => x.MeetingDate == filter.MeetingDate);
                query = query.WhereIf(filter.HasMeetingTypeId, x => x.MeetingTypeId == filter.MeetingTypeId);

                if (filter.HasTake)
                {
                    query = query.Take(filter.Take ?? Defaults.Take);
                }



                query = query
                    .OrderByDescending(x => x.Id)
                    .Include(x => x.MeetingType!);

                var result = await query.ToListAsync();


                return (ExecutionState.Retrieved, new PaginationResutl<Meeting>
                {
                    aaData = result,
                    iTotalDisplayRecords = await queryTotal.CountAsync(),
                    iTotalRecords = await queryTotal.CountAsync(),
                }, "Data returned successfully.");


                //return (ExecutionState.Retrieved, result, "Data returned successfully.");
            }
            catch (Exception ex)
            {
                return (ExecutionState.Failure, new PaginationResutl<Meeting>()!, "Unexpected error occurred.");
            }
        }

        public override Task<(ExecutionState executionState, Meeting entity, string message)> GetAsync(long id)
        {
            var filterOptions = new FilterOptions<Meeting>
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
                    .Include(x => x.MeetingType)
                    .Include(x => x.Ngo)
                    .Include(y => y.MeetingParticipantsMaps!)
                        .ThenInclude(ab => ab.Survey)
                    .Include(y => y.MeetingParticipantsMaps!)
                        .ThenInclude(ab => ab.MeetingMember)
                    .Include(y => y.MeetingFiles!)
            };

            return base.GetAsync(filterOptions);
        }

        public override async Task<(ExecutionState executionState, Meeting entity, string message)> CreateAsync(Meeting entity)
        {
            AddParticipantType(ref entity);

            await SetMaleFemale(entity);

            return await base.CreateAsync(entity);
        }

        public override async Task<(ExecutionState executionState, Meeting entity, string message)> UpdateAsync(Meeting entity)
        {
            await SetMaleFemale(entity);

            if (entity.MeetingParticipantsMaps != null)
            {
                foreach (var map in entity.MeetingParticipantsMaps)
                {
                    map.IsActive = !entity.IsDeleted;
                    map.IsDeleted = entity.IsDeleted;

                    if (map.MeetingMember != null)
                    {
                        map.MeetingMember.IsActive = !entity.IsDeleted;
                        map.MeetingMember.IsDeleted = entity.IsDeleted;
                    }
                }
            }

            AddParticipantType(ref entity);

            return await base.UpdateAsync(entity);
        }

        private async Task SetMaleFemale(Meeting entity)
        {
            var surveyIds = entity.MeetingParticipantsMaps?.Select(x => x.SurveyId).ToList() ?? new List<long?>();
            var surveyGenders = await _readOnlyCtx.Set<Survey>().Where(x => surveyIds.Contains(x.Id)).Select(x => x.BeneficiaryGender).ToListAsync();

            var surveyTotalMale = surveyGenders.Count(x => x == Gender.Male);
            var surveyTotalFemale = surveyGenders.Count(x => x == Gender.Female);
            var otherTotalMale = entity.MeetingParticipantsMaps?.Where(x => x.MeetingMember?.MemberGender == Gender.Male).Count() ?? 0;
            var otherTotalFemale = entity.MeetingParticipantsMaps?.Where(x => x.MeetingMember?.MemberGender == Gender.Female).Count() ?? 0;

            var total = entity.MeetingParticipantsMaps?.Count ?? 0;

            entity.TotalMembers = total;
            entity.TotalMale = otherTotalMale + surveyTotalMale;
            entity.TotalFemale = otherTotalFemale + surveyTotalFemale;
        }

        private void AddParticipantType(ref Meeting entity)
        {
            if (entity.MeetingParticipantsMaps == null)
                return;

            entity.MeetingParticipantsMaps =
                entity.MeetingParticipantsMaps
                    .Where(x => x.MeetingMember != null || (x.SurveyId != null && x.SurveyId > 0))
                    .ToList();

            if (entity.MeetingParticipantsMaps != null && entity.MeetingParticipantsMaps.Count > 0)
            {
                foreach (var participentsMap in entity.MeetingParticipantsMaps)
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

        public async Task<(ExecutionState executionState, bool isDeleted, string message)> DeleteParticipant(long mapId)
        {
            (ExecutionState executionState, bool isDeleted, string message) returnResponse;

            try
            {
                var trainingParticipentsMap = await _unitOfWork.GetAsync(new FilterOptions<MeetingParticipantsMap>()
                {
                    FilterExpression = x => x.Id == mapId,
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

    }
}

