using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Common.Entity.Capacity;
using PTSL.GENERIC.Common.Entity.SocialForestryTraining;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions;

public static partial class EntityModelBuilderExtensions
{
    public static void ConfigureSocialForestryTrainingParticipentsMap(this ModelBuilder builder)
    {
        builder.Entity<SocialForestryTrainingParticipentsMap>(e =>
        {
            e.ToTable($"{nameof(SocialForestryTrainingParticipentsMap)}s", SchemaNames.SocialForestryTraining);

            e.Property(x => x.SocialForestryTrainingMemberId)
                   .IsRequired();
        });

        builder.Entity<SocialForestryTrainingParticipentsMap>()
               .HasOne(x => x.SocialForestryTrainingMember)
               .WithMany(x => x.SocialForestryTrainingParticipentsMaps)
               .HasForeignKey(x => x.SocialForestryTrainingMemberId)
               .IsRequired();

        builder.Entity<SocialForestryTrainingParticipentsMap>()
            .HasOne(x => x.SocialForestryTraining)
            .WithMany(x => x.SocialForestryTrainingParticipentsMaps)
            .HasForeignKey(x => x.SocialForestryTrainingId)
            .IsRequired();

        builder.Entity<SocialForestryTrainingParticipentsMap>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
    }
}