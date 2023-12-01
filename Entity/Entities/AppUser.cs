using Microsoft.AspNetCore.Identity;

namespace Entity.Entities;
public class AppUser:IdentityUser<Guid>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public Guid ImageId { get; set; } = Guid.Parse("C0F62248-8220-49ED-8354-1A5ED2A5FF23");
    public Image Image { get; set; }

    public ICollection<Article> Articles { get; set; }
}
