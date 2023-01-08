using CloudBees.BLL.DTOs;
using CloudBees.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace CloudBees.API.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;
    privae

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }


    [HttpPost("register")]
    public async Task<IActionResult> SignUp(RegisterDTO auth)
    {
        var result = await _authService.SignUp(auth);
        return Ok(result);
    }

    [HttpPost("login")]
    public async Task<ActionResult<string>> Login(LoginDTO request)
    {
        if (!await _authService.CheckPassword(request))
        {
            return BadRequest(new { Message = "Invalid password or user not found!" });
        }
        var token = await _authService.GenerateToken(request, request.rememberMe);
        var expires = request.rememberMe ? 240 : 30;
        var roles = await _user
        return Ok(new { token = (new JwtSecurityTokenHandler().WriteToken(token)).ToString(), expiresIn = expires, role = "Admin" });
    }

    [HttpGet("logged-username")]
    [Authorize]
    public ActionResult<string> GetUserName()
    {
        var result = _authService.GetLoggedUserName();
        if (result == null)
        {
            return NotFound();
        }
        return Ok(result);
    }
}
