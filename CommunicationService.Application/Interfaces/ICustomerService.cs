using CommunicationService.Application.DTOs;

namespace CommunicationService.Application.Interfaces;

public interface ICustomerService
{
    Task<IEnumerable<CustomerDto>> GetAllAsync();
    Task<CustomerDto?> GetByIdAsync(Guid id);
    Task<CustomerDto> CreateAsync(CustomerDto customer);
    Task<CustomerDto> UpdateAsync(CustomerDto customer);
    Task DeleteAsync(Guid id);
}
