using CommunicationService.Application.DTOs;
using CommunicationService.Application.Interfaces;
using CommunicationService.Domain.Entities;
using CommunicationService.Domain.Interfaces;

namespace CommunicationService.Application.Services;

public class CustomerService : ICustomerService
{
    private readonly IRepository<Customer> _repository;

    public CustomerService(IRepository<Customer> repository)
    {
        _repository = repository;
    }

    public async Task<CustomerDto> CreateAsync(CustomerDto customer)
    {
        var entity = new Customer { Id = Guid.NewGuid(), Name = customer.Name, Email = customer.Email };
        var added = await _repository.AddAsync(entity);
        return new CustomerDto { Id = added.Id, Name = added.Name, Email = added.Email };
    }

    public async Task DeleteAsync(Guid id) => await _repository.DeleteAsync(id);

    public async Task<IEnumerable<CustomerDto>> GetAllAsync()
    {
        var customers = await _repository.GetAllAsync();
        return customers.Select(c => new CustomerDto { Id = c.Id, Name = c.Name, Email = c.Email });
    }

    public async Task<CustomerDto?> GetByIdAsync(Guid id)
    {
        var c = await _repository.GetByIdAsync(id);
        return c == null ? null : new CustomerDto { Id = c.Id, Name = c.Name, Email = c.Email };
    }

    public async Task<CustomerDto> UpdateAsync(CustomerDto customer)
    {
        var entity = new Customer { Id = customer.Id, Name = customer.Name, Email = customer.Email };
        var updated = await _repository.UpdateAsync(entity);
        return new CustomerDto { Id = updated.Id, Name = updated.Name, Email = updated.Email };
    }
}
