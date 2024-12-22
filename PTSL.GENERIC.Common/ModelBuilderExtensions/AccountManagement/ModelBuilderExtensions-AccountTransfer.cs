using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Common.Entity.AccountManagement;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions;

public static partial class EntityModelBuilderExtensions
{
    public static void ConfigureAccountTransfer(this ModelBuilder builder)
    {
        builder.Entity<AccountTransfer>(e =>
        {
            e.ToTable($"{nameof(AccountTransfer)}s", SchemaNames.AccountManagement);
        });

        builder.Entity<AccountTransfer>()
            .HasOne(x => x.FromAccount)
            .WithMany(x => x.FromAccountTransfers)
            .HasForeignKey(x => x.FromAccountId)
            .IsRequired()
            .OnDelete(DeleteBehavior.NoAction);

        builder.Entity<AccountTransfer>()
            .HasOne(x => x.ToAccount)
            .WithMany(x => x.ToAccountTransfers)
            .HasForeignKey(x => x.ToAccountId)
            .IsRequired()
            .OnDelete(DeleteBehavior.NoAction);

        builder.Entity<AccountTransfer>()
            .HasOne(x => x.FinancialYear)
            .WithMany(x => x.AccountTransfers)
            .HasForeignKey(x => x.FinancialYearId)
            .IsRequired()
            .OnDelete(DeleteBehavior.NoAction);

        builder.Entity<AccountTransfer>()
            .HasOne(x => x.TransferRequestedBy)
            .WithMany(x => x.AccountTransfers)
            .HasForeignKey(x => x.TransferRequestedById)
            .IsRequired();

        builder.Entity<AccountTransfer>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
    }
}