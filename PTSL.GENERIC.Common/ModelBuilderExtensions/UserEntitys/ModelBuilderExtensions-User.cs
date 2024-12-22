using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Common.Entity;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions;

public static partial class EntityModelBuilderExtensions
{
    public static void ConfigureUser(this ModelBuilder builder)
    {
        builder.Entity<User>(ac =>
        {
            ac.ToTable("User", "System");

            ac.Property(a => a.UserName)
                .HasColumnName("UserName")
                .HasColumnType("varchar(500)")
                .IsRequired();

            ac.Property(a => a.UserEmail)
                .HasColumnName("UserEmail")
                .HasColumnType("varchar(100)")
                .IsRequired();

            ac.Property(a => a.UserPassword)
                .HasColumnName("UserPassword")
                .HasColumnType("varchar(500)")
                .IsRequired();

            ac.Property(a => a.UserPhone)
                .HasColumnName("UserPhone")
                .HasColumnType("varchar(100)")
                .IsRequired(false);

            ac.Property(a => a.UserGroup)
                .HasColumnName("UserGroup")
                .HasColumnType("varchar(100)")
                .IsRequired(false);

            ac.Property(a => a.UserStatus)
                .HasColumnName("UserStatus")
                .HasColumnType("int")
                .IsRequired();

            ac.Property(a => a.RoleName)
                .HasColumnName("RoleName")
                .HasColumnType("varchar(100)")
                .IsRequired(false);
        });

        builder.Entity<User>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);

        builder.Entity<User>()
            .HasOne(x => x.ForestCircle)
            .WithMany(x => x.Users)
            .HasForeignKey(x => x.ForestCircleId)
            .IsRequired(false);
        builder.Entity<User>()
            .HasOne(x => x.ForestDivision)
            .WithMany(x => x.Users)
            .HasForeignKey(x => x.ForestDivisionId)
            .IsRequired(false);
        builder.Entity<User>()
            .HasOne(x => x.ForestRange)
            .WithMany(x => x.Users)
            .HasForeignKey(x => x.ForestRangeId)
            .IsRequired(false);
        builder.Entity<User>()
            .HasOne(x => x.ForestBeat)
            .WithMany(x => x.Users)
            .HasForeignKey(x => x.ForestBeatId)
            .IsRequired(false);
        builder.Entity<User>()
            .HasOne(x => x.ForestFcvVcf)
            .WithMany(x => x.Users)
            .HasForeignKey(x => x.ForestFcvVcfId)
            .IsRequired(false);

        builder.Entity<User>()
            .HasOne(x => x.District)
            .WithMany(x => x.Users)
            .HasForeignKey(x => x.DistrictId)
            .IsRequired(false);
        builder.Entity<User>()
            .HasOne(x => x.Division)
            .WithMany(x => x.Users)
            .HasForeignKey(x => x.DivisionId)
            .IsRequired(false);
        builder.Entity<User>()
            .HasOne(x => x.Upazilla)
            .WithMany(x => x.Users)
            .HasForeignKey(x => x.UpazillaId)
            .IsRequired(false);
        builder.Entity<User>()
            .HasOne(x => x.Union)
            .WithMany(x => x.Users)
            .HasForeignKey(x => x.UnionId)
            .IsRequired(false);

        builder.Entity<User>()
            .HasOne(x => x.UserRole)
            .WithMany(x => x.Users)
            .HasForeignKey(x => x.UserRoleId)
            .IsRequired(false);

        // Map To Account into User
        builder.Entity<User>()
           .HasOne(x => x.Accounts)
           .WithMany(x => x.Users)
           .HasForeignKey(x => x.AccountsId)
           .IsRequired(false);
    }
}
