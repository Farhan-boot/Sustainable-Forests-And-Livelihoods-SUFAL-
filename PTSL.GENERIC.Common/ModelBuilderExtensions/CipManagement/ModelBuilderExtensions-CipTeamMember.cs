using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Common.Entity.CipManagement;
using PTSL.GENERIC.Common.Entity.ForestManagement;
using PTSL.GENERIC.Common.Entity.GeneralSetup;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions
{
    public static partial class EntityModelBuilderExtensions
    {
        public static void ConfigureCipTeamMember(this ModelBuilder builder)
        {
            builder.Entity<CipTeamMember>(ac =>
            {
                ac.ToTable("CipTeamMember", "CipManagement");

                //ac.Property(a => a.Name)
                //    .HasColumnType("varchar(500)")
                //    .IsRequired(false);
                //ac.Property(a => a.NameBn)
                //    .HasColumnType("varchar(500)")
                //    .IsRequired(false);

            });

            builder.Entity<CipTeamMember>()
              .HasOne(x => x.CipTeam)
              .WithMany(x => x.CipTeamMembers)
              .HasForeignKey(x => x.CipTeamId)
              .IsRequired(false);

            builder.Entity<CipTeamMember>()
               .HasOne(x => x.Cip)
               .WithMany(x => x.CipTeamMembers)
               .HasForeignKey(x => x.CipId)
               .IsRequired(false);

            //Add New
            builder.Entity<CipTeamMember>()
              .HasOne(x => x.OtherCommitteeMember)
              .WithMany(x => x.CipTeamMembers)
              .HasForeignKey(x => x.OtherCommitteeMemberId)
              .IsRequired(false);

			builder.Entity<CipTeamMember>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
        }
    }
}
