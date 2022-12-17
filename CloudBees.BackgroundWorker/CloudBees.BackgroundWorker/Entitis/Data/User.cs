using Microsoft.AspNetCore.Identity;

namespace CloudBees.DAL.Entities;

public class User : IdentityUser
{
    public int Points { get; set; }
    public string FirstName { get; set; } = String.Empty;
    public string LastName { get; set; } = String.Empty;
}

