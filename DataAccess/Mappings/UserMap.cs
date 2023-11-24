using Entity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Mappings;
public class UserMap : IEntityTypeConfiguration<AppUser>
{
    public void Configure(EntityTypeBuilder<AppUser> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasIndex(x => x.NormalizedUserName).IsUnique().HasName("UserNameIndex");
        builder.HasIndex(x=>x.NormalizedEmail).HasName("EmailIndex");

        builder.ToTable("AspNetUsers");

        builder.Property(x => x.ConcurrencyStamp).IsConcurrencyToken();

        builder.Property(x=>x.UserName).HasMaxLength(64);
        builder.Property(x=>x.NormalizedUserName).HasMaxLength(64);
        builder.Property(x=>x.Email).HasMaxLength(128);
        builder.Property(x=>x.NormalizedEmail).HasMaxLength(128);

        builder.HasMany<AppUserClaim>().WithOne().HasForeignKey(x=>x.UserId).IsRequired();
        builder.HasMany<AppUserLogin>().WithOne().HasForeignKey(x => x.UserId).IsRequired();
        builder.HasMany<AppUserToken>().WithOne().HasForeignKey(x => x.UserId).IsRequired();
        builder.HasMany<AppUserRole>().WithOne().HasForeignKey(x => x.UserId).IsRequired();

        var superadmin=new AppUser
        {
            Id = Guid.Parse("4505611C-4DDD-46DA-9FB8-32D402ECA8D3"),
            UserName = "superadmin",
            NormalizedUserName = "SUPERADMIN",
            Email = "superadmin@gmail.com",
            NormalizedEmail = "SUPERADMIN@GMAIL.COM",
            PhoneNumber = "+905441234567",
            FirstName = "Hakan",
            LastName = "SuperAdmin",
            PhoneNumberConfirmed = true,
            EmailConfirmed = true,
            SecurityStamp = Guid.NewGuid().ToString(),
            ImageId= Guid.Parse("C0F62248-8220-49ED-8354-1A5ED2A5FF23")

        };
        superadmin.PasswordHash = CreatePasswordHash(superadmin, "123456");

        var admin = new AppUser
        {
            Id = Guid.Parse("0C9C10A3-C42B-4E04-BF62-AB69A366EBE1"),
            UserName = "admin",
            NormalizedUserName = "ADMIN",
            Email = "admin@gmail.com",
            NormalizedEmail = "ADMIN@GMAIL.COM",
            PhoneNumber = "+905441234588",
            FirstName = "Hakan",
            LastName = "Admin",
            PhoneNumberConfirmed = false,
            EmailConfirmed = false,
            SecurityStamp = Guid.NewGuid().ToString(),
            ImageId = Guid.Parse("C0F62248-8220-49ED-8354-1A5ED2A5FF23")
        };
        admin.PasswordHash = CreatePasswordHash(admin, "123456");

        builder.HasData(superadmin, admin);
    }

    private string CreatePasswordHash(AppUser user,string password)
    {
        var passwordHash = new PasswordHasher<AppUser>();
        return passwordHash.HashPassword(user,password);
    }
}
