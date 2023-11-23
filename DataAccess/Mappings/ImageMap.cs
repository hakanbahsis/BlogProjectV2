using Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mappings;
public class ImageMap : IEntityTypeConfiguration<Image>
{
    public void Configure(EntityTypeBuilder<Image> builder)
    {
        builder.HasData(new Image
        {
            Id = Guid.Parse("C0F62248-8220-49ED-8354-1A5ED2A5FF23"),
            FileName = "images/testimage",
            FileType = "png",
            CreatedDate = DateTime.Now,
            CreatedBy = "Admin Test",
            IsDeleted = false,

        },
        new Image
        {
            Id = Guid.Parse("25222750-0AA6-40CE-BAD6-616A23F249F4"),
            FileName = "images/testimage",
            FileType = "jpg",
            CreatedDate = DateTime.Now,
            CreatedBy = "Admin Test",
            IsDeleted = false,
        });
    }
}
