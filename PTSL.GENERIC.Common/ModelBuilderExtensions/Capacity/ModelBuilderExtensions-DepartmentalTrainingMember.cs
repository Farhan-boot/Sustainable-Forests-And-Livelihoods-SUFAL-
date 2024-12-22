using Microsoft.EntityFrameworkCore;
using PTSL.GENERIC.Common.Entity.Capacity;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions
{
    public static partial class EntityModelBuilderExtensions
    {
        public static void ConfigureDepartmentalTrainingMember(this ModelBuilder builder)
        {
            builder.Entity<DepartmentalTrainingMember>(e =>
            {
                e.ToTable($"{nameof(DepartmentalTrainingMember)}s", "Capacity");

                e.Property(x => x.MemberName)
                    .HasColumnType("varchar(500)")
                    .IsRequired();

                e.Property(x => x.MemberPhoneNumber)
                    .HasColumnType("varchar(30)")
                    .IsRequired(false);

                e.Property(x => x.MemberGender)
                    .IsRequired();

                e.Property(x => x.MemberEmail)
                    .HasColumnType("varchar(200)")
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
            });

            builder.Entity<DepartmentalTrainingMember>()
                .HasOne(x => x.Ethnicity)
                .WithMany(x => x.DepartmentalTrainingMember)
                .HasForeignKey(x => x.EthnicityId)
                .IsRequired(false);

			builder.Entity<DepartmentalTrainingMember>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
        }
    }
}
