using AutoMapper;

using PTSL.GENERIC.Business.Businesses.Interface.AIG;
using PTSL.GENERIC.Business.Businesses.Interface.InternalLoan;
using PTSL.GENERIC.Common.Entity.AIG;
using PTSL.GENERIC.Common.Entity.InternalLoan;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model.EntityViewModels.AIG;
using PTSL.GENERIC.Service.BaseServices;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTSL.GENERIC.Service.Services.InternalLoan
{
    public class InternalLoanInformationFileService : BaseService<InternalLoanInformationFileVM, InternalLoanInformationFile>, IInternalLoanInformationFileService
    {
        private readonly IInternalLoanInformationFileBusiness _business;
        public IMapper _mapper;

        public InternalLoanInformationFileService(IInternalLoanInformationFileBusiness business, IMapper mapper) : base(business)
        {
            _business = business;
            _mapper = mapper;
        }

        public override InternalLoanInformationFile CastModelToEntity(InternalLoanInformationFileVM model)
        {
            return _mapper.Map<InternalLoanInformationFile>(model);
        }

        public override InternalLoanInformationFileVM CastEntityToModel(InternalLoanInformationFile entity)
        {
            return _mapper.Map<InternalLoanInformationFileVM>(entity);
        }

        public override IList<InternalLoanInformationFileVM> CastEntityToModel(IQueryable<InternalLoanInformationFile> entity)
        {
            return _mapper.Map<IList<InternalLoanInformationFileVM>>(entity).ToList();
        }

        public IList<InternalLoanInformationFileVM> CastEntityListToModel(IList<InternalLoanInformationFile> entity)
        {
            return _mapper.Map<IList<InternalLoanInformationFileVM>>(entity);
        }

       

    }
}