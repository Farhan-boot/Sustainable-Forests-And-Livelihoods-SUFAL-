using AutoMapper;

using PTSL.GENERIC.Business.Businesses.Interface.AIG;
using PTSL.GENERIC.Common.Entity.AIG;
using PTSL.GENERIC.Service.BaseServices;

using System;
using System.Collections.Generic;
using System.Linq;

namespace PTSL.GENERIC.Service.Services.AIG
{
    public class FirstSixtyPercentageLDFService : BaseService<FirstSixtyPercentageLDFVM, FirstSixtyPercentageLDF>, IFirstSixtyPercentageLDFService
    {
        public IMapper _mapper;

        public FirstSixtyPercentageLDFService(IFirstSixtyPercentageLDFBusiness business, IMapper mapper) : base(business)
        {
            _mapper = mapper;
        }

        public override FirstSixtyPercentageLDF CastModelToEntity(FirstSixtyPercentageLDFVM model)
        {
            return _mapper.Map<FirstSixtyPercentageLDF>(model);
        }

        public override FirstSixtyPercentageLDFVM CastEntityToModel(FirstSixtyPercentageLDF entity)
        {
            return _mapper.Map<FirstSixtyPercentageLDFVM>(entity);
        }

        public override IList<FirstSixtyPercentageLDFVM> CastEntityToModel(IQueryable<FirstSixtyPercentageLDF> entity)
        {
            return _mapper.Map<IList<FirstSixtyPercentageLDFVM>>(entity).ToList();
        }
    }
}