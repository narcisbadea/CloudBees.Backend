using AutoMapper;
using CloudBees.BLL.DTOs;
using CloudBees.DAL.Entities;
using CloudBees.DAL.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CloudBees.BLL.Services;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly UserManager<User> _userManager;
    private readonly IConfiguration _configuration;
    private readonly IMapper _mapper;

    public AuthService(IUserRepository userRepository, IMapper mapper, UserManager<User> userManager, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _userManager = userManager;
        _configuration = configuration;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<string> SignUp(RegisterDTO signup)
    {
        var user = _mapper.Map<User>(signup);
        user.UserName = user.Email;
        var result = await _userManager.CreateAsync(user, signup.Password);
        if (!result.Succeeded)
        {
            return "Error";
        }
        var savedUser = await _userManager.FindByEmailAsync(signup.Email);
        if (savedUser == null)
        {
            return "Error";
        }
        return "User added!";

    }
    public async Task<bool> CheckPassword(LoginDTO request)
    {
        var userFind = await _userManager.FindByEmailAsync(request.Email);

        var wrongPassword = !await _userManager.CheckPasswordAsync(userFind, request.Password);
        if (request == null || wrongPassword)
        {
            return false;
        }
        return true;
    }

    public async Task<JwtSecurityToken> GenerateToken(LoginDTO userLogin, bool rememberMe)
    {
        var user = await _userManager.FindByEmailAsync(userLogin.Email);
        var userRoles = await _userManager.GetRolesAsync(user);

        var authClaims = new List<Claim>
            {
                new(ClaimTypes.Name, user.UserName)
            };

        authClaims.AddRange(userRoles.Select(userRole => new Claim(ClaimTypes.Role, userRole)));

        var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));
        var expiresTime = DateTime.Now.AddMinutes(30);
        if (rememberMe)
        {
            expiresTime = DateTime.Now.AddHours(4);
        }
        var token = new JwtSecurityToken(
            expires: expiresTime,
            claims: authClaims,
            signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
        );
        return token;
    }

    public async Task<User> GetLoggedUser()
    {
        var result = await _userRepository.GetUserByName(GetLoggedUserName());
        return result;
    }

    public string GetLoggedUserName()
    {
        var result = string.Empty;
        if (_httpContextAccessor.HttpContext != null)
        {
            result = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Name);
        }
        return result;
    }
}
