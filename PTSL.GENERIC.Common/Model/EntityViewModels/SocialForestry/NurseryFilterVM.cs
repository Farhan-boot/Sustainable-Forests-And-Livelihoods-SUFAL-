using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PTSL.GENERIC.Common.Model.EntityViewModels;

namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.SocialForestry
{
    public class NurseryFilterVM : ForestCivilLocationFilter
    {
        public long? FinancialYearId { get; set; }
        public bool HasFinancialYearId => FinancialYearId.HasValue && FinancialYearId.Value > 0;
        public long? NurseryId { get; set; }
        public bool HasNurseryId => NurseryId.HasValue && NurseryId.Value > 0;

        public DateTime? DistributionDate { get; set; }
        public bool HasDistributionDate => DistributionDate.HasValue && DistributionDate > DateTime.MinValue;

        public DateTime? DistributionDateFrom { get; set; }
        public bool HasDistributionDateFrom => DistributionDateFrom.HasValue && DistributionDateFrom > DateTime.MinValue;
        public DateTime? DistributionDateTo { get; set; }
        public bool HasDistributionDateTo => DistributionDateTo.HasValue && DistributionDateTo > DateTime.MinValue;

        public string? BeneficiaryName { get; set; }
        public bool HasBeneficiaryName => string.IsNullOrEmpty(BeneficiaryName) == false;
        public string? BeneficiaryNid { get; set; }
        public bool HasBeneficiaryNid => string.IsNullOrEmpty(BeneficiaryNid) == false;
        public string? PlantationId { get; set; }
    }
}
