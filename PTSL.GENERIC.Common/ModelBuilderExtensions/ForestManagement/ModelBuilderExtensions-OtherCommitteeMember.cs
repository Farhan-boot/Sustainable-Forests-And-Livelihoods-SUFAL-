using Microsoft.EntityFrameworkCore;
using PTSL.GENERIC.Common.Entity.ForestManagement;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions
{
    public static partial class EntityModelBuilderExtensions
    {
        public static void ConfigureOtherCommitteeMember(this ModelBuilder builder)
        {
            builder.Entity<OtherCommitteeMember>(ac =>
            {
                ac.ToTable("OtherCommitteeMembers", "BEN");

                ac.Property(a => a.FullName)
                    .HasColumnType("varchar(500)")
                    .IsRequired();
                ac.Property(a => a.Gender)
                    .IsRequired();

                ac.Property(a => a.PhoneNumber)
                    .IsRequired();
                ac.Property(a => a.NID)
                    .HasColumnType("varchar(100)")
                    .IsRequired(false);
                ac.Property(a => a.Address)
                    .HasColumnType("varchar(600)")
                    .IsRequired(false);
            });

            // Forest Administration
            builder.Entity<OtherCommitteeMember>()
                .HasOne(x => x.ForestCircle)
                .WithMany(x => x.OtherCommitteeMembers)
                .HasForeignKey(x => x.ForestCircleId)
                .IsRequired();
            builder.Entity<OtherCommitteeMember>()
                .HasOne(x => x.ForestDivision)
                .WithMany(x => x.OtherCommitteeMembers)
                .HasForeignKey(x => x.ForestDivisionId)
                .IsRequired();
            builder.Entity<OtherCommitteeMember>()
                .HasOne(x => x.ForestRange)
                .WithMany(x => x.OtherCommitteeMembers)
                .HasForeignKey(x => x.ForestRangeId)
                .IsRequired();
            builder.Entity<OtherCommitteeMember>()
                .HasOne(x => x.ForestBeat)
                .WithMany(x => x.OtherCommitteeMembers)
                .HasForeignKey(x => x.ForestBeatId)
                .IsRequired();
            builder.Entity<OtherCommitteeMember>()
                .HasOne(x => x.ForestFcvVcf)
                .WithMany(x => x.OtherCommitteeMembers)
                .HasForeignKey(x => x.ForestFcvVcfId)
                .IsRequired();

            builder.Entity<OtherCommitteeMember>()
                .HasOne(x => x.Ethnicity)
                .WithMany(x => x.OtherCommitteeMembers)
                .HasForeignKey(x => x.EthnicityId)
                .IsRequired(false);

            // Civil Administration
            builder.Entity<OtherCommitteeMember>()
                .HasOne(x => x.Division)
                .WithMany(x => x.OtherCommitteeMembers)
                .HasForeignKey(x => x.DivisionId)
                .IsRequired();
            builder.Entity<OtherCommitteeMember>()
                .HasOne(x => x.District)
                .WithMany(x => x.OtherCommitteeMembers)
                .HasForeignKey(x => x.DistrictId)
                .IsRequired();
            builder.Entity<OtherCommitteeMember>()
                .HasOne(x => x.Upazilla)
                .WithMany(x => x.OtherCommitteeMembers)
                .HasForeignKey(x => x.UpazillaId)
                .IsRequired();
            builder.Entity<OtherCommitteeMember>()
                .HasOne(x => x.Union)
                .WithMany(x => x.OtherCommitteeMembers)
                .HasForeignKey(x => x.UnionId)
                .IsRequired(false);

            builder.Entity<OtherCommitteeMember>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
        }
    }
}
