using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Common.Entity.Labour;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions
{
    public static partial class EntityModelBuilderExtensions
    {
        public static void ConfigureOtherLabourMember(this ModelBuilder builder)
        {
            builder.Entity<OtherLabourMember>(ac =>
            {
                ac.ToTable("OtherLabourMembers", SchemaNames.LABOUR);

                ac.Property(a => a.FullName)
                    .HasColumnType("varchar(500)")
                    .IsRequired();
                ac.Property(a => a.Gender)
                    .IsRequired();

                ac.Property(a => a.PhoneNumber)
                    .IsRequired(false);
                ac.Property(a => a.NID)
                    .HasColumnType("varchar(100)")
                    .IsRequired(false);
            });

            builder.Entity<OtherLabourMember>()
                .HasOne(x => x.Ethnicity)
                .WithMany(x => x.OtherLabourMembers)
                .HasForeignKey(x => x.EthnicityId)
                .IsRequired(false);

            builder.Entity<OtherLabourMember>().HasQueryFilter(x => !x.IsDeleted && x.IsActive);
        }
    }
}
