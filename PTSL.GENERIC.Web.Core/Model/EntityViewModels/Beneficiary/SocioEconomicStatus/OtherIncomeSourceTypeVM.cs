﻿namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.Beneficiary;

public class OtherIncomeSourceTypeVM : BaseModel
{
    public string Name { get; set; }
    public string NameBn { get; set; }

    public List<OtherIncomeSourceVM>? OtherIncomeSources { get; set; }
}