using Microsoft.AspNetCore.Identity;

namespace CloudBees.DAL.Entities;

public class User : IdentityUser
{
    public int Points { get; set; }
}

