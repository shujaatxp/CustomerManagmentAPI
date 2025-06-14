namespace CommunicationService.Domain.Interfaces;

using CommunicationService.Domain.Entities;

public interface ITemplateService
{
    Task<Template> SendTemplateToCustomer(Guid templateId, Customer customer);
}
