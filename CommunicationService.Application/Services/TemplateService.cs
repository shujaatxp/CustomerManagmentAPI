using CommunicationService.Application.DTOs;
using CommunicationService.Application.Interfaces;
using CommunicationService.Domain.Entities;
using CommunicationService.Domain.Interfaces;
using ITemplateService = CommunicationService.Application.Interfaces.ITemplateService;

namespace CommunicationService.Application.Services;

/// <summary> Syed Shujaat Ali
/// Service for managing templates.
/// </summary>
public class TemplateService : ITemplateService
{
    private readonly IRepository<Template> _repository;

    /// <summary> Syed Shujaat Ali
    /// Initializes a new instance of the <see cref="TemplateService"/> class.
    /// </summary>
    /// <param name="repository">The repository for Template entities.</param>
    public TemplateService(IRepository<Template> repository)
    {
        _repository = repository;
    }

    /// <summary> Syed Shujaat Ali
    /// Creates a new template in the repository.
    /// </summary>
    /// <param name="template">The template data transfer object containing Name, Subject, and Body.</param>
    /// <returns>The created <see cref="TemplateDto"/> with generated Id.</returns>
    public async Task<TemplateDto> CreateAsync(TemplateDto template)
    {
        var entity = new Template
        {
            Id = Guid.NewGuid(),
            Name = template.Name,
            Subject = template.Subject,
            Body = template.Body
        };
        var added = await _repository.AddAsync(entity);
        return new TemplateDto { Id = added.Id, Name = added.Name, Subject = added.Subject, Body = added.Body };
    }

    /// <summary> Syed Shujaat Ali
    /// Deletes a template by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the template to delete.</param>
    public async Task DeleteAsync(Guid id) => await _repository.DeleteAsync(id);

    /// <summary> Syed Shujaat Ali
    /// Retrieves all templates from the repository.
    /// </summary>
    /// <returns>An enumerable collection of <see cref="TemplateDto"/>.</returns>
    public async Task<IEnumerable<TemplateDto>> GetAllAsync()
    {
        var templates = await _repository.GetAllAsync();
        return templates.Select(t => new TemplateDto { Id = t.Id, Name = t.Name, Subject = t.Subject, Body = t.Body });
    }

    /// <summary> Syed Shujaat Ali
    /// Retrieves a template by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the template.</param>
    /// <returns>The <see cref="TemplateDto"/> if found; otherwise, null.</returns>
    public async Task<TemplateDto?> GetByIdAsync(Guid id)
    {
        var t = await _repository.GetByIdAsync(id);
        return t == null ? null : new TemplateDto { Id = t.Id, Name = t.Name, Subject = t.Subject, Body = t.Body };
    }

    /// <summary> Syed Shujaat Ali
    /// Updates an existing template in the repository.
    /// </summary>
    /// <param name="template">The template data transfer object with updated values.</param>
    /// <returns>The updated <see cref="TemplateDto"/>.</returns>
    public async Task<TemplateDto> UpdateAsync(TemplateDto template)
    {
        var entity = new Template
        {
            Id = template.Id,
            Name = template.Name,
            Subject = template.Subject,
            Body = template.Body
        };
        var updated = await _repository.UpdateAsync(entity);
        return new TemplateDto { Id = updated.Id, Name = updated.Name, Subject = updated.Subject, Body = updated.Body };
    }
}
