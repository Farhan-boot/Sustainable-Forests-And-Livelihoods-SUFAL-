using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.SocialForestry
{
    public class NurseryFilterVM : ForestCivilLocationFilter
    {
        public long? FinancialYearId { get; set; }
        public long? NurseryId { get; set; }
        public string? BeneficiaryName { get; set; }
        public string? BeneficiaryNid { get; set; }

        public DateTime? DistributionDate { get; set; }

        public DateTime? DistributionDateFrom { get; set; }
        public DateTime? DistributionDateTo { get; set; }
    }
}
