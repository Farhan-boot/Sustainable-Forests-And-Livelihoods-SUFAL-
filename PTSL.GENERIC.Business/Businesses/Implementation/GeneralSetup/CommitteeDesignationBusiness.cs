using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Business.BaseBusinesses;
using PTSL.GENERIC.Business.Businesses.Interface;
using PTSL.GENERIC.Common.Entity;
using PTSL.GENERIC.Common.Entity.GeneralSetup;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Helper;
using PTSL.GENERIC.Common.Model.EntityViewModels.GeneralSetup;
using PTSL.GENERIC.Common.QuerySerialize.Implementation;
using PTSL.GENERIC.DAL.UnitOfWork;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTSL.GENERIC.Business.Businesses.Implementation;

public class CommitteeDesignationBusiness : BaseBusiness<CommitteeDesignation>, ICommitteeDesignationBusiness
{
    public readonly GENERICUnitOfWork _unitOfWork;
    private readonly GENERICWriteOnlyCtx _writeOnlyCtx;

    public CommitteeDesignationBusiness(GENERICUnitOfWork unitOfWork, GENERICWriteOnlyCtx writeOnlyCtx)
        : base(unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _writeOnlyCtx = writeOnlyCtx;
    }

    public override Task<(ExecutionState executionState, IQueryable<CommitteeDesignation> entity, string message)> List(QueryOptions<CommitteeDesignation> queryOptions = null)
    {
        queryOptions = new QueryOptions<CommitteeDesignation>
        {
            SortingExpression = x => x.OrderByDescending(y => y.Id)
        };

        return base.List(queryOptions);
    }

    public async Task<(ExecutionState executionState, List<CommitteeDesignation> entity, string message)> ListByFilter(CommitteeDesignationFilterVM filter)
    {
        var result = await _writeOnlyCtx.Set<CommitteeDesignation>()
            .WhereIf(filter.HasSubCommitteeType, x => x.SubCommitteeType == filter.SubCommitteeType)
            .WhereIf(filter.HasCommitteeType, x => x.CommitteeType == filter.CommitteeType)
            .ToListAsync();

        return (ExecutionState.Retrieved, result, "Retrived successfully");
    }
}
