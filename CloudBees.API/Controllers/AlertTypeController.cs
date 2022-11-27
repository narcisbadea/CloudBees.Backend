using CloudBees.BLL.Services.Interfaces;
using CloudBees.DAL;
using CloudBees.DAL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CloudBees.API.Controllers;

[ApiController]
[Route("[controller]")]
public class AlertTypeController : ControllerBase
{
    private readonly IAlertTypeService _alertTypeService;

    public AlertTypeController(IAlertTypeService alertTypeService)
    {
        _alertTypeService = alertTypeService;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<string>> GetAlertTypeById(string id)
    {
        var alertType = await _alertTypeService.GetAlertTypeByIdAsync(id);
        return Ok(alertType);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<AlertType>>> GetAllAlertTypes()
    {
        var result = await _alertTypeService.GetAllAlertTypes();
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<string>> PostAlertType(string type)
    {
        var result = await _alertTypeService.PostAlertType(type);
        return Ok(result);
    }
}
