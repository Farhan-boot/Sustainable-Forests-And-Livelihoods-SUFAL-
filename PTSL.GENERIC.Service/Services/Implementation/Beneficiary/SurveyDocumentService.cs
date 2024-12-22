using AutoMapper;

using PTSL.GENERIC.Business.Businesses.Interface.Beneficiary;
using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Model.EntityViewModels.Beneficiary;
using PTSL.GENERIC.Service.BaseServices;

using System;
using System.Collections.Generic;
using System.Linq;

namespace PTSL.GENERIC.Service.Services.Beneficiary
{
    public class SurveyDocumentService : BaseService<SurveyDocumentVM, SurveyDocument>, ISurveyDocumentService
    {
        public IMapper _mapper;

        public SurveyDocumentService(ISurveyDocumentBusiness business, IMapper mapper) : base(business)
        {
            _mapper = mapper;
        }

        public override SurveyDocument CastModelToEntity(SurveyDocumentVM model)
        {
            return _mapper.Map<SurveyDocument>(model);
        }

        public override SurveyDocumentVM CastEntityToModel(SurveyDocument entity)
        {
            return _mapper.Map<SurveyDocumentVM>(entity);
        }

        public override IList<SurveyDocumentVM> CastEntityToModel(IQueryable<SurveyDocument> entity)
        {
            return _mapper.Map<IList<SurveyDocumentVM>>(entity).ToList();
        }
    }
}