using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Common.Entity.ForestManagement;
using PTSL.GENERIC.Common.Entity.GeneralSetup;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions
{
    public static partial class EntityModelBuilderExtensions
    {
        public static void ConfigureCommitteeDesignationsConfiguration(this ModelBuilder builder)
        {
            builder.Entity<CommitteeDesignationsConfiguration>(ac =>
            {
                ac.ToTable("CommitteeDesignationsConfiguration", "BEN");

                ac.Property(a => a.DesignationName)
                    .HasColumnType("varchar(500)")
                    .IsRequired(false);
            });

            builder.Entity<CommitteeDesignationsConfiguration>()
              .HasOne(x => x.CommitteesConfiguration)
              .WithMany(x => x.CommitteeDesignationsConfigurations)
              .HasForeignKey(x => x.CommitteesConfigurationId)
              .IsRequired(false);
        }
    }
}
