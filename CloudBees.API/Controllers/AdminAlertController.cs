using CloudBees.BLL.DTOs;
using CloudBees.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CloudBees.API.Controllers;

[ApiController]
[Route("[controller]")]
public class AdminAlertController : ControllerBase
{
    private readonly IAlertService _alertService;

    public AdminAlertController(IAlertService alertService)
    {
        _alertService = alertService;
    }

    [HttpPut]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> CloseAlert([FromBody] CloseAlertDTO alert)
    {
        var result = await _alertService.CloseAlert(alert.AlertId);
        if (result)
        {
            return Ok();
        }
        return BadRequest();
    }
}
