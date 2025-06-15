using CommunicationService.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CommunicationService.API.Controllers;

/// <summary> Syed Shujaat Ali
/// API controller for sending communications and retrieving message history.
/// </summary>
[ApiController]
[Route("api/communications")]
public class CommunicationController : ControllerBase
{
    private readonly ICommunicationService _communicationService;

    /// <summary> Syed Shujaat Ali
    /// Initializes a new instance of the <see cref="CommunicationController"/> class.
    /// </summary>
    /// <param name="communicationService">The communication service instance.</param>
    public CommunicationController(ICommunicationService communicationService)
    {
        _communicationService = communicationService;
    }

    /// <summary> Syed Shujaat Ali
    /// Sends a communication to a customer using a template.
    /// </summary>
    /// <param name="templateId">The unique identifier of the template.</param>
    /// <param name="customerId">The unique identifier of the customer.</param>
    /// <returns>The result of the communication if successful; otherwise, NotFound.</returns>
    [HttpPost]
    public async Task<IActionResult> Send([FromQuery] Guid templateId, [FromQuery] Guid customerId)
    {
        var result = await _communicationService.SendToCustomerAsync(templateId, customerId);

        if (result == null) { 
            return NotFound(result);
        }

        return Ok(result);
    }

    /// <summary> Syed Shujaat Ali
    /// Gets the message logging history.
    /// </summary>
    /// <returns>A list of message logging history entries.</returns>
    [HttpGet("history")]
    public async Task<IActionResult> GetHistory()
    {
        var history = await _communicationService.GetMessageLoggingHistoryAsync();
        return Ok(history);
    }
}