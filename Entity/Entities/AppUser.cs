using Core.Entities;
using Microsoft.AspNetCore.Identity;

namespace Entity.Entities;
public class AppUser:IdentityUser<Guid>,IEntityBase
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public Guid ImageId { get; set; } = Guid.Parse("0d36aae8-a74f-42b1-bd25-d99c37ce747f");
    public Image Image { get; set; }

    public ICollection<Article> Articles { get; set; }
}
