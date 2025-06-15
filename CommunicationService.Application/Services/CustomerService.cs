using CommunicationService.Application.DTOs;
using CommunicationService.Application.Interfaces;
using CommunicationService.Domain.Entities;
using CommunicationService.Domain.Interfaces;

namespace CommunicationService.Application.Services;

/// <summary> Syed Shujaat Ali
/// Service for managing customers.
/// </summary>
public class CustomerService : ICustomerService
{
    private readonly IRepository<Customer> _repository;

    /// <summary> Syed Shujaat Ali
    /// Initializes a new instance of the <see cref="CustomerService"/> class.
    /// </summary>
    /// <param name="repository">The repository for Customer entities.</param>
    public CustomerService(IRepository<Customer> repository)
    {
        _repository = repository;
    }

    /// <summary> Syed Shujaat Ali
    /// Creates a new customer in the repository.
    /// </summary>
    /// <param name="customer">The customer data transfer object containing Name and Email.</param>
    /// <returns>The created <see cref="CustomerDto"/> with generated Id.</returns>
    public async Task<CustomerDto> CreateAsync(CustomerDto customer)
    {
        var entity = new Customer
        {
            Id = Guid.NewGuid(),
            Name = customer.Name,
            Email = customer.Email
        };
        var added = await _repository.AddAsync(entity);
        return new CustomerDto { Id = added.Id, Name = added.Name, Email = added.Email };
    }

    /// <summary> Syed Shujaat Ali
    /// Deletes a customer by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the customer to delete.</param>
    public async Task DeleteAsync(Guid id) => await _repository.DeleteAsync(id);

    /// <summary> Syed Shujaat Ali
    /// Retrieves all customers from the repository.
    /// </summary>
    /// <returns>An enumerable collection of <see cref="CustomerDto"/>.</returns>
    public async Task<IEnumerable<CustomerDto>> GetAllAsync()
    {
        var customers = await _repository.GetAllAsync();
        return customers.Select(c => new CustomerDto { Id = c.Id, Name = c.Name, Email = c.Email });
    }

    /// <summary> Syed Shujaat Ali
    /// Retrieves a customer by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the customer.</param>
    /// <returns>The <see cref="CustomerDto"/> if found; otherwise, null.</returns>
    public async Task<CustomerDto?> GetByIdAsync(Guid id)
    {
        var c = await _repository.GetByIdAsync(id);
        return c == null ? null : new CustomerDto { Id = c.Id, Name = c.Name, Email = c.Email };
    }

    /// <summary> Syed Shujaat Ali
    /// Updates an existing customer in the repository.
    /// </summary>
    /// <param name="customer">The customer data transfer object with updated values.</param>
    /// <returns>The updated <see cref="CustomerDto"/>.</returns>
    public async Task<CustomerDto> UpdateAsync(CustomerDto customer)
    {
        var entity = new Customer
        {
            Id = customer.Id,
            Name = customer.Name,
            Email = customer.Email
        };
        var updated = await _repository.UpdateAsync(entity);
        return new CustomerDto { Id = updated.Id, Name = updated.Name, Email = updated.Email };
    }
}
