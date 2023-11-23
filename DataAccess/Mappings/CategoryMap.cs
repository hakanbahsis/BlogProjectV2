using Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Mappings;
public class CategoryMap : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasData(new Category
        {
            Id = Guid.Parse("C0F62248-8220-49ED-8354-1A5ED2A5FF57"),
            Name = "Visual Studio",
            CreatedBy = "Admin Test",
            CreatedDate = DateTime.Now,
            IsDeleted = false,
        },
        new Category
        {
            Id = Guid.Parse("1F148B26-918A-4153-94A6-0D55256D4C7E"),
            Name = "Asp.Net Core",
            CreatedBy = "Admin Test",
            CreatedDate = DateTime.Now,
            IsDeleted = false,
        });
    }
}
