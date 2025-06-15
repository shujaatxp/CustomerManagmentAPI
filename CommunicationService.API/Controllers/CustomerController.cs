using CommunicationService.Application.DTOs;
using CommunicationService.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CommunicationService.API.Controllers;

/// <summary> Syed Shujaat Ali
/// API controller for managing customers.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class CustomerController : ControllerBase
{
    private readonly ICustomerService _service;

    /// <summary> Syed Shujaat Ali
    /// Initializes a new instance of the <see cref="CustomerController"/> class.
    /// </summary>
    /// <param name="service">The customer service instance.</param>
    public CustomerController(ICustomerService service)
    {
        _service = service;
    }

    /// <summary> Syed Shujaat Ali
    /// Gets all customers.
    /// </summary>
    /// <returns>A list of all customers.</returns>
    [HttpGet]
    public async Task<IActionResult> Get() => Ok(await _service.GetAllAsync());

    /// <summary> Syed Shujaat Ali
    /// Gets a customer by ID.
    /// </summary>
    /// <param name="id">The unique identifier of the customer.</param>
    /// <returns>The customer if found; otherwise, NotFound.</returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _service.GetByIdAsync(id);
        return result == null ? NotFound() : Ok(result);
    }

    /// <summary> Syed Shujaat Ali
    /// Creates a new customer.
    /// </summary>
    /// <param name="dto">The customer data transfer object.</param>
    /// <returns>The created customer.</returns>
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CustomerDto dto)
    {
        var result = await _service.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    /// <summary> Syed Shujaat Ali
    /// Updates an existing customer.
    /// </summary>
    /// <param name="id">The unique identifier of the customer.</param>
    /// <param name="dto">The updated customer data transfer object.</param>
    /// <returns>The updated customer if successful; otherwise, BadRequest.</returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] CustomerDto dto)
    {
        if (id != dto.Id) return BadRequest();
        return Ok(await _service.UpdateAsync(dto));
    }

    /// <summary> Syed Shujaat Ali
    /// Deletes a customer by ID.
    /// </summary>
    /// <param name="id">The unique identifier of the customer to delete.</param>
    /// <returns>No content if successful.</returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _service.DeleteAsync(id);
        return NoContent();
    }
}
