using CommunicationService.Application.DTOs;

namespace CommunicationService.Application.Interfaces;

public interface ITemplateService
{
    Task<IEnumerable<TemplateDto>> GetAllAsync();
    Task<TemplateDto?> GetByIdAsync(Guid id);
    Task<TemplateDto> CreateAsync(TemplateDto template);
    Task<TemplateDto> UpdateAsync(TemplateDto template);
    Task DeleteAsync(Guid id);
}
