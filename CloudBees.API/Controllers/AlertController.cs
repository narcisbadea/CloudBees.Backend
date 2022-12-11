using AutoMapper;
using CloudBees.BLL;
using CloudBees.BLL.DTOs;
using CloudBees.BLL.Services.Interfaces;
using CloudBees.Common.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CloudBees.API.Controllers;

[ApiController]
[Route("[controller]")]
public class AlertController : ControllerBase
{
    private readonly IAlertService _alertService;
    private readonly IAuthService _authService;
    private readonly IMapper _mapper;

    public AlertController(IAlertService alertService, IMapper mapper, IAuthService authService)
    {
        _alertService = alertService;
        _mapper = mapper;
        _authService = authService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<AlertDTO>>> GetAllAlerts()
    {
        var result = await _alertService.GetAll();
        return Ok(result);
    }

    [HttpGet("filtered")]
    public async Task<ActionResult<IEnumerable<AlertDTO>>> GetFilteredAlerts([FromQuery]FiltersAlert filters)
    {
        var result = await _alertService.GetAlertByFilters(filters);
        if (result == null)
        {
            return NoContent();
        }
        return Ok(result);
    }

    [HttpGet("logged-user")]
    [Authorize]
    public async Task<ActionResult<IEnumerable<AlertDTO>>> GetAlertsForLoggedUser()
    {
        var userId = await _authService.GetLoggedUserId();
        var result = await _alertService.GetAllAlertsForLoggedUserAsync(userId);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<string>> PostAlert(AlertRequestDTO alert)
    {
        var user = await _authService.GetLoggedUser();
        var result = await _alertService.PostAlert(alert, user);
        if (result.Contains("Error"))
        {
            return BadRequest(result);
        }
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<string>> DeleteAlert(string id)
    {
        return Ok(await _alertService.DeleteAlert(id));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<AlertDTO>> GetAlertById(string id)
    {
        return Ok(await _alertService.GetAlertByIdAsync(id));
    }
}