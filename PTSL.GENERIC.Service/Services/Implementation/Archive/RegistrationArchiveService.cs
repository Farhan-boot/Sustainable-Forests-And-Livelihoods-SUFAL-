using AutoMapper;

using PTSL.GENERIC.Business.Businesses.Interface;
using PTSL.GENERIC.Business.Businesses.Interface.Archive;
using PTSL.GENERIC.Common.Entity.Archive;
using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Entity.MeetingManagement;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model.EntityViewModels.Archive;
using PTSL.GENERIC.Common.Model.EntityViewModels.Capacity;
using PTSL.GENERIC.Service.BaseServices;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTSL.GENERIC.Service.Services.Archive
{
    public class RegistrationArchiveService : BaseService<RegistrationArchiveVM, RegistrationArchive>, IRegistrationArchiveService
    {
        public IMapper _mapper;
        private readonly IRegistrationArchiveBusiness _business;
        public RegistrationArchiveService(IRegistrationArchiveBusiness business, IMapper mapper) : base(business)
        {
            _business = business;
            _mapper = mapper;
        }

        public override RegistrationArchive CastModelToEntity(RegistrationArchiveVM model)
        {
            return _mapper.Map<RegistrationArchive>(model);
        }

        public override RegistrationArchiveVM CastEntityToModel(RegistrationArchive entity)
        {
            return _mapper.Map<RegistrationArchiveVM>(entity);
        }

        public override IList<RegistrationArchiveVM> CastEntityToModel(IQueryable<RegistrationArchive> entity)
        {
            return _mapper.Map<IList<RegistrationArchiveVM>>(entity).ToList();
        }


        public List<RegistrationArchiveVM> CastEntityListToModel(List<RegistrationArchive> entity)
        {
            return _mapper.Map<List<RegistrationArchiveVM>>(entity);
        }

        public async Task<(ExecutionState executionState, List<RegistrationArchiveVM> entity, string message)> GetRegistrationArchiveByFilter(MeetingFilterVM filterData)
        {
            var result = await _business.GetRegistrationArchiveByFilter(filterData);

            if (result.entity is not null)
            {
                return (result.executionState, CastEntityListToModel(result.entity), result.message);
            }

            return (result.executionState, new List<RegistrationArchiveVM>(), result.message);
        }

    }
}