using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using PTSL.GENERIC.Common.Entity.AIG;
using PTSL.GENERIC.Common.Entity.InternalLoan;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model;
using PTSL.GENERIC.Common.Model.EntityViewModels.AIG;
using PTSL.GENERIC.Common.Model.EntityViewModels.Beneficiary;
using PTSL.GENERIC.Service.Services.AIG;
using PTSL.GENERIC.Service.Services.InternalLoan;

namespace PTSL.GENERIC.Api.Controllers.InternalLoan
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class InternalLoanInformationFileController : BaseController<IInternalLoanInformationFileService, InternalLoanInformationFileVM, InternalLoanInformationFile>
    {
        private readonly IInternalLoanInformationFileService _service;

        public InternalLoanInformationFileController(IInternalLoanInformationFileService service) :
            base(service)
        {
            _service = service;
        }
      
    }
}
