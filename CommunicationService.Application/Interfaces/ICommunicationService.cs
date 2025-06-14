namespace CommunicationService.Application.Interfaces;

public interface ICommunicationService
{
    Task<string> SendToCustomerAsync(Guid templateId, Guid customerId);

    Task<List<MessageLoggingDto>> GetMessageLoggingHistoryAsync();

}
