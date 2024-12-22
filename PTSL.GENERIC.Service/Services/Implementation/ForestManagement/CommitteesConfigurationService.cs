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
    public class CommitteesConfigurationService : BaseService<CommitteesConfigurationVM, CommitteesConfiguration>, ICommitteesConfigurationService
    {
        public IMapper _mapper;
        private readonly ICommitteesConfigurationBusiness _business;
        public CommitteesConfigurationService(ICommitteesConfigurationBusiness business, IMapper mapper) : base(business)
        {
            _mapper = mapper;
            _business = business;
        }

        public override CommitteesConfiguration CastModelToEntity(CommitteesConfigurationVM model)
        {
            return _mapper.Map<CommitteesConfiguration>(model);
        }

        public override CommitteesConfigurationVM CastEntityToModel(CommitteesConfiguration entity)
        {
            return _mapper.Map<CommitteesConfigurationVM>(entity);
        }

        public override IList<CommitteesConfigurationVM> CastEntityToModel(IQueryable<CommitteesConfiguration> entity)
        {
            return _mapper.Map<IList<CommitteesConfigurationVM>>(entity).ToList();
        }


        public List<CommitteesConfigurationVM> CastEntityListToModel(List<CommitteesConfiguration> entity)
        {
            return _mapper.Map<List<CommitteesConfigurationVM>>(entity);
        }

        public async Task<(ExecutionState executionState, List<CommitteesConfigurationVM> entity, string message)> GetCommitteesConfigurationByCommitteeTypeConfigurationId(long id)
        {
            var result = await _business.GetCommitteesConfigurationByCommitteeTypeConfigurationId(id);

            if (result.entity is not null)
            {
                return (result.executionState, CastEntityListToModel(result.entity), result.message);
            }

            return (result.executionState, new List<CommitteesConfigurationVM>(), result.message);
        }


    }
}