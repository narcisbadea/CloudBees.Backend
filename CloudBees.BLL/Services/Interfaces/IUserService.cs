using CloudBees.BLL.DTOs;

namespace CloudBees.BLL.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserProfileDTO> GetLoggedUserProfile();
    }
}