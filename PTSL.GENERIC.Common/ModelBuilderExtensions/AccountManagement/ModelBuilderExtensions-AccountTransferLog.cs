using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Common.Entity.AccountManagement;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions;

public static partial class EntityModelBuilderExtensions
{
    public static void ConfigureAccountTransferLog(this ModelBuilder builder)
    {
        builder.Entity<AccountTransferLog>(e =>
        {
            e.ToTable($"{nameof(AccountTransferLog)}s", SchemaNames.AccountManagement);
        });

        builder.Entity<AccountTransferLog>()
            .HasOne(x => x.AccountTransfer)
            .WithMany(x => x.AccountTransferLogs)
            .HasForeignKey(x => x.AccountTransferId)
            .IsRequired();

        builder.Entity<AccountTransferLog>()
            .HasOne(x => x.AccountTransferDetails)
            .WithMany(x => x.AccountTransferLogs)
            .HasForeignKey(x => x.AccountTransferDetailsId)
            .IsRequired(false);

        builder.Entity<AccountTransferLog>()
            .HasOne(x => x.TransferStatusChangedBy)
            .WithMany(x => x.AccountTransferLogs)
            .HasForeignKey(x => x.TransferStatusChangedById)
            .IsRequired();

        builder.Entity<AccountTransferLog>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
    }
}