using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PTSL.GENERIC.Web.Core.Model.GeneralSetup
{
    public class DivisionVM : BaseModel
    {
        public string Name { get; set; }
        public string? NameBn { get; set; }
        public List<DistrictVM>? DistrictList { get; set; }
        //public IList<PermanentAddress> PermanentAddresses { get; set; }
        //public IList<PresentAddress> PresentAddresses { get; set; }
        //public IList<SpouseInformation> SpouseInformation { get; set; }
        //public IList<EmployeeInformation> EmployeeInformation { get; set; }
    }
}
