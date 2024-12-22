using AutoMapper;

using PTSL.GENERIC.Business.Businesses.Interface.SocialForestry.Cutting;
using PTSL.GENERIC.Common.Entity.SocialForestry.Cutting;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model.EntityViewModels.SocialForestry.Cutting;
using PTSL.GENERIC.Service.BaseServices;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTSL.GENERIC.Service.Services.SocialForestry.Cutting
{
    public class LotWiseSellingInformationService : BaseService<LotWiseSellingInformationVM, LotWiseSellingInformation>, ILotWiseSellingInformationService
    {
        private readonly ILotWiseSellingInformationBusiness _business;
        public IMapper _mapper;

        public LotWiseSellingInformationService(ILotWiseSellingInformationBusiness business, IMapper mapper) : base(business)
        {
            _business = business;
            _mapper = mapper;
        }

        public override LotWiseSellingInformation CastModelToEntity(LotWiseSellingInformationVM model)
        {
            return _mapper.Map<LotWiseSellingInformation>(model);
        }

        public override LotWiseSellingInformationVM CastEntityToModel(LotWiseSellingInformation entity)
        {
            return _mapper.Map<LotWiseSellingInformationVM>(entity);
        }

        public override IList<LotWiseSellingInformationVM> CastEntityToModel(IQueryable<LotWiseSellingInformation> entity)
        {
            return _mapper.Map<IList<LotWiseSellingInformationVM>>(entity).ToList();
        }

        public async Task<(ExecutionState executionState, List<LotWiseSellingInformationVM> data, string message)> GetLotInfoByCuttingId(long id)
        {
            var result = await _business.GetLotInfoByCuttingId(id);
            if (result.data is null)
            {
                return (ExecutionState.Success, new List<LotWiseSellingInformationVM>(), "Success");
            }

            return (ExecutionState.Success, _mapper.Map<List<LotWiseSellingInformationVM>>(result.data), "Success");
        }

        public async Task<(ExecutionState executionState, LotWiseSellingInformationVM data, string message)> GetLotInfoByLotNumber(string lotNumber)
        {
            var result = await _business.GetLotInfoByLotNumber(lotNumber);
            if (result.data is null)
            {
                return (ExecutionState.Success, null!, "Success");
            }

            return (ExecutionState.Success, _mapper.Map<LotWiseSellingInformationVM>(result.data), "Success");
        }
    }
}