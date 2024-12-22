using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Common.Entity.AIG;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions;

public static partial class EntityModelBuilderExtensions
{
    public static void ConfigureGroupLDFInfoFormMember(this ModelBuilder builder)
    {
        builder.Entity<GroupLDFInfoFormMember>(e =>
        {
            e.ToTable($"{nameof(GroupLDFInfoFormMember)}s", SchemaNames.AIG);

            e.Property(x => x.GroupLDFInfoFormId)
                .IsRequired();
            e.Property(x => x.IndividualLDFInfoFormId)
                .IsRequired();
        });

        builder.Entity<GroupLDFInfoFormMember>()
            .HasOne(x => x.GroupLDFInfoForm)
            .WithMany(x => x.GroupLDFInfoFormMembers)
            .HasForeignKey(x => x.GroupLDFInfoFormId)
            .IsRequired();

        builder.Entity<GroupLDFInfoFormMember>()
            .HasOne(x => x.IndividualLDFInfoForm)
            .WithMany(x => x.GroupLDFInfoFormMembers)
            .HasForeignKey(x => x.IndividualLDFInfoFormId)
            .IsRequired();

        builder.Entity<GroupLDFInfoFormMember>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
    }
}
