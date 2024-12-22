﻿using System.Collections.Generic;

using PTSL.GENERIC.Common.Helper;
using PTSL.GENERIC.Common.Model.BaseModels;

namespace PTSL.GENERIC.Common.Entity.AIG;

public class FirstSixtyPercentageLDFVM : BaseModel
{
    public long AIGBasicInformationId { get; set; }
    [SwaggerExclude]
    public AIGBasicInformationVM? AIGBasicInformation { get; set; }

    public bool HasGrace { get; set; }
    public int GraceMonth { get; set; }

    public double LDFAmount { get; set; }
    public double ServiceChargeAmount { get; set; }
    public double SecurityChargeAmount { get; set; }

    // Percentage
    public double ServiceChargePercentage { get; set; }
    public double SecurityChargePercentage { get; set; }

    // Land Marks
    public bool IsAgreeToInvestInOwnIncomeActivities { get; set; }
    public bool ShallAdhereTheCOM { get; set; }
    public bool IsAttendedEightyPercentageOfMeetings { get; set; }
    public bool IsFirstInstallmentIsCertifiedBySocialAuditCommittee { get; set; }
    public bool HasBankAccountInHisOwnName { get; set; }
    public bool IsPayingRegularIncomingInstallments { get; set; }
    public bool IsAgreedToKeepIncomeAndExpenditureFund { get; set; }

    [SwaggerExclude]
    public List<RepaymentLDFVM>? RepaymentLDFs { get; set; }
}
