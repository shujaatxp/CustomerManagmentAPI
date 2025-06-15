using CommunicationService.Application.Interfaces;
using CommunicationService.Domain.Entities;
using CommunicationService.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CommunicationService.Application.Services;

public class CommunicationService : ICommunicationService
{
    private readonly AppDbContext _context;

    public CommunicationService(Domain.Interfaces.IRepository<Template> @object, AppDbContext context)
    {
        _context = context;
    }

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


    private string Replace(string content, Customer customer)
    {
        return content
            .Replace("{{Name}}", customer.Name)
            .Replace("{{Email}}", customer.Email);
    }
}
