using AutoMapper;
using CloudBees.BLL;
using CloudBees.BLL.DTOs;
using CloudBees.BLL.Services;
using CloudBees.DAL.Entities;
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

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<string>> PostAlert(AlertRequestDTO alert)
    {
        var user = await _authService.GetLoggedUser();
        var result = await _alertService.PostAlert(alert, user);
        return Ok(result);
    }
}