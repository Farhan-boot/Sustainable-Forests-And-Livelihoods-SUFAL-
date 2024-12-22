using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Common.Entity.ForestManagement;
using PTSL.GENERIC.Common.Entity.GeneralSetup;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions
{
    public static partial class EntityModelBuilderExtensions
    {
        public static void ConfigureCommitteesConfiguration(this ModelBuilder builder)
        {
            builder.Entity<CommitteesConfiguration>(ac =>
            {
                ac.ToTable("CommitteesConfiguration", "BEN");

                ac.Property(a => a.CommitteeName)
                    .HasColumnType("varchar(500)")
                    .IsRequired(false);
            });

            builder.Entity<CommitteesConfiguration>()
              .HasOne(x => x.CommitteeTypeConfiguration)
              .WithMany(x => x.CommitteesConfigurations)
              .HasForeignKey(x => x.CommitteeTypeConfigurationId)
              .IsRequired(false);
        }
    }
}
