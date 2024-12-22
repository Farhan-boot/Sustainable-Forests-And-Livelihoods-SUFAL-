using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Common.Entity.SocialForestry;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions;

public static partial class EntityModelBuilderExtensions
{
    public static void ConfigureLaborInformation(this ModelBuilder builder)
    {
        builder.Entity<LaborInformation>(e =>
        {
            e.ToTable($"{nameof(LaborInformation)}s", SchemaNames.SocialForestry);
        });

        builder.Entity<LaborInformation>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
    }
}