using CommunicationService.Domain.Entities;

namespace CommunicationService.Application.Interfaces;

public interface ICommunicationService
{
    Task<CommunicationResult> SendToCustomerAsync(Guid templateId, Guid customerId);

    Task<List<MessageLoggingDto>> GetMessageLoggingHistoryAsync();

}
