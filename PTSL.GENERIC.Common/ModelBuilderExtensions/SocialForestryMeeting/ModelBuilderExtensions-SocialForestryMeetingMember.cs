using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Common.Entity.Capacity;
using PTSL.GENERIC.Common.Entity.SocialForestryMeeting;
using PTSL.GENERIC.Common.Entity.SocialForestryTraining;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions;

public static partial class EntityModelBuilderExtensions
{
    public static void ConfigureSocialForestryMeetingMember(this ModelBuilder builder)
    {
        builder.Entity<SocialForestryMeetingMember>(e =>
        {
            e.ToTable($"{nameof(SocialForestryMeetingMember)}s", SchemaNames.SocialForestryMeeting);

            e.Property(x => x.MemberName)
                    .HasColumnType("varchar(500)")
                    .IsRequired();

            e.Property(x => x.MemberGender)
               .IsRequired();

            e.Property(x => x.MemberPhoneNumber)
                .HasColumnType("varchar(30)")
                .IsRequired(false);

            e.Property(x => x.MemberNID)
                .HasColumnType("varchar(100)")
                .IsRequired(false);

            e.Property(x => x.MemberDesignation)
                .HasColumnType("varchar(500)")
                .IsRequired(false);

            e.Property(x => x.MemberOrganization)
                .HasColumnType("varchar(800)")
                .IsRequired(false);

            e.Property(x => x.EthnicityId)
                .IsRequired(false)
                .HasDefaultValue(null);

            e.Property(x => x.MemberAddress)
                .IsRequired(false)
                .HasDefaultValue(null);


           //New Fild
            e.Property(x => x.PlantationId)
                   .IsRequired(false);

            e.Property(x => x.PlantationName)
                  .HasColumnType("varchar(500)")
                  .IsRequired(false);
        });

        builder.Entity<SocialForestryMeetingMember>()
              .HasOne(x => x.Ethnicity)
              .WithMany(x => x.SocialForestryMeetingMember)
              .HasForeignKey(x => x.EthnicityId)
              .IsRequired(false);

        builder.Entity<SocialForestryMeetingMember>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
    }
}