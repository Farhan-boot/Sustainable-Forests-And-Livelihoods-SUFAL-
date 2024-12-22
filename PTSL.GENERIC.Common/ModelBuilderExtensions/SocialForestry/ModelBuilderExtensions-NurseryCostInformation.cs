using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Common.Entity.SocialForestry;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions;

public static partial class EntityModelBuilderExtensions
{
    public static void ConfigureNurseryCostInformation(this ModelBuilder builder)
    {
        builder.Entity<NurseryCostInformation>(e =>
        {
            e.ToTable($"{nameof(NurseryCostInformation)}s", SchemaNames.SocialForestry);
        });

        builder.Entity<NurseryCostInformation>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
    }
}