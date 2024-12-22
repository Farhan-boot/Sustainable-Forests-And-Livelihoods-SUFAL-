using AutoMapper;

using PTSL.GENERIC.Business.Businesses.Interface;
using PTSL.GENERIC.Common.Entity.GeneralSetup;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model.EntityViewModels.GeneralSetup;
using PTSL.GENERIC.Service.BaseServices;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTSL.GENERIC.Service.Services;

public class CommitteeDesignationService : BaseService<CommitteeDesignationVM, CommitteeDesignation>, ICommitteeDesignationService
{
    public readonly ICommitteeDesignationBusiness _business;
    public IMapper _mapper;

    public CommitteeDesignationService(ICommitteeDesignationBusiness business, IMapper mapper) : base(business)
    {
        _business = business;
        _mapper = mapper;
    }

    public override CommitteeDesignation CastModelToEntity(CommitteeDesignationVM model)
    {
        try
        {
            return _mapper.Map<CommitteeDesignation>(model);
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    public override CommitteeDesignationVM CastEntityToModel(CommitteeDesignation entity)
    {
        try
        {
            CommitteeDesignationVM model = _mapper.Map<CommitteeDesignationVM>(entity);
            return model;
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    public override IList<CommitteeDesignationVM> CastEntityToModel(IQueryable<CommitteeDesignation> entity)
    {
        try
        {
            IList<CommitteeDesignationVM> SubCommitteeDesignationList = _mapper.Map<IList<CommitteeDesignationVM>>(entity).ToList();
            return SubCommitteeDesignationList;
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    public async Task<(ExecutionState executionState, List<CommitteeDesignationVM> entity, string message)> ListByFilter(CommitteeDesignationFilterVM filter)
    {
        var result = await _business.ListByFilter(filter);

        return (result.executionState, _mapper.Map<List<CommitteeDesignationVM>>(result.entity), result.message);
    }
}
