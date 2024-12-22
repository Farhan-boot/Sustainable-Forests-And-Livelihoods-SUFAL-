using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Common.Entity.SocialForestryTraining;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions;

public static partial class EntityModelBuilderExtensions
{
    public static void ConfigureTrainingOrganizerForTraining(this ModelBuilder builder)
    {
        builder.Entity<TrainingOrganizerForTraining>(e =>
        {
            e.ToTable($"{nameof(TrainingOrganizerForTraining)}s", SchemaNames.SocialForestryTraining);
        });

        builder.Entity<TrainingOrganizerForTraining>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
    }
}