    using CommunicationService.Application.Interfaces;
using CommunicationService.Domain.Entities;
using CommunicationService.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CommunicationService.Application.Services;

/// <summary> Syed Shujaat Ali
/// Service for sending communications to customers and retrieving message logs.
/// </summary>
public class CommunicationService : ICommunicationService
{
    private readonly AppDbContext _context;

    /// <summary> Syed Shujaat Ali
    /// Initializes a new instance of the <see cref="CommunicationService"/> class.
    /// </summary>
    /// <param name="object">Repository for templates (not used directly).</param>
    /// <param name="context">The application's database context.</param>
    public CommunicationService(Domain.Interfaces.IRepository<Template> @object, AppDbContext context)
    {
        _context = context;
    }

    /// <summary> Syed Shujaat Ali
    /// Sends a communication to a customer using a template.
    /// </summary>
    /// <param name="templateId">The unique identifier of the template.</param>
    /// <param name="customerId">The unique identifier of the customer.</param>
    /// <returns>
    /// A <see cref="CommunicationResult"/> containing the rendered subject and body, or null if customer or template is not found.
    /// </returns>
    public async Task<CommunicationResult> SendToCustomerAsync(Guid templateId, Guid customerId)
    {
        var customer = await _context.Customers.FirstOrDefaultAsync(c => c.Id == customerId);
        if (customer == null) return null;

        var template = await _context.Templates.FirstOrDefaultAsync(t => t.Id == templateId);
        if (template == null) return null;

        var subject = Replace(template.Subject, customer);
        var body = Replace(template.Body, customer);

        // Save communication history
        _context.SendHistories.Add(new MessageLogging
        {
            TemplateId = templateId,
            CustomerId = customerId,
            Subject = subject,
            Body = body,
            SentAt = DateTime.UtcNow  // Optional: add a SentAt field to the table
        });

        await _context.SaveChangesAsync();

        // Return just the rendered message body (or full message if needed)
        return new CommunicationResult
        {
            Subject = subject,
            Body = body
        };
    }

    /// <summary> Syed Shujaat Ali
    /// Retrieves the message logging history, ordered by sent date descending.
    /// </summary>
    /// <returns>A list of <see cref="MessageLoggingDto"/> representing the message logs.</returns>
    public async Task<List<MessageLoggingDto>> GetMessageLoggingHistoryAsync()
    {
        return await _context.SendHistories
            .OrderByDescending(h => h.SentAt)
            .Select(h => new MessageLoggingDto
            {
                Id = h.Id,
                TemplateId = h.TemplateId,
                CustomerId = h.CustomerId,
                Subject = h.Subject,
                Body = h.Body,
                SentAt = h.SentAt
            })
            .ToListAsync();
    }

    /// <summary> Syed Shujaat Ali
    /// Replaces template placeholders with customer data.
    /// </summary>
    /// <param name="content">The template content containing placeholders.</param>
    /// <param name="customer">The customer whose data will be used for replacement.</param>
    /// <returns>The content with placeholders replaced by customer data.</returns>
    private string Replace(string content, Customer customer)
    {
        return content
            .Replace("{{Name}}", customer.Name)
            .Replace("{{Email}}", customer.Email);
    }
}
