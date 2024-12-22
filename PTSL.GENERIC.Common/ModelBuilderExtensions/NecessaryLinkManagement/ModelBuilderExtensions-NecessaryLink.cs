using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Common.Entity.CipManagement;
using PTSL.GENERIC.Common.Entity.ForestManagement;
using PTSL.GENERIC.Common.Entity.GeneralSetup;
using PTSL.GENERIC.Common.Entity.NecessaryLinkManagement;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions
{
    public static partial class EntityModelBuilderExtensions
    {
        public static void ConfigureNecessaryLink(this ModelBuilder builder)
        {
            builder.Entity<NecessaryLink>(ac =>
            {
                ac.ToTable("NecessaryLink", "NecessaryLinkManagement");

                ac.Property(a => a.LinkTitleEn)
                    .HasColumnType("varchar(500)")
                    .IsRequired(false);
                ac.Property(a => a.LinkTitleBn)
                    .HasColumnType("varchar(500)")
                    .IsRequired(false);
                ac.Property(a => a.SiteLink)
                   .IsRequired(false);
            });
        }
    }
}
