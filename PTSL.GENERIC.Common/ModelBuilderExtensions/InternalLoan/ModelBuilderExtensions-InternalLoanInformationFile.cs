using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Common.Entity.AIG;
using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Entity.InternalLoan;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions;

public static partial class EntityModelBuilderExtensions
{
    public static void ConfigureInternalLoanInformationFile(this ModelBuilder builder)
    {
        builder.Entity<InternalLoanInformationFile>(e =>
        {
            e.ToTable($"{nameof(InternalLoanInformationFile)}s", "InternalLoan");
        });

        builder.Entity<InternalLoanInformationFile>()
            .HasOne(x => x.InternalLoanInformation)
            .WithMany(x => x.InternalLoanInformationFiles)
            .HasForeignKey(x => x.InternalLoanInformationId)
            .IsRequired();

        builder.Entity<InternalLoanInformationFile>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
    }
}
