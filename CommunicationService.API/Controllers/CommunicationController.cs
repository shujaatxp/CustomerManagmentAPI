using CommunicationService.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CommunicationService.API.Controllers;

[ApiController]
[Route("api/communications")]
public class CommunicationController : ControllerBase
{
    private readonly ICommunicationService _communicationService;

    public CommunicationController(ICommunicationService communicationService)
    {
        _communicationService = communicationService;
    }

    [HttpPost]
    public async Task<IActionResult> Send([FromQuery] Guid templateId, [FromQuery] Guid customerId)
    {
        var result = await _communicationService.SendToCustomerAsync(templateId, customerId);

        if (result == null) { 
            return NotFound(result);
        }

        return Ok(result);
    }

    [HttpGet("history")]
    public async Task<IActionResult> GetHistory()
    {
        var history = await _communicationService.GetMessageLoggingHistoryAsync();
        return Ok(history);
    }

}