using AutoMapper;
using PTSL.GENERIC.Business.Businesses.Interface.ForestManagement;
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
    public class OtherCommitteeMemberService : BaseService<OtherCommitteeMemberVM, OtherCommitteeMember>, IOtherCommitteeMemberService
    {
        private readonly IOtherCommitteeMemberBusiness _business;
        public IMapper _mapper;

        public OtherCommitteeMemberService(IOtherCommitteeMemberBusiness business, IMapper mapper) : base(business)
        {
            _business = business;
            _mapper = mapper;
        }

        public override OtherCommitteeMember CastModelToEntity(OtherCommitteeMemberVM model)
        {
            try
            {
                return _mapper.Map<OtherCommitteeMember>(model);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public override OtherCommitteeMemberVM CastEntityToModel(OtherCommitteeMember entity)
        {
            try
            {
                var model = _mapper.Map<OtherCommitteeMemberVM>(entity);
                return model;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public override IList<OtherCommitteeMemberVM> CastEntityToModel(IQueryable<OtherCommitteeMember> entity)
        {
            try
            {
                var entityList = _mapper.Map<IList<OtherCommitteeMemberVM>>(entity).ToList();
                return entityList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<(ExecutionState executionState, IList<OtherCommitteeMemberVM> entity, string message)> ListByForestFcvVcf(long id)
        {
            (ExecutionState executionState, IList<OtherCommitteeMemberVM> entity, string message) returnResponse;

            try
            {
                (ExecutionState executionState, IQueryable<OtherCommitteeMember> entity, string message) response = await _business.ListByForestFcvVcf(id);

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
