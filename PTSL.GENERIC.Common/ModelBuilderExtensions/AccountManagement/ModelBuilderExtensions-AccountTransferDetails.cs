using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Common.Entity.AccountManagement;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions;

public static partial class EntityModelBuilderExtensions
{
    public static void ConfigureAccountTransferDetails(this ModelBuilder builder)
    {
        builder.Entity<AccountTransferDetails>(e =>
        {
            e.ToTable(nameof(AccountTransferDetails), SchemaNames.AccountManagement);
        });

        builder.Entity<AccountTransferDetails>()
            .HasOne(x => x.AccountTransfer)
            .WithMany(x => x.AccountTransferDetails)
            .HasForeignKey(x => x.AccountTransferId)
            .IsRequired()
            .OnDelete(DeleteBehavior.NoAction);

        builder.Entity<AccountTransferDetails>()
            .HasOne(x => x.SourceOfFund)
            .WithMany(x => x.AccountTransferDetails)
            .HasForeignKey(x => x.SourceOfFundId)
            .IsRequired();

        builder.Entity<AccountTransferDetails>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
    }
}