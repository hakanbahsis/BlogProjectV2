using Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mappings;
public class UserRoleMap : IEntityTypeConfiguration<AppUserRole>
{
    public void Configure(EntityTypeBuilder<AppUserRole> builder)
    {
        // Primary key
        builder.HasKey(r => new { r.UserId, r.RoleId });

        // Maps to the AspNetUserRoles table
        builder.ToTable("AspNetUserRoles");

        builder.HasData(new AppUserRole
        {
            UserId= Guid.Parse("4505611C-4DDD-46DA-9FB8-32D402ECA8D3"),
            RoleId= Guid.Parse("A6CA339A-F8A4-4C50-AFD5-83E9A3C7A1C8")
        },
        new AppUserRole
        {
            UserId = Guid.Parse("0C9C10A3-C42B-4E04-BF62-AB69A366EBE1"),
            RoleId = Guid.Parse("E6F02C99-B838-4D6E-98BC-4CFFF4ED5DF7")
        }
        );
    }
}
