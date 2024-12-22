using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Common.Entity.TransactionMangement;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions;

public static partial class EntityModelBuilderExtensions
{
    public static void ConfigureExpenseDetailsForCDF(this ModelBuilder builder)
    {
        builder.Entity<ExpenseDetailsForCDF>(e =>
        {
            e.ToTable($"{nameof(ExpenseDetailsForCDF)}s", SchemaNames.TRANSACTION);

            e.Property(x => x.TransactionId).IsRequired();
        });

        builder.Entity<ExpenseDetailsForCDF>()
            .HasOne(x => x.Transaction)
            .WithMany(x => x.ExpenseDetailsForCDFs)
            .HasForeignKey(x => x.TransactionId)
            .IsRequired();

        builder.Entity<ExpenseDetailsForCDF>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
    }
}
