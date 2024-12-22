using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Common.Entity.GeneralSetup;
using PTSL.GENERIC.Common.Entity.SocialForestryTraining;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions;

public static partial class EntityModelBuilderExtensions
{
    public static void ConfigureFinancialYearForTraining(this ModelBuilder builder)
    {
        builder.Entity<FinancialYearForTraining>(e =>
        {
            e.ToTable($"{nameof(FinancialYearForTraining)}s", SchemaNames.SocialForestryTraining);

            e.Property(x => x.Name)
                .HasColumnType("varchar(500)")
                .IsRequired(false);
            e.Property(x => x.NameBn)
                .HasColumnType("varchar(500)")
                .IsRequired(false);
        });

        builder.Entity<FinancialYearForTraining>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
    }
}
