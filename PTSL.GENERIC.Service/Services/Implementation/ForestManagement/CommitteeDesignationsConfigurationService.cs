using AutoMapper;

using PTSL.GENERIC.Business.Businesses.Interface.ForestManagement;
using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Entity.ForestManagement;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model.EntityViewModels.ForestManagement;
using PTSL.GENERIC.Service.BaseServices;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTSL.GENERIC.Service.Services.ForestManagement
{
    public class CommitteeDesignationsConfigurationService : BaseService<CommitteeDesignationsConfigurationVM, CommitteeDesignationsConfiguration>, ICommitteeDesignationsConfigurationService
    {
        public IMapper _mapper;
        private readonly ICommitteeDesignationsConfigurationBusiness _business;

        public CommitteeDesignationsConfigurationService(ICommitteeDesignationsConfigurationBusiness business, IMapper mapper) : base(business)
        {
            _mapper = mapper;
            _business = business;
        }

        public override CommitteeDesignationsConfiguration CastModelToEntity(CommitteeDesignationsConfigurationVM model)
        {
            return _mapper.Map<CommitteeDesignationsConfiguration>(model);
        }

        public override CommitteeDesignationsConfigurationVM CastEntityToModel(CommitteeDesignationsConfiguration entity)
        {
            return _mapper.Map<CommitteeDesignationsConfigurationVM>(entity);
        }

        public override IList<CommitteeDesignationsConfigurationVM> CastEntityToModel(IQueryable<CommitteeDesignationsConfiguration> entity)
        {
            return _mapper.Map<IList<CommitteeDesignationsConfigurationVM>>(entity).ToList();
        }


        public List<CommitteeDesignationsConfigurationVM> CastEntityListToModel(List<CommitteeDesignationsConfiguration> entity)
        {
            return _mapper.Map<List<CommitteeDesignationsConfigurationVM>>(entity);
        }

        public async Task<(ExecutionState executionState, List<CommitteeDesignationsConfigurationVM> entity, string message)> GetCommitteeDesignationsConfigurationByCommitteesConfigurationId(long id)
        {
            var result = await _business.GetCommitteeDesignationsConfigurationByCommitteesConfigurationId(id);

            if (result.entity is not null)
            {
                return (result.executionState, CastEntityListToModel(result.entity), result.message);
            }

            return (result.executionState, new List<CommitteeDesignationsConfigurationVM>(), result.message);
        }

    }
}