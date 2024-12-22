using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Common.Entity.ForestManagement;
using PTSL.GENERIC.Common.Entity.GeneralSetup;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions
{
    public static partial class EntityModelBuilderExtensions
    {
        public static void ConfigureCommitteeTypeConfiguration(this ModelBuilder builder)
        {
            builder.Entity<CommitteeTypeConfiguration>(ac =>
            {
                ac.ToTable("CommitteeTypeConfiguration", "BEN");

                ac.Property(a => a.FcvOrVcfTypeId)
                    .IsRequired(false);
                ac.Property(a => a.CommitteeTypeName)
                    .HasColumnType("varchar(500)")
                    .IsRequired(false);
            });
        }
    }
}
