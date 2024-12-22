using Microsoft.EntityFrameworkCore;
using PTSL.GENERIC.Business.BaseBusinesses;
using PTSL.GENERIC.Business.Businesses.Interface.Beneficiary;
using PTSL.GENERIC.Common.Entity;
using PTSL.GENERIC.Common.Entity.AIG;
using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Entity.Capacity;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Helper;
using PTSL.GENERIC.Common.Model.EntityViewModels.AIG.Reports;
using PTSL.GENERIC.Common.Model.EntityViewModels.Beneficiary;
using PTSL.GENERIC.Common.QuerySerialize.Implementation;
using PTSL.GENERIC.DAL.UnitOfWork;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Threading.Tasks;

namespace PTSL.GENERIC.Business.Businesses.Implementation.Beneficiary
{
    public class ForestFcvVcfBusiness : BaseBusiness<ForestFcvVcf>, IForestFcvVcfBusiness
    {
        public readonly GENERICUnitOfWork _unitOfWork;
        private readonly GENERICReadOnlyCtx _readOnlyCtx;
        public ForestFcvVcfBusiness(GENERICUnitOfWork unitOfWork, GENERICReadOnlyCtx readOnlyCtx)
            : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _readOnlyCtx = readOnlyCtx;
        }

        public override Task<(ExecutionState executionState, IQueryable<ForestFcvVcf> entity, string message)> List(QueryOptions<ForestFcvVcf> queryOptions = null)
        {
            queryOptions = new QueryOptions<ForestFcvVcf>
            {
                SortingExpression = x => x.OrderByDescending(y => y.Id),
                IncludeExpression = x => x.Include(y => y.ForestBeat!.ForestRange!.ForestDivision!.ForestCircle!),
            };

            return base.List(queryOptions);
        }

        public override Task<(ExecutionState executionState, ForestFcvVcf entity, string message)> GetAsync(long forestFcvVcfId)
        {
            var filterOptions = new FilterOptions<ForestFcvVcf>();
            filterOptions.FilterExpression = e => e.Id == forestFcvVcfId;
            filterOptions.IncludeExpression = e => e.Include(x => x.ForestBeat!.ForestRange!.ForestDivision!);

            return base.GetAsync(filterOptions);
        }
        public Task<(ExecutionState executionState, IQueryable<ForestFcvVcf> entity , string message)> GetFcvVcfByType(bool isFcv)
        {
            var queryOptions = new QueryOptions<ForestFcvVcf>();
            queryOptions.FilterExpression = x=>x.IsFcv! == isFcv;
            return base.List(queryOptions);
        }
        public Task<(ExecutionState executionState, IQueryable<ForestFcvVcf> entity, string message)> ListByForestBeat(long ForestBeatId)
        {
            var queryOptions = new QueryOptions<ForestFcvVcf>();
            queryOptions.FilterExpression = e => e.ForestBeatId ==ForestBeatId;

            return base.List(queryOptions);
        }
        public Task<(ExecutionState executionState, IQueryable<ForestFcvVcf> entity, string message)> ListByForestBeatAndType(long ForestBeatId, FcvVcfType type)
        {
            var queryOptions = new QueryOptions<ForestFcvVcf>();
            queryOptions.FilterExpression = e => e.ForestBeatId == ForestBeatId && (e.IsFcv == (type == FcvVcfType.FCV));

            return base.List(queryOptions);
        }


        public async Task<(ExecutionState executionState, List<MemberPerVillageVM> entity, string message)> MemberPerVillage(MemberPerVillageFilterVM filter)
        {

            IQueryable<Survey> query = _readOnlyCtx.Set<Survey>()
                .FilterSurvey(filter);

            var groups = await query
                .Where(x => x.ForestFcvVcf!.IsFcv)
                .Select(x => new
                {
                    x.ForestCircleId,
                    x.ForestDivisionId,
                    x.ForestRangeId,
                    x.ForestBeatId,
                    x.ForestFcvVcfId,

                    ForestCircle = x.ForestCircle!.Name,
                    ForestDivision = x.ForestDivision!.Name,
                    ForestRange = x.ForestRange!.Name,
                    ForestBeat = x.ForestBeat!.Name,
                    ForestFcvVcf = x.ForestFcvVcf!.Name,

                    x.Id,
                })
                .ToListAsync();

            var result = groups
                .GroupBy(x => new { x.ForestCircleId, x.ForestDivisionId, x.ForestRangeId, x.ForestBeatId, x.ForestFcvVcfId })
                .Select(group => new MemberPerVillageVM
                {
                    ForestCircle = group.Where(x => x.ForestCircleId == group.Key.ForestCircleId).Select(x => x.ForestCircle).First(),
                    ForestDivision = group.Where(x => x.ForestDivisionId == group.Key.ForestDivisionId).Select(x => x.ForestDivision).First(),
                    ForestRange = group.Where(x => x.ForestRangeId == group.Key.ForestRangeId).Select(x => x.ForestRange).First(),
                    ForestBeat = group.Where(x => x.ForestBeatId == group.Key.ForestBeatId).Select(x => x.ForestBeat).First(),
                    ForestFcvVcf = group.Where(x => x.ForestFcvVcfId == group.Key.ForestFcvVcfId).Select(x => x.ForestFcvVcf).First(),

                    NoOfTotalFcvMember = group.Where(x => x.ForestFcvVcfId == group.Key.ForestFcvVcfId).Count(),
                    NoOfTotalVillage = group.Count()
                })
                .ToList();

            return (ExecutionState.Success, result!, "Returned successfully");
        }


    }
}
