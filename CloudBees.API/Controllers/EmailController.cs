using CloudBees.BLL.DTOs;
using CloudBees.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CloudBees.API.Controllers;

[ApiController]
[Route("[controller]")]
public class EmailController : ControllerBase
{
    private readonly IEmailService _emailService;

    public EmailController(IEmailService emailService)
    {
        _emailService = emailService;
    }

    [HttpPost]
    public ActionResult<string> postEmail([FromBody] EmailRequestDTO email)
    {
        _emailService.Send(email);
        return Ok("Email sent");
    }
}
