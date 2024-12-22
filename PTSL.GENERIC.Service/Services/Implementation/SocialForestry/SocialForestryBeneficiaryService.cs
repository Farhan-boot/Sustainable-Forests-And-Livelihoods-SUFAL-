using AutoMapper;

using PTSL.GENERIC.Business.Businesses.Interface.SocialForestry;
using PTSL.GENERIC.Common.Entity.SocialForestry;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model.EntityViewModels.SocialForestry;
using PTSL.GENERIC.Service.BaseServices;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTSL.GENERIC.Service.Services.SocialForestry
{
    public class SocialForestryBeneficiaryService : BaseService<SocialForestryBeneficiaryVM, SocialForestryBeneficiary>, ISocialForestryBeneficiaryService
    {
        private readonly ISocialForestryBeneficiaryBusiness _business;
        public IMapper _mapper;

        public SocialForestryBeneficiaryService(ISocialForestryBeneficiaryBusiness business, IMapper mapper) : base(business)
        {
            _business = business;
            _mapper = mapper;
        }

        public override SocialForestryBeneficiary CastModelToEntity(SocialForestryBeneficiaryVM model)
        {
            return _mapper.Map<SocialForestryBeneficiary>(model);
        }

        public override SocialForestryBeneficiaryVM CastEntityToModel(SocialForestryBeneficiary entity)
        {
            return _mapper.Map<SocialForestryBeneficiaryVM>(entity);
        }

        public override IList<SocialForestryBeneficiaryVM> CastEntityToModel(IQueryable<SocialForestryBeneficiary> entity)
        {
            return _mapper.Map<IList<SocialForestryBeneficiaryVM>>(entity).ToList();
        }
        public override async Task<(ExecutionState executionState, SocialForestryBeneficiaryVM entity, string message)> GetAsync(long key)
        {

            (ExecutionState executionState, SocialForestryBeneficiaryVM entity, string message) returnResponse;
            try
            {
                (ExecutionState executionState, SocialForestryBeneficiary entity, string message) recieveEntity = await _business.GetByIdAsync(key);

                if (recieveEntity.executionState == ExecutionState.Retrieved)
                {
                    returnResponse = (executionState: recieveEntity.executionState, entity: CastEntityToModel(recieveEntity.entity), message: recieveEntity.message);
                }
                else
                {
                    returnResponse = (executionState: recieveEntity.executionState, entity: null, message: recieveEntity.message);
                }
            }
            catch (Exception ex)
            {
                returnResponse = (executionState: ExecutionState.Failure, entity: null, message: ex.Message);
            }

            return returnResponse;

        }

        public async Task<(ExecutionState executionState, List<SocialForestryBeneficiaryVM> entity, string message)> GetBeneficiariesByNewRaisedId(long newRaisedId, bool hasPbsa = false)
        {
            var result = await _business.GetBeneficiariesByNewRaisedId(newRaisedId);

            return (ExecutionState.Success, _mapper.Map<List<SocialForestryBeneficiaryVM>>(result.entity!), "Data returned successfully");
        }
    }
}
