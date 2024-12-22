using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Common.Entity.TransactionMangement;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions;

public static partial class EntityModelBuilderExtensions
{
    public static void ConfigureFundType(this ModelBuilder builder)
    {
        builder.Entity<FundType>(e =>
        {
            e.ToTable($"{nameof(FundType)}s", SchemaNames.TRANSACTION);

            e.Property(x => x.Name)
                .HasColumnType("varchar(500)")
                .IsRequired(false);
            e.Property(x => x.NameBn)
                .HasColumnType("varchar(500)")
                .IsRequired(false);
        });

        builder.Entity<FundType>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
    }
}
