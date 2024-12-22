using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Common.Entity.GeneralSetup;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions
{
    public static partial class EntityModelBuilderExtensions
    {
        public static void ConfigureCommitteeDesignation(this ModelBuilder builder)
        {
            builder.Entity<CommitteeDesignation>(ac =>
            {
                ac.ToTable($"{nameof(CommitteeDesignation)}", "GS");

                ac.Property(a => a.CommitteeType)
                    .IsRequired();
                ac.Property(a => a.SubCommitteeType)
                    .IsRequired(false);

                ac.Property(a => a.Name)
                    .HasColumnType("text")
                    .IsRequired(false);
                ac.Property(a => a.NameBn)
                    .HasColumnType("text")
                    .IsRequired(false);
            });

            builder.Entity<CommitteeDesignation>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
        }
    }
}
