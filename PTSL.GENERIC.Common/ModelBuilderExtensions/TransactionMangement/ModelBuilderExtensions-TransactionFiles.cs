using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Common.Entity.TransactionMangement;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions;

public static partial class EntityModelBuilderExtensions
{
    public static void ConfigureTransactionFiles(this ModelBuilder builder)
    {
        builder.Entity<TransactionFiles>(e =>
        {
            e.ToTable(nameof(TransactionFiles), SchemaNames.TRANSACTION);
        });

        builder.Entity<TransactionFiles>()
            .HasOne(x => x.Transaction)
            .WithMany(x => x.TransactionFiles)
            .HasForeignKey(x => x.TransactionId)
            .IsRequired();

        builder.Entity<TransactionFiles>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
    }
}