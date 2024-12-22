using Microsoft.EntityFrameworkCore;
using PTSL.GENERIC.Common.Entity.Capacity;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions
{
    public static partial class EntityModelBuilderExtensions
    {
        public static void ConfigureCommunityTrainingFile(this ModelBuilder builder)
        {
            builder.Entity<CommunityTrainingFile>(e =>
            {
                e.ToTable($"{nameof(CommunityTrainingFile)}s", "Capacity");

                e.Property(x => x.FileName)
                    .HasColumnType("text")
                    .IsRequired(false);

                e.Property(x => x.FileNameUrl)
                    .HasColumnType("text")
                    .IsRequired(false);

                e.Property(x => x.FileType)
                    .IsRequired();
            });

            builder.Entity<CommunityTrainingFile>()
                .HasOne(x => x.CommunityTraining)
                .WithMany(x => x.CommunityTrainingFiles)
                .HasForeignKey(x => x.CommunityTrainingId)
                .IsRequired();

			builder.Entity<CommunityTrainingFile>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
        }
    }
}
