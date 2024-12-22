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
    public class CommitteeTypeConfigurationService : BaseService<CommitteeTypeConfigurationVM, CommitteeTypeConfiguration>, ICommitteeTypeConfigurationService
    {
        public IMapper _mapper;
        private readonly ICommitteeTypeConfigurationBusiness _business;

        public CommitteeTypeConfigurationService(ICommitteeTypeConfigurationBusiness business, IMapper mapper) : base(business)
        {
            _mapper = mapper;
            _business = business;
        }

        public override CommitteeTypeConfiguration CastModelToEntity(CommitteeTypeConfigurationVM model)
        {
            return _mapper.Map<CommitteeTypeConfiguration>(model);
        }

        public override CommitteeTypeConfigurationVM CastEntityToModel(CommitteeTypeConfiguration entity)
        {
            return _mapper.Map<CommitteeTypeConfigurationVM>(entity);
        }

        public override IList<CommitteeTypeConfigurationVM> CastEntityToModel(IQueryable<CommitteeTypeConfiguration> entity)
        {
            return _mapper.Map<IList<CommitteeTypeConfigurationVM>>(entity).ToList();
        }


        public List<CommitteeTypeConfigurationVM> CastEntityListToModel(List<CommitteeTypeConfiguration> entity)
        {
            return _mapper.Map<List<CommitteeTypeConfigurationVM>>(entity);
        }

        public async Task<(ExecutionState executionState, List<CommitteeTypeConfigurationVM> entity, string message)> GetCommitteeTypeConfigurationByFcvOrVcfId(long id)
        {
            var result = await _business.GetCommitteeTypeConfigurationByFcvOrVcfId(id);

            if (result.entity is not null)
            {
                return (result.executionState, CastEntityListToModel(result.entity), result.message);
            }

            return (result.executionState, new List<CommitteeTypeConfigurationVM>(), result.message);
        }


    }
}