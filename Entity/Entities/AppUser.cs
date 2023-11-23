using Microsoft.AspNetCore.Identity;

namespace Entity.Entities;
public class AppUser:IdentityUser<Guid>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
}
