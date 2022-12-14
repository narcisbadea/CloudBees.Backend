using CloudBees.DAL.Entities;

namespace CloudBees.DAL.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<string> CreateUserAsync(User user);
        Task DeleteUserAsync(User user);
        Task<User> GetUserById(string userId);
        Task<User> GetUserByName(string name);
        Task<List<string>> GetUserRoles(string email);
    }
}