using Microsoft.EntityFrameworkCore;
using PTSL.GENERIC.Common.Entity.MeetingManagement;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions
{
    public static partial class EntityModelBuilderExtensions
    {
        public static void ConfigureMeeting(this ModelBuilder builder)
        {
            builder.Entity<Meeting>(e =>
            {
                e.ToTable($"{nameof(Meeting)}s", "Meeting");

                e.Property(x => x.MeetingTitle)
                    .HasColumnType("text")
                    .IsRequired();
                e.Property(x => x.MeetingDate)
                    .IsRequired();
                e.Property(x => x.StartTime)
                    .IsRequired();
                e.Property(x => x.EndTime)
                    .IsRequired();
                e.Property(x => x.MeetingTypeId)
                    .IsRequired();

                e.Property(x => x.ForestCircleId)
                    .IsRequired();
                e.Property(x => x.ForestDivisionId)
                    .IsRequired();
                e.Property(x => x.ForestRangeId)
                    .IsRequired();
                e.Property(x => x.ForestBeatId)
                    .IsRequired();
                e.Property(x => x.ForestFcvVcfId)
                    .IsRequired();

                e.Property(x => x.DivisionId)
                    .IsRequired();
                e.Property(x => x.DistrictId)
                    .IsRequired();
                e.Property(x => x.UpazillaId)
                    .IsRequired();
                e.Property(x => x.UnionId)
                    .IsRequired(false);
            });

			builder.Entity<Meeting>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);

            builder.Entity<Meeting>()
                .HasOne(x => x.MeetingType)
                .WithMany(x => x.Meetings)
                .HasForeignKey(x => x.MeetingTypeId)
                .IsRequired();

            builder.Entity<Meeting>()
                .HasOne(x => x.ForestCircle)
                .WithMany(x => x.Meetings)
                .HasForeignKey(x => x.ForestCircleId)
                .IsRequired();
            builder.Entity<Meeting>()
                .HasOne(x => x.ForestDivision)
                .WithMany(x => x.Meetings)
                .HasForeignKey(x => x.ForestDivisionId)
                .IsRequired();
            builder.Entity<Meeting>()
                .HasOne(x => x.ForestRange)
                .WithMany(x => x.Meetings)
                .HasForeignKey(x => x.ForestRangeId)
                .IsRequired();
            builder.Entity<Meeting>()
                .HasOne(x => x.ForestBeat)
                .WithMany(x => x.Meetings)
                .HasForeignKey(x => x.ForestBeatId)
                .IsRequired();
            builder.Entity<Meeting>()
                .HasOne(x => x.ForestFcvVcf)
                .WithMany(x => x.Meetings)
                .HasForeignKey(x => x.ForestFcvVcfId)
                .IsRequired();

            builder.Entity<Meeting>()
                .HasOne(x => x.Division)
                .WithMany(x => x.Meetings)
                .HasForeignKey(x => x.DivisionId)
                .IsRequired();
            builder.Entity<Meeting>()
                .HasOne(x => x.District)
                .WithMany(x => x.Meetings)
                .HasForeignKey(x => x.DistrictId)
                .IsRequired();
            builder.Entity<Meeting>()
                .HasOne(x => x.Upazilla)
                .WithMany(x => x.Meetings)
                .HasForeignKey(x => x.UpazillaId)
                .IsRequired();
            builder.Entity<Meeting>()
                .HasOne(x => x.Union)
                .WithMany(x => x.Meetings)
                .HasForeignKey(x => x.UnionId)
                .IsRequired(false);
            builder.Entity<Meeting>()
             .HasOne(x => x.Ngo)
             .WithMany(x => x.Meetings)
             .HasForeignKey(x => x.NgoId)
             .IsRequired(false);

        }
    }
}
