using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Common.Entity.SocialForestry;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions;

public static partial class EntityModelBuilderExtensions
{
    public static void ConfigureLandOwningAgency(this ModelBuilder builder)
    {
        builder.Entity<LandOwningAgency>(e =>
        {
            e.ToTable($"{nameof(LandOwningAgency)}s", SchemaNames.SocialForestry);
        });

        builder.Entity<LandOwningAgency>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
    }
}