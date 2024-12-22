using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Common.Entity.SocialForestry.Nursery;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions;

public static partial class EntityModelBuilderExtensions
{
    public static void ConfigureNurseryInformation(this ModelBuilder builder)
    {
        builder.Entity<NurseryInformation>(e =>
        {
            e.ToTable($"{nameof(NurseryInformation)}s", SchemaNames.SocialForestry);
        });

        builder.Entity<NurseryInformation>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
    }
}