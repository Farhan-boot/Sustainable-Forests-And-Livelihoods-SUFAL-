using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Common.Entity.AccountManagement;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions;

public static partial class EntityModelBuilderExtensions
{
    public static void ConfigureAccountDeposit(this ModelBuilder builder)
    {
        builder.Entity<AccountDeposit>(e =>
        {
            e.ToTable($"{nameof(AccountDeposit)}s", SchemaNames.AccountManagement);
        });

        builder.Entity<AccountDeposit>()
            .HasOne(x => x.Account)
            .WithMany(x => x.AccountDeposits)
            .HasForeignKey(x => x.AccountId)
            .IsRequired();

        builder.Entity<AccountDeposit>()
            .HasOne(x => x.FinancialYear)
            .WithMany(x => x.AccountDeposits)
            .HasForeignKey(x => x.FinancialYearId)
            .IsRequired();

        builder.Entity<AccountDeposit>()
            .HasOne(x => x.SourceOfFund)
            .WithMany(x => x.AccountDeposits)
            .HasForeignKey(x => x.SourceOfFundId)
            .IsRequired();

        builder.Entity<AccountDeposit>()
            .HasOne(x => x.TransactionBy)
            .WithMany(x => x.AccountDeposits)
            .HasForeignKey(x => x.TransactionById)
            .IsRequired();

        builder.Entity<AccountDeposit>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
    }
}