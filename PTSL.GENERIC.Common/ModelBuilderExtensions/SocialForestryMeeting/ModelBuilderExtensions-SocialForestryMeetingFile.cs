using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Common.Entity.Capacity;
using PTSL.GENERIC.Common.Entity.SocialForestryMeeting;
using PTSL.GENERIC.Common.Entity.SocialForestryTraining;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions;

public static partial class EntityModelBuilderExtensions
{
    public static void ConfigureSocialForestryMeetingFile(this ModelBuilder builder)
    {
        builder.Entity<SocialForestryMeetingFile>(e =>
        {
            e.ToTable($"{nameof(SocialForestryMeetingFile)}s", SchemaNames.SocialForestryMeeting);

            e.Property(x => x.FileName)
                   .HasColumnType("text")
                   .IsRequired(false);

            e.Property(x => x.FileNameUrl)
                .HasColumnType("text")
                .IsRequired(false);

            e.Property(x => x.FileType)
                .IsRequired();

        });

        builder.Entity<SocialForestryMeetingFile>()
              .HasOne(x => x.SocialForestryMeeting)
              .WithMany(x => x.SocialForestryMeetingFiles)
              .HasForeignKey(x => x.SocialForestryMeetingId)
              .IsRequired();

        builder.Entity<SocialForestryMeetingFile>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
    }
}