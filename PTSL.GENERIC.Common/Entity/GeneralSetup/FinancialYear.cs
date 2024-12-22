using System.Collections.Generic;

using PTSL.GENERIC.Common.Entity.AccountManagement;
using PTSL.GENERIC.Common.Entity.Capacity;
using PTSL.GENERIC.Common.Entity.CommonEntity;
using PTSL.GENERIC.Common.Entity.SocialForestry;
using PTSL.GENERIC.Common.Entity.TransactionMangement;

namespace PTSL.GENERIC.Common.Entity.GeneralSetup;

public class FinancialYear : BaseEntity
{
    public string? Name { get; set; }
    public string? NameBn { get; set; }

    public int StartYear { get; set; }
    public int EndYear { get; set; }

    public List<Transaction>? Transactions { get; set; }
    public List<DepartmentalTraining>? DepartmentalTrainings { get; set; }
    public List<AccountDeposit>? AccountDeposits { get; set; }
    public List<AccountTransfer>? AccountTransfers { get; set; }
    public List<NewRaisedPlantation>? NewRaisedPlantations { get; set; }
}
