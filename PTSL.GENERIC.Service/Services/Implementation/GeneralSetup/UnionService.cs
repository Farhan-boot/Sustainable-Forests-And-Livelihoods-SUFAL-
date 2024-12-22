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
    public class UnionService : BaseService<UnionVM, Union>, IUnionService
    {
        public readonly IUnionBusiness _UnionBusiness;
        public IMapper _mapper;

        public UnionService(IUnionBusiness business, IMapper mapper) : base(business)
        {
            _UnionBusiness = business;
            _mapper = mapper;
        }

        public override Union CastModelToEntity(UnionVM model)
        {
            try
            {
                return _mapper.Map<Union>(model);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public override UnionVM CastEntityToModel(Union entity)
        {
            try
            {
                UnionVM model = _mapper.Map<UnionVM>(entity);
                return model;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public override IList<UnionVM> CastEntityToModel(IQueryable<Union> entity)
        {
            try
            {
                IList<UnionVM> UnionList = _mapper.Map<IList<UnionVM>>(entity).ToList();
                return UnionList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<(ExecutionState executionState, IList<UnionVM> entity, string message)> ListByUpazilla(long UpazillaId)
        {
            (ExecutionState executionState, IList<UnionVM> entity, string message) returnResponse;

            try
            {
                (ExecutionState executionState, IQueryable<Union> entity, string message) response = await _UnionBusiness.ListByUpazilla(UpazillaId);

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

        public async Task<(ExecutionState executionState, IList<UnionVM> entity, string message)> ListByMultipleUpazilla(List<long> upazillas)
        {
            (ExecutionState executionState, IList<UnionVM> entity, string message) returnResponse;

            try
            {
                (ExecutionState executionState, IQueryable<Union> entity, string message) response = await _UnionBusiness.ListByMultipleUpazilla(upazillas);

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
