using CloudBees.BLL.DTOs;
using CloudBees.DAL.Entities;
using System.IdentityModel.Tokens.Jwt;

namespace CloudBees.BLL.Services
{
    public interface IAuthService
    {
        Task<bool> CheckPassword(LoginDTO request);
        Task<JwtSecurityToken> GenerateToken(LoginDTO userLogin, bool rememberMe);
        Task<User> GetLoggedUser();
        string GetLoggedUserName();
        Task<string> SignUp(RegisterDTO signup);
    }
}