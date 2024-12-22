using Microsoft.EntityFrameworkCore;
using PTSL.GENERIC.Common.Entity.MeetingManagement;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions
{
    public static partial class EntityModelBuilderExtensions
    {
        public static void ConfigureMeetingFile(this ModelBuilder builder)
        {
            builder.Entity<MeetingFile>(e =>
            {
                e.ToTable($"{nameof(MeetingFile)}s", "Meeting");

                e.Property(x => x.FileName)
                    .HasColumnType("text")
                    .IsRequired(false);

                e.Property(x => x.FileNameUrl)
                    .HasColumnType("text")
                    .IsRequired(false);

                e.Property(x => x.FileType)
                    .IsRequired();
            });

            builder.Entity<MeetingFile>()
                .HasOne(x => x.Meeting)
                .WithMany(x => x.MeetingFiles)
                .HasForeignKey(x => x.MeetingId)
                .IsRequired();

			builder.Entity<MeetingFile>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
        }
    }
}
