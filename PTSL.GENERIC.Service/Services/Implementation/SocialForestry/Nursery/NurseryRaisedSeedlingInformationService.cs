using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AutoMapper;

using PTSL.GENERIC.Business.Businesses.Interface.SocialForestry.Nursery;
using PTSL.GENERIC.Common.Entity.SocialForestry.Nursery;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Service.BaseServices;

namespace PTSL.GENERIC.Service.Services.SocialForestry.Nursery
{
    public class NurseryRaisedSeedlingInformationService : BaseService<NurseryRaisedSeedlingInformationVM, NurseryRaisedSeedlingInformation>, INurseryRaisedSeedlingInformationService
    {
        private readonly INurseryRaisedSeedlingInformationBusiness _business;
        public IMapper _mapper;

        public NurseryRaisedSeedlingInformationService(INurseryRaisedSeedlingInformationBusiness business, IMapper mapper) : base(business)
        {
            _business = business;
            _mapper = mapper;
        }

        public override NurseryRaisedSeedlingInformation CastModelToEntity(NurseryRaisedSeedlingInformationVM model)
        {
            return _mapper.Map<NurseryRaisedSeedlingInformation>(model);
        }

        public override NurseryRaisedSeedlingInformationVM CastEntityToModel(NurseryRaisedSeedlingInformation entity)
        {
            return _mapper.Map<NurseryRaisedSeedlingInformationVM>(entity);
        }

        public override IList<NurseryRaisedSeedlingInformationVM> CastEntityToModel(IQueryable<NurseryRaisedSeedlingInformation> entity)
        {
            return _mapper.Map<IList<NurseryRaisedSeedlingInformationVM>>(entity).ToList();
        }

        public async Task<(ExecutionState executionState, List<NurseryRaisedSeedlingInformationVM> entity, string message)> GetSeedlingByNurseryId(long id, bool forPlantationOrDistribution)
        {
            var list = await _business.GetSeedlingByNurseryId(id, forPlantationOrDistribution);
            if (list.entity is null)
            {
                return (ExecutionState.Failure, new List<NurseryRaisedSeedlingInformationVM>(), "No data found");
            }

            return (ExecutionState.Success, _mapper.Map<List<NurseryRaisedSeedlingInformationVM>>(list.entity), "Success");
        }

        public async Task<(ExecutionState executionState, NurseryRaisedSeedlingInformationVM entity, string message)> SeedlinUpdate(UpdateSeedlingInfoVM model)
        {
            (ExecutionState executionState, NurseryRaisedSeedlingInformationVM entity, string message) returnResponse;
            try
            {
                
                (ExecutionState executionState, NurseryRaisedSeedlingInformation entity, string message) entity = await _business.SeedlinUpdate(model);

                if (entity.executionState == ExecutionState.Updated)
                {
                    returnResponse = (executionState: entity.executionState, entity: CastEntityToModel(entity.entity), message: entity.message);
                }
                else
                {
                    returnResponse = (executionState: entity.executionState, entity: new NurseryRaisedSeedlingInformationVM(), message: entity.message);
                }
            }
            catch (Exception ex)
            {
                returnResponse = (executionState: ExecutionState.Failure, entity: new NurseryRaisedSeedlingInformationVM(), message: ex.Message);
            }

            return returnResponse;
        }
    }
}