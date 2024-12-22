using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Common.Entity.AccountManagement;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions;

public static partial class EntityModelBuilderExtensions
{
    public static void ConfigureAccountTransferApproval(this ModelBuilder builder)
    {
        builder.Entity<AccountTransferApproval>(e =>
        {
            e.ToTable($"{nameof(AccountTransferApproval)}s", SchemaNames.AccountManagement);
        });

        builder.Entity<AccountTransferApproval>()
            .HasOne(x => x.Row)
            .WithMany(x => x.AccountTransferApprovals)
            .HasForeignKey(x => x.RowId);

        builder.Entity<AccountTransferApproval>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
    }
}