using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Common.Entity.Capacity;
using PTSL.GENERIC.Common.Entity.SocialForestryTraining;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions;

public static partial class EntityModelBuilderExtensions
{
    public static void ConfigureSocialForestryTrainingFile(this ModelBuilder builder)
    {
        builder.Entity<SocialForestryTrainingFile>(e =>
        {
            e.ToTable($"{nameof(SocialForestryTrainingFile)}s", SchemaNames.SocialForestryTraining);

            e.Property(x => x.FileName)
                   .HasColumnType("text")
                   .IsRequired(false);

            e.Property(x => x.FileNameUrl)
                .HasColumnType("text")
                .IsRequired(false);

            e.Property(x => x.FileType)
                .IsRequired();

        });

        builder.Entity<SocialForestryTrainingFile>()
              .HasOne(x => x.SocialForestryTraining)
              .WithMany(x => x.SocialForestryTrainingFiles)
              .HasForeignKey(x => x.SocialForestryTrainingId)
              .IsRequired();

        builder.Entity<SocialForestryTrainingFile>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
    }
}