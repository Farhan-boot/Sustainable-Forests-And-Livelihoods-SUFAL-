using PTSL.GENERIC.Common.Entity.CommonEntity;

namespace PTSL.GENERIC.Common.Entity.TransactionMangement;

public class FundType : BaseEntity
{
    public string? Name { get; set; }
    public string? NameBn { get; set; }
    public bool IsCdf { get; set; }

    public List<Transaction>? Transactions { get; set; }
}
