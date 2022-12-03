using AutoMapper;
using CloudBees.BLL;
using CloudBees.BLL.DTOs;
using CloudBees.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nest;
using System.Data;
using System.Net;
using System.Text;

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
        string url = "https://maps.googleapis.com/maps/api/distancematrix/xml?origins=" + "45.7669338,21.2282715" + "&destinations=" + "45.75,21.2399997";
        WebRequest request = WebRequest.Create(url);
        using (WebResponse response = (HttpWebResponse)request.GetResponse())
        {
            using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
            {
                DataSet dsResult = new DataSet();
                dsResult.ReadXml(reader);
                //lblOriginAddress.Text = dsResult.Tables["DistanceMatrixResponse"].Rows[0]["origin_address"].ToString();
                //lblDestinationAddress.Text = dsResult.Tables["DistanceMatrixResponse"].Rows[0]["destination_address"].ToString();
                var dur = dsResult.Tables["duration"].Rows[0]["text"].ToString();
                var dist = dsResult.Tables["duration"].Rows[0]["value"].ToString() + dsResult.Tables["distance"].Rows[0]["text"].ToString();
            }
        }
        var result = await _alertService.GetAll();
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