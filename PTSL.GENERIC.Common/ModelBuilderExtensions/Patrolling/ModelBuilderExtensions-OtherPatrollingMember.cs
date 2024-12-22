using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Entity.BeneficiarySavingsAccount;
using PTSL.GENERIC.Common.Entity.ForestManagement;
using PTSL.GENERIC.Common.Entity.GeneralSetup;
using PTSL.GENERIC.Common.Entity.Patrolling;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions
{
    public static partial class EntityModelBuilderExtensions
    {
        public static void ConfigureOtherPatrollingMember(this ModelBuilder builder)
        {
            builder.Entity<OtherPatrollingMember>(ac =>
            {
                ac.ToTable("OtherPatrollingMember", "Patrolling");

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
            builder.Entity<OtherPatrollingMember>()
                .HasOne(x => x.ForestCircle)
                .WithMany(x => x.OtherPatrollingMembers)
                .HasForeignKey(x => x.ForestCircleId)
                .IsRequired();
            builder.Entity<OtherPatrollingMember>()
                .HasOne(x => x.ForestDivision)
                .WithMany(x => x.OtherPatrollingMembers)
                .HasForeignKey(x => x.ForestDivisionId)
                .IsRequired();
            builder.Entity<OtherPatrollingMember>()
                .HasOne(x => x.ForestRange)
                .WithMany(x => x.OtherPatrollingMembers)
                .HasForeignKey(x => x.ForestRangeId)
                .IsRequired();
            builder.Entity<OtherPatrollingMember>()
                .HasOne(x => x.ForestBeat)
                .WithMany(x => x.OtherPatrollingMembers)
                .HasForeignKey(x => x.ForestBeatId)
                .IsRequired();
            builder.Entity<OtherPatrollingMember>()
                .HasOne(x => x.ForestFcvVcf)
                .WithMany(x => x.OtherPatrollingMembers)
                .HasForeignKey(x => x.ForestFcvVcfId)
                .IsRequired();
            builder.Entity<OtherPatrollingMember>()
                .HasOne(x => x.Ethnicity)
                .WithMany(x => x.OtherPatrollingMembers)
                .HasForeignKey(x => x.EthnicityId)
                .IsRequired(false);

            // Civil Administration
            builder.Entity<OtherPatrollingMember>()
                .HasOne(x => x.Division)
                .WithMany(x => x.OtherPatrollingMembers)
                .HasForeignKey(x => x.DivisionId)
                .IsRequired();
            builder.Entity<OtherPatrollingMember>()
                .HasOne(x => x.District)
                .WithMany(x => x.OtherPatrollingMembers)
                .HasForeignKey(x => x.DistrictId)
                .IsRequired();

            builder.Entity<OtherPatrollingMember>()
                .HasOne(x => x.Upazilla)
                .WithMany(x => x.OtherPatrollingMembers)
                .HasForeignKey(x => x.UpazillaId)
                .IsRequired();

            builder.Entity<OtherPatrollingMember>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
        }
    }
}
