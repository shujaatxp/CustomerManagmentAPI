using CommunicationService.Application.DTOs;
using CommunicationService.Application.Interfaces;
using CommunicationService.Domain.Entities;
using CommunicationService.Domain.Interfaces;
using ITemplateService = CommunicationService.Application.Interfaces.ITemplateService;

namespace CommunicationService.Application.Services;

public class TemplateService : ITemplateService
{
    private readonly IRepository<Template> _repository;

    public TemplateService(IRepository<Template> repository)
    {
        _repository = repository;
    }

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

    public async Task DeleteAsync(Guid id) => await _repository.DeleteAsync(id);

    public async Task<IEnumerable<TemplateDto>> GetAllAsync()
    {
        var templates = await _repository.GetAllAsync();
        return templates.Select(t => new TemplateDto { Id = t.Id, Name = t.Name, Subject = t.Subject, Body = t.Body });
    }

    public async Task<TemplateDto?> GetByIdAsync(Guid id)
    {
        var t = await _repository.GetByIdAsync(id);
        return t == null ? null : new TemplateDto { Id = t.Id, Name = t.Name, Subject = t.Subject, Body = t.Body };
    }

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
