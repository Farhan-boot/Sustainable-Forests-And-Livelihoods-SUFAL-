using Microsoft.EntityFrameworkCore;
using PTSL.GENERIC.Common.Entity.Beneficiary;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions
{
    public static partial class EntityModelBuilderExtensions
    {
        public static void ConfigureBFDAssociationHouseholdMembersMap(this ModelBuilder builder)
        {
            builder.Entity<BFDAssociationHouseholdMembersMap>(ac =>
            {
                ac.ToTable($"{nameof(BFDAssociationHouseholdMembersMap)}s", "BEN");
            });
            builder.Entity<BFDAssociationHouseholdMembersMap>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);

            builder.Entity<BFDAssociationHouseholdMembersMap>()
                .HasOne(x => x.BFDAssociation)
                .WithMany(x => x.BFDAssociationHouseholdMembers)
                .HasForeignKey(x => x.BFDAssociationId);
            builder.Entity<BFDAssociationHouseholdMembersMap>()
                .HasOne(x => x.HouseholdMember)
                .WithMany(x => x.BFDAssociationHouseholdMembers)
                .HasForeignKey(x => x.HouseholdMemberId);
        }
    }
}
