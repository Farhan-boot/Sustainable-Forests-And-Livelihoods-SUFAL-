using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Common.Entity.TransactionMangement;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions;

public static partial class EntityModelBuilderExtensions
{
    public static void ConfigureTransaction(this ModelBuilder builder)
    {
        builder.Entity<Transaction>(e =>
        {
            e.ToTable($"{nameof(Transaction)}s", SchemaNames.TRANSACTION);

            e.Property(x => x.ForestCircleId)
                .IsRequired();
            e.Property(x => x.ForestDivisionId)
                .IsRequired();

            e.Property(x => x.FromDate)
                .IsRequired();
            e.Property(x => x.ToDate)
                .IsRequired();

            e.Property(x => x.FinancialYearId)
                .IsRequired();
        });

        builder.Entity<Transaction>()
            .HasOne(x => x.ForestCircle)
            .WithMany(x => x.Transactions)
            .HasForeignKey(x => x.ForestCircleId)
            .IsRequired();
        builder.Entity<Transaction>()
            .HasOne(x => x.ForestDivision)
            .WithMany(x => x.Transactions)
            .HasForeignKey(x => x.ForestDivisionId)
            .IsRequired();

        builder.Entity<Transaction>()
            .HasOne(x => x.FinancialYear)
            .WithMany(x => x.Transactions)
            .HasForeignKey(x => x.FinancialYearId)
            .IsRequired();

        builder.Entity<Transaction>()
            .HasOne(x => x.Account)
            .WithMany(x => x.Transactions)
            .HasForeignKey(x => x.AccountId)
            .IsRequired();

        builder.Entity<Transaction>()
            .HasOne(x => x.FundType)
            .WithMany(x => x.Transactions)
            .HasForeignKey(x => x.FundTypeId)
            .IsRequired();

        builder.Entity<Transaction>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
    }
}
