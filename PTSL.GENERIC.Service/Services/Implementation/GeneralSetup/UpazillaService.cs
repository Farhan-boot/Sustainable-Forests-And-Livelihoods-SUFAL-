using AutoMapper;
using PTSL.GENERIC.Business.Businesses.Interface;
using PTSL.GENERIC.Common.Entity.GeneralSetup;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model.EntityViewModels.Beneficiary;
using PTSL.GENERIC.Common.Model.EntityViewModels.GeneralSetup;
using PTSL.GENERIC.Service.BaseServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTSL.GENERIC.Service.Services
{
    public class UpazillaService : BaseService<UpazillaVM, Upazilla>, IUpazillaService
    {
        public readonly IUpazillaBusiness _upazillaBusiness;
        public IMapper _mapper;

        public UpazillaService(IUpazillaBusiness business, IMapper mapper) : base(business)
        {
            _upazillaBusiness = business;
            _mapper = mapper;
        }

        public override Upazilla CastModelToEntity(UpazillaVM model)
        {
            try
            {
                return _mapper.Map<Upazilla>(model);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public override UpazillaVM CastEntityToModel(Upazilla entity)
        {
            try
            {
                UpazillaVM model = _mapper.Map<UpazillaVM>(entity);
                return model;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public override IList<UpazillaVM> CastEntityToModel(IQueryable<Upazilla> entity)
        {
            try
            {
                IList<UpazillaVM> UpazillaList = _mapper.Map<IList<UpazillaVM>>(entity).ToList();
                return UpazillaList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<(ExecutionState executionState, IList<UpazillaVM> entity, string message)> ListByDistrict(long districtId)
        {
            (ExecutionState executionState, IList<UpazillaVM> entity, string message) returnResponse;

            try
            {
                (ExecutionState executionState, IQueryable<Upazilla> entity, string message) response = await _upazillaBusiness.ListByDistrict(districtId);

                if (response.executionState == ExecutionState.Retrieved)
                {
                    returnResponse = (response.executionState, entity: CastEntityToModel(response.entity), response.message);
                }
                else
                {
                    returnResponse = (response.executionState, entity: null, response.message);
                }
            }
            catch (Exception ex)
            {
                returnResponse = (executionState: ExecutionState.Failure, entity: null, message: ex.Message);
            }

            return returnResponse;
        }
    }
}
