using CommunicationService.Application.DTOs;
using CommunicationService.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CommunicationService.API.Controllers;

/// <summary> Syed Shujaat Ali
/// API controller for managing templates.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class TemplateController : ControllerBase
{
    private readonly ITemplateService _service;

    /// <summary> Syed Shujaat Ali
    /// Initializes a new instance of the <see cref="TemplateController"/> class.
    /// </summary>
    /// <param name="service">The template service instance.</param>
    public TemplateController(ITemplateService service)
    {
        _service = service;
    }

    /// <summary> Syed Shujaat Ali
    /// Gets all templates.
    /// </summary>
    /// <returns>A list of all templates.</returns>
    [HttpGet]
    public async Task<IActionResult> Get() => Ok(await _service.GetAllAsync());

    /// <summary> Syed Shujaat Ali
    /// Gets a template by ID.
    /// </summary>
    /// <param name="id">The unique identifier of the template.</param>
    /// <returns>The template if found; otherwise, NotFound.</returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _service.GetByIdAsync(id);
        return result == null ? NotFound() : Ok(result);
    }

    /// <summary> Syed Shujaat Ali
    /// Creates a new template.
    /// </summary>
    /// <param name="dto">The template data transfer object.</param>
    /// <returns>The created template.</returns>
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] TemplateDto dto)
    {
        var result = await _service.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    /// <summary> Syed Shujaat Ali
    /// Updates an existing template.
    /// </summary>
    /// <param name="id">The unique identifier of the template.</param>
    /// <param name="dto">The updated template data transfer object.</param>
    /// <returns>The updated template if successful; otherwise, BadRequest.</returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] TemplateDto dto)
    {
        if (id != dto.Id) return BadRequest();
        return Ok(await _service.UpdateAsync(dto));
    }

    /// <summary> Syed Shujaat Ali
    /// Deletes a template by ID.
    /// </summary>
    /// <param name="id">The unique identifier of the template to delete.</param>
    /// <returns>No content if successful.</returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _service.DeleteAsync(id);
        return NoContent();
    }
}
