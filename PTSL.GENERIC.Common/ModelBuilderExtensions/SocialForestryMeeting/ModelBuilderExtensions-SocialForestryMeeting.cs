using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Common.Entity.Capacity;
using PTSL.GENERIC.Common.Entity.ForestManagement;
using PTSL.GENERIC.Common.Entity.SocialForestryMeeting;
using PTSL.GENERIC.Common.Entity.SocialForestryTraining;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions;

public static partial class EntityModelBuilderExtensions
{
    public static void ConfigureSocialForestryMeeting(this ModelBuilder builder)
    {
        builder.Entity<SocialForestryMeeting>(e =>
        {
            e.ToTable($"{nameof(SocialForestryMeeting)}s", SchemaNames.SocialForestryMeeting);

            e.Property(x => x.MeetingTitle)
                    .HasColumnType("varchar(500)")
                    .IsRequired(false);

            e.Property(x => x.MeetingTitleBn)
                .HasColumnType("varchar(500)")
                .IsRequired(false);

            e.Property(x => x.Venue)
               .HasColumnType("varchar(500)")
               .IsRequired(false);

            e.Property(x => x.StartTime)
                .IsRequired();

            e.Property(x => x.EndTime)
                .IsRequired();

            e.Property(x => x.MeetingDate)
               .IsRequired();

            e.Property(x => x.MeetingOrganizer)
              .HasColumnType("varchar(500)")
              .IsRequired(false);

            //Extra
            e.Property(x => x.TotalMembers)
                .IsRequired();
            e.Property(x => x.TotalMale)
                .IsRequired();
            e.Property(x => x.TotalFemale)
                .IsRequired();

            e.Property(x => x.MeetingTypeForSocialForestryMeetingId)
                .IsRequired(false);

        });

        
        builder.Entity<SocialForestryMeeting>()
                .HasOne(x => x.MeetingTypeForSocialForestryMeeting)
                .WithMany(x => x.SocialForestryMeetings)
                .HasForeignKey(x => x.MeetingTypeForSocialForestryMeetingId)
                .IsRequired(false);

        builder.Entity<SocialForestryMeeting>()
            .HasOne(x => x.Ngo)
            .WithMany(x => x.SocialForestryMeetings)
            .HasForeignKey(x => x.NgoId)
            .IsRequired(false);

        //Forest
        builder.Entity<SocialForestryMeeting>()
            .HasOne(x => x.ForestCircle)
            .WithMany(x => x.SocialForestryMeetings)
            .HasForeignKey(x => x.ForestCircleId)
            .IsRequired(false);

        builder.Entity<SocialForestryMeeting>()
           .HasOne(x => x.ForestDivision)
           .WithMany(x => x.SocialForestryMeetings)
           .HasForeignKey(x => x.ForestDivisionId)
           .IsRequired(false);

        builder.Entity<SocialForestryMeeting>()
         .HasOne(x => x.ForestRange)
         .WithMany(x => x.SocialForestryMeetings)
         .HasForeignKey(x => x.ForestRangeId)
         .IsRequired(false);

        builder.Entity<SocialForestryMeeting>()
          .HasOne(x => x.ForestBeat)
          .WithMany(x => x.SocialForestryMeetings)
          .HasForeignKey(x => x.ForestBeatId)
          .IsRequired(false);

        //Civil
        builder.Entity<SocialForestryMeeting>()
                 .HasOne(x => x.Division)
                 .WithMany(x => x.SocialForestryMeetings)
                 .HasForeignKey(x => x.DivisionId)
                 .IsRequired(false);

        builder.Entity<SocialForestryMeeting>()
                .HasOne(x => x.District)
                .WithMany(x => x.SocialForestryMeetings)
                .HasForeignKey(x => x.DistrictId)
                .IsRequired(false);

        builder.Entity<SocialForestryMeeting>()
               .HasOne(x => x.Upazilla)
               .WithMany(x => x.SocialForestryMeetings)
               .HasForeignKey(x => x.UpazillaId)
               .IsRequired(false);

        builder.Entity<SocialForestryMeeting>()
               .HasOne(x => x.Union)
               .WithMany(x => x.SocialForestryMeetings)
               .HasForeignKey(x => x.UnionId)
               .IsRequired(false);
        //Extra End

        builder.Entity<SocialForestryMeeting>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
    }
}