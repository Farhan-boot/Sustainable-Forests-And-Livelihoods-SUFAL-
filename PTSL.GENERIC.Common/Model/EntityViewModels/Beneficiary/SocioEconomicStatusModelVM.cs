using PTSL.GENERIC.Common.Entity.Beneficiary;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTSL.GENERIC.Common.Model.EntityViewModels.Beneficiary
{
	public class SocioEconomicStatusModelVM
	{
		public List<GrossMarginIncomeAndCostStatusVM>? GrossMarginIncomeAndCostStatus { get; set; }
		public List<ManualPhysicalWorkVM>? ManualPhysicalWorks { get; set; }
		public List<NaturalResourcesIncomeAndCostStatusVM>? NaturalResourcesIncomeAndCosts { get; set; }
		public List<OtherIncomeSourceVM>? OtherIncomeSources { get; set; }
		public List<BusinessVM>? Businesses { get; set; }
	}

	public class SocioEconomicStatusModel
	{
		public List<GrossMarginIncomeAndCostStatus>? GrossMarginIncomeAndCostStatus { get; set; }
		public List<ManualPhysicalWork>? ManualPhysicalWorks { get; set; }
		public List<NaturalResourcesIncomeAndCostStatus>? NaturalResourcesIncomeAndCosts { get; set; }
		public List<OtherIncomeSource>? OtherIncomeSources { get; set; }
		public List<Business>? Businesses { get; set; }
	}
}
