using CloudBees.BLL.DTOs;
using CloudBees.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CloudBees.API.Controllers;

public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet("user-profile")]
    [Authorize]
    public async Task<ActionResult<UserProfileDTO?>> GetLoggedUserProfile()
    {
        var loggedUserProfile = await _userService.GetLoggedUserProfile();
        return Ok(loggedUserProfile);
    }

}
