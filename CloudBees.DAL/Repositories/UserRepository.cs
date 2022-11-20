using CloudBees.DAL.Entities;
using Microsoft.EntityFrameworkCore;


namespace CloudBees.DAL.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _dbContext;

    public UserRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<User>> GetAllUsersAsync()
    {
        return await _dbContext.Users
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<User?> GetUserByIdAsync(string userId)
    {
        return await _dbContext.Users
            .AsNoTracking()
            .Where(user => user.Id == userId)
            .SingleOrDefaultAsync();
    }

    public async Task<User?> GetTrakedUserByIdAsync(string userId)
    {
        return await _dbContext.Users
            .Where(user => user.Id == userId)
            .SingleOrDefaultAsync();
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

    public async Task<User?> GetUserByName(string userName)
    {
        return await _dbContext.Users
            .Where(u => u.UserName == userName)
            .FirstOrDefaultAsync();
    }
}
