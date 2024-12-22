using Microsoft.EntityFrameworkCore;
using PTSL.GENERIC.Common.Entity.Beneficiary;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions
{
    public static partial class EntityModelBuilderExtensions
    {
        public static void ConfigureHouseholdMember(this ModelBuilder builder)
        {
            builder.Entity<HouseholdMember>(e =>
            {
                e.ToTable($"{nameof(HouseholdMember)}s", "BEN");

                e.Property(x => x.FullName)
                    .HasColumnType("varchar(500)")
                    .IsRequired(false);
                e.Property(x => x.FullNameBn)
                    .HasColumnType("varchar(500)")
                    .IsRequired(false);
                e.Property(x => x.RelationWithHeadHouseHoldTypeTxt)
                    .HasColumnType("varchar(500)")
                    .IsRequired(false);
                e.Property(x => x.Gender)
                    .HasColumnType("smallint")
                    .IsRequired();
                e.Property(x => x.Age)
                    .HasColumnType("varchar(100)")
                    .IsRequired(false);
                e.Property(x => x.AgeBn)
                    .HasColumnType("varchar(100)")
                    .IsRequired(false);
                e.Property(x => x.MaritalSatus)
                    .HasColumnType("smallint")
                    .IsRequired();
                e.Property(x => x.MaritalSatusTxt)
                    .HasColumnType("varchar(100)")
                    .IsRequired(false);
                e.Property(x => x.EducationLevel)
                    .HasColumnType("smallint")
                    .IsRequired();
                e.Property(x => x.MainOccupationTxt)
                    .HasColumnType("varchar(500)")
                    .IsRequired(false);
                e.Property(x => x.SecondOccupationTxt)
                    .HasColumnType("varchar(500)")
                    .IsRequired(false);
                e.Property(x => x.BFDAssociationTxt)
                    .HasColumnType("varchar(500)")
                    .IsRequired(false);
                e.Property(x => x.SubmittedBy)
                    .HasColumnType("varchar(500)")
                    .IsRequired(false);
                e.Property(x => x.Notes)
                    .HasColumnType("varchar(500)")
                    .IsRequired(false);
            });

            builder.Entity<HouseholdMember>()
                .HasOne(x => x.RelationWithHeadHouseHoldType)
                .WithMany(x => x.HouseholdMembers)
                .HasForeignKey(x => x.RelationWithHeadHouseHoldTypeId)
                .IsRequired();
            builder.Entity<HouseholdMember>()
                .HasOne(x => x.MainOccupation)
                .WithMany(x => x.HouseholdMembersMain)
                .HasForeignKey(x => x.MainOccupationId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);
            builder.Entity<HouseholdMember>()
                .HasOne(x => x.SecondaryOccupation)
                .WithMany(x => x.HouseholdMembersSecondary)
                .HasForeignKey(x => x.SecondaryOccupationId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);
            builder.Entity<HouseholdMember>()
                .HasOne(x => x.SafetyNetType)
                .WithMany(x => x.HouseholdMembers)
                .HasForeignKey(x => x.SafetyNetTypeId)
                .IsRequired();
            builder.Entity<HouseholdMember>()
                .HasOne(x => x.Survey)
                .WithMany(x => x.HouseholdMembers)
                .HasForeignKey(x => x.SurveyId)
                .IsRequired();

			builder.Entity<HouseholdMember>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
        }
    }
}
