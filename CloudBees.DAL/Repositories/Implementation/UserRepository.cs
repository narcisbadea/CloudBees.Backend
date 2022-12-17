using CloudBees.DAL.Entities;
using CloudBees.DAL.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


namespace CloudBees.DAL.Repositories.Implementation;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _dbContext;
    private readonly UserManager<User> _userManager;
    private readonly RoleManager<Role> _roleManager;

    public UserRepository(AppDbContext dbContext, UserManager<User> userManager, RoleManager<Role> roleManager)
    {
        _dbContext = dbContext;
        _userManager = userManager;
        _roleManager = roleManager;
    }


    public async Task<string> CreateUserAsync(User user)
    {
        await _dbContext.Users.AddAsync(user);

        await _dbContext.SaveChangesAsync();

        return user.Id;
    }

    public async Task DeleteUserAsync(User user)
    {
        _dbContext.Users.Remove(user);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<User> GetUserById(string userId)
    {
        var result = await _userManager.FindByIdAsync(userId);
        return result;
    }

    public async Task<User> GetUserByName(string name)
    {
        var result = await _userManager.FindByNameAsync(name);
        return result;
    }
}
