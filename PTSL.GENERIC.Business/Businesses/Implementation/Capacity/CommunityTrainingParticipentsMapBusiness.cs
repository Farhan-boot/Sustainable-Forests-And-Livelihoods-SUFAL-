using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;

using PTSL.GENERIC.Business.BaseBusinesses;
using PTSL.GENERIC.Business.Businesses.Interface.Capacity;
using PTSL.GENERIC.Common.Entity.Capacity;
using PTSL.GENERIC.Common.Helper;
using PTSL.GENERIC.Common.Model.EntityViewModels.AIG;
using PTSL.GENERIC.DAL.UnitOfWork;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Entity;
using Microsoft.EntityFrameworkCore;
using PTSL.GENERIC.Common.Model.EntityViewModels.Capacity;
using PTSL.GENERIC.Common.Entity.MeetingManagement;
using PTSL.GENERIC.Common.QuerySerialize.Implementation;

namespace PTSL.GENERIC.Business.Businesses.Implementation.Capacity
{
    public class CommunityTrainingParticipentsMapBusiness : BaseBusiness<CommunityTrainingParticipentsMap>, ICommunityTrainingParticipentsMapBusiness
    {
        public readonly GENERICUnitOfWork _unitOfWork;
        private readonly GENERICReadOnlyCtx _readOnlyCtx;

        public CommunityTrainingParticipentsMapBusiness(GENERICUnitOfWork unitOfWork, GENERICReadOnlyCtx readOnlyCtx)
            : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _readOnlyCtx = readOnlyCtx;
        }

        public async Task<(ExecutionState executionState, IList<CommunityTrainingParticipantsByBeneficiaryResultVM> entity, string message)> GetCommunityTrainingParticipentsMapByFilter(CommunityTrainingFilterByBeneficiaryVM filter)
        {
            try
            {
                IQueryable<CommunityTrainingParticipentsMap> query = _readOnlyCtx.Set<CommunityTrainingParticipentsMap>()
                    .OrderByDescending(x => x.Id)
                    .Include(x => x.CommunityTraining!)
                    .Include(x => x.Survey!)
                    .Where(x => x.SurveyId != null);

                // Forest Administration
                query = query.WhereIf(filter.HasForestCircleId, x => x.CommunityTraining!.ForestCircleId == filter.ForestCircleId);
                query = query.WhereIf(filter.HasForestDivisionId, x => x.CommunityTraining!.ForestDivisionId == filter.ForestDivisionId);
                query = query.WhereIf(filter.HasForestRangeId, x => x.CommunityTraining!.ForestRangeId == filter.ForestRangeId);
                query = query.WhereIf(filter.HasForestBeatId, x => x.CommunityTraining!.ForestBeatId == filter.ForestBeatId);
                query = query.WhereIf(filter.HasForestFcvVcfId, x => x.CommunityTraining!.ForestFcvVcfId == filter.ForestFcvVcfId);

                // Civil Administration
                query = query.WhereIf(filter.HasDivisionId, x => x.CommunityTraining!.DivisionId == filter.DivisionId);
                query = query.WhereIf(filter.HasDistrictId, x => x.CommunityTraining!.DistrictId == filter.DistrictId);
                query = query.WhereIf(filter.HasUpazillaId, x => x.CommunityTraining!.UpazillaId == filter.UpazillaId);
                query = query.WhereIf(filter.HasUnionId, x => x.CommunityTraining!.UnionId == filter.UnionId);

                // Common
                query = query.WhereIf(filter.HasGender, x => x.Survey!.BeneficiaryGender == filter.Gender);
                query = query.WhereIf(filter.HasPhoneNumber, x => x.Survey!.BeneficiaryPhone == filter.PhoneNumber);
                query = query.WhereIf(filter.HasNID, x => x.Survey!.BeneficiaryNid == filter.NID);
                query = query.WhereIf(filter.HasNgoId, x => x.Survey!.NgoId == filter.NgoId);

                query = query.WhereIf(filter.HasBeneficiaryName,
                    x => x.Survey!.BeneficiaryName!.Contains(filter.BeneficiaryName!)
                        || x.Survey.BeneficiaryNameBn!.Contains(filter.BeneficiaryName!));

                var result = await query.ToListAsync();

                var finalResult = result
                    .GroupBy(r => new
                    {
                        r.SurveyId,
                        r.Survey,
                    })
                    .Select(g => new CommunityTrainingParticipantsByBeneficiaryResultVM
                    {
                        BeneficiaryName = g.Key.Survey!.BeneficiaryName,
                        BeneficiaryPhone = g.Key.Survey!.BeneficiaryPhone,
                        BeneficiaryNid = g.Key.Survey!.BeneficiaryNid,
                        Trainings = result.Where(x => x.SurveyId == g.Key.SurveyId).Select(x => x.CommunityTraining) ?? Enumerable.Empty<CommunityTraining>(),
                    })
                    .ToList();

                return (ExecutionState.Retrieved, finalResult, "Data returned successfully.");
            }
            catch (Exception ex)
            {
                return (ExecutionState.Failure, new List<CommunityTrainingParticipantsByBeneficiaryResultVM>()!, "Unexpected error occurred.");
            }
        }


        public override Task<(ExecutionState executionState, IQueryable<CommunityTrainingParticipentsMap> entity, string message)> List(QueryOptions<CommunityTrainingParticipentsMap> queryOptions = null)
        {
            queryOptions = new QueryOptions<CommunityTrainingParticipentsMap>
            {
                IncludeExpression = e => e.Include(x => x.CommunityTraining!),
                SortingExpression = x => x.OrderByDescending(y => y.Id)
            };
            return base.List(queryOptions);
        }



    }
}
