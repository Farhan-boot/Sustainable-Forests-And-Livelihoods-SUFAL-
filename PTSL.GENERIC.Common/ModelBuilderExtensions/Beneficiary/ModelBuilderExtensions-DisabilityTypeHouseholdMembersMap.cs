using Microsoft.EntityFrameworkCore;
using PTSL.GENERIC.Common.Entity.Beneficiary;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions
{
    public static partial class EntityModelBuilderExtensions
    {
        public static void ConfigureDisabilityTypeHouseholdMembersMap(this ModelBuilder builder)
        {
            builder.Entity<DisabilityTypeHouseholdMembersMap>(e =>
            {
                e.ToTable($"{nameof(DisabilityTypeHouseholdMembersMap)}s", "BEN");
            });

            builder.Entity<DisabilityTypeHouseholdMembersMap>()
                .HasOne(x => x.DisabilityType)
                .WithMany(x => x.DisabilityTypeHouseholdMembers)
                .HasForeignKey(x => x.DisabilityTypeId);
            builder.Entity<DisabilityTypeHouseholdMembersMap>()
                .HasOne(x => x.HouseholdMember)
                .WithMany(x => x.DisabilityTypeHouseholdMembers)
                .HasForeignKey(x => x.HouseholdMemberId);

			builder.Entity<DisabilityTypeHouseholdMembersMap>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
		}
	}
}
