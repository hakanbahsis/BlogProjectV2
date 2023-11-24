using Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Mappings;
public class ArticleMap : IEntityTypeConfiguration<Article>
{
    public void Configure(EntityTypeBuilder<Article> builder)
    {

        //builder.HasKey(x => x.Id);
        //builder.Property(x => x.Title).IsRequired();
        //builder.Property(x => x.Title).HasMaxLength(150);

        builder.HasData(new Article
        {
            Id = Guid.NewGuid(),
            Title = "Asp.Net Core Deneme Makalesi 1",
            Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
            ViewCount = 15,
            CategoryId=Guid.Parse("1F148B26-918A-4153-94A6-0D55256D4C7E"),
            ImageId= Guid.Parse("25222750-0AA6-40CE-BAD6-616A23F249F4"),
            CreatedBy = "Admin Test",
            CreatedDate = DateTime.Now,
            IsDeleted=false,
            UserId=  Guid.Parse("4505611C-4DDD-46DA-9FB8-32D402ECA8D3"),
        },new Article
        {
            Id = Guid.NewGuid(),
            Title = "Visual Studio Deneme Makalesi 1",
            Content = "Visual Studio Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
            ViewCount = 15,
            CategoryId= Guid.Parse("C0F62248-8220-49ED-8354-1A5ED2A5FF57"),
            ImageId= Guid.Parse("C0F62248-8220-49ED-8354-1A5ED2A5FF23"),
            CreatedBy = "Admin Test",
            CreatedDate = DateTime.Now,
            IsDeleted = false,
            UserId = Guid.Parse("0C9C10A3-C42B-4E04-BF62-AB69A366EBE1"),
        });

    }
}
