using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Common.Entity.SocialForestryTraining;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions;

public static partial class EntityModelBuilderExtensions
{
    public static void ConfigureTrainerDesignationForTraining(this ModelBuilder builder)
    {
        builder.Entity<TrainerDesignationForTraining>(e =>
        {
            e.ToTable($"{nameof(TrainerDesignationForTraining)}s", SchemaNames.SocialForestryTraining);
        });

        builder.Entity<TrainerDesignationForTraining>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
    }
}