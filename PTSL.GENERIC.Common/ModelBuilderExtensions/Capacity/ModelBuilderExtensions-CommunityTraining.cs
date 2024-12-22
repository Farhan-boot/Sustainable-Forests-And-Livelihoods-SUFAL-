using Microsoft.EntityFrameworkCore;
using PTSL.GENERIC.Common.Entity.Capacity;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions
{
    public static partial class EntityModelBuilderExtensions
    {
        public static void ConfigureCommunityTraining(this ModelBuilder builder)
        {
            builder.Entity<CommunityTraining>(e =>
            {
                e.ToTable($"{nameof(CommunityTraining)}s", "Capacity");

                e.Property(x => x.TrainingTitle)
                    .HasColumnType("varchar(500)")
                    .IsRequired(false);

                e.Property(x => x.TrainingTitleBn)
                    .HasColumnType("varchar(500)")
                    .IsRequired(false);

                e.Property(x => x.StartDate)
                    .IsRequired();

                e.Property(x => x.EndDate)
                    .IsRequired();

                e.Property(x => x.UnionId)
                    .HasDefaultValue(null)
                    .IsRequired(false);

                e.Property(x => x.TrainingDuration)
                    .HasColumnType("varchar(200)")
                    .IsRequired();

                e.Property(x => x.Location)
                    .HasColumnType("varchar(500)")
                    .IsRequired(false);

                e.Property(x => x.LocationBn)
                    .HasColumnType("varchar(500)")
                    .IsRequired(false);

                e.Property(x => x.TrainerName)
                    .HasColumnType("varchar(500)")
                    .IsRequired(false);

                e.Property(x => x.CommunityTrainingTypeId)
                    .IsRequired(false)
                    .HasDefaultValue(null);

                e.Property(x => x.TrainingOrganizerId)
                    .IsRequired(false);
            });

            builder.Entity<CommunityTraining>()
                .HasOne(x => x.ForestCircle)
                .WithMany(x => x.CommunityTrainings)
                .HasForeignKey(x => x.ForestCircleId)
                .IsRequired();
            builder.Entity<CommunityTraining>()
                .HasOne(x => x.ForestDivision)
                .WithMany(x => x.CommunityTrainings)
                .HasForeignKey(x => x.ForestDivisionId)
                .IsRequired();
            builder.Entity<CommunityTraining>()
                .HasOne(x => x.ForestRange)
                .WithMany(x => x.CommunityTrainings)
                .HasForeignKey(x => x.ForestRangeId)
                .IsRequired();
            builder.Entity<CommunityTraining>()
                .HasOne(x => x.ForestBeat)
                .WithMany(x => x.CommunityTrainings)
                .HasForeignKey(x => x.ForestBeatId)
                .IsRequired();
            builder.Entity<CommunityTraining>()
                .HasOne(x => x.ForestFcvVcf)
                .WithMany(x => x.CommunityTrainings)
                .HasForeignKey(x => x.ForestFcvVcfId)
                .IsRequired();

            builder.Entity<CommunityTraining>()
                .HasOne(x => x.Division)
                .WithMany(x => x.CommunityTrainings)
                .HasForeignKey(x => x.DivisionId)
                .IsRequired();
            builder.Entity<CommunityTraining>()
                .HasOne(x => x.District)
                .WithMany(x => x.CommunityTrainings)
                .HasForeignKey(x => x.DistrictId)
                .IsRequired();
            builder.Entity<CommunityTraining>()
                .HasOne(x => x.Upazilla)
                .WithMany(x => x.CommunityTrainings)
                .HasForeignKey(x => x.UpazillaId)
                .IsRequired();
            builder.Entity<CommunityTraining>()
                .HasOne(x => x.Union)
                .WithMany(x => x.CommunityTrainings)
                .HasForeignKey(x => x.UnionId)
                .IsRequired(false);

            builder.Entity<CommunityTraining>()
                .HasOne(x => x.EventType)
                .WithMany(x => x.CommunityTrainings)
                .HasForeignKey(x => x.EventTypeId)
                .IsRequired();
            builder.Entity<CommunityTraining>()
                .HasOne(x => x.CommunityTrainingType)
                .WithMany(x => x.CommunityTrainings)
                .HasForeignKey(x => x.CommunityTrainingTypeId)
                .IsRequired(false);
            builder.Entity<CommunityTraining>()
                .HasOne(x => x.TrainingOrganizer)
                .WithMany(x => x.CommunityTrainings)
                .HasForeignKey(x => x.TrainingOrganizerId)
                .IsRequired();

			builder.Entity<CommunityTraining>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
        }
    }
}
