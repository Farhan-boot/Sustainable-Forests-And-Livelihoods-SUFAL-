using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Common.Entity.GeneralSetup;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions;

public static partial class EntityModelBuilderExtensions
{
    public static void ConfigureFinancialYear(this ModelBuilder builder)
    {
        builder.Entity<FinancialYear>(e =>
        {
            e.ToTable($"{nameof(FinancialYear)}s", SchemaNames.GENERAL_SETUP);

            e.Property(x => x.Name)
                .HasColumnType("varchar(500)")
                .IsRequired(false);
            e.Property(x => x.NameBn)
                .HasColumnType("varchar(500)")
                .IsRequired(false);
        });

        builder.Entity<FinancialYear>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
    }
}
