using Microsoft.AspNetCore.Identity;

namespace ProjectEBusinessMVC.Core.Entities;

public class AppUser:IdentityUser
{
    public string? Fullname;
}
