using AutoMapper;

using PTSL.GENERIC.Business.Businesses.Interface.AIG;
using PTSL.GENERIC.Common.Entity.AIG;
using PTSL.GENERIC.Service.BaseServices;

using System.Collections.Generic;
using System.Linq;

namespace PTSL.GENERIC.Service.Services.AIG
{
    public class SecondFourtyPercentageLDFService : BaseService<SecondFourtyPercentageLDFVM, SecondFourtyPercentageLDF>, ISecondFourtyPercentageLDFService
    {
        public IMapper _mapper;

        public SecondFourtyPercentageLDFService(ISecondFourtyPercentageLDFBusiness business, IMapper mapper) : base(business)
        {
            _mapper = mapper;
        }

        public override SecondFourtyPercentageLDF CastModelToEntity(SecondFourtyPercentageLDFVM model)
        {
            return _mapper.Map<SecondFourtyPercentageLDF>(model);
        }

        public override SecondFourtyPercentageLDFVM CastEntityToModel(SecondFourtyPercentageLDF entity)
        {
            return _mapper.Map<SecondFourtyPercentageLDFVM>(entity);
        }

        public override IList<SecondFourtyPercentageLDFVM> CastEntityToModel(IQueryable<SecondFourtyPercentageLDF> entity)
        {
            return _mapper.Map<IList<SecondFourtyPercentageLDFVM>>(entity).ToList();
        }
    }
}