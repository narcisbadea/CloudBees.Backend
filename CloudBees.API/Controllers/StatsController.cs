using CloudBees.BLL.DTOs;
using CloudBees.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CloudBees.API.Controllers;

[ApiController]
[Route("[controller]")]
public class StatsController : ControllerBase
{
    private readonly IStatsService _statsService;

    public StatsController(IStatsService statsService)
    {
        _statsService = statsService;
    }

    [HttpGet("alerts")]
    [Authorize]
    public async Task<ActionResult<AlertsStatsDTO>> GetAllAlertsStats()
    {
        var result = await _statsService.GetAllAlertsStatsAsync();
        return Ok(result);
    }

    [HttpGet("users")]
    [Authorize]
    public async Task<ActionResult<IEnumerable<UserStatsDTO>>> GetAllUserStats()
    {
        var result = await _statsService.GetAllUserStatsAsync();
        if (result.Count() == 0)
        {
            return NoContent();
        }
        return Ok(result);
    }
}
