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

    public async Task<string> SendToCustomerAsync(Guid templateId, Guid customerId)
    {
        var customer = await _context.Customers.FirstOrDefaultAsync(c => c.Id == customerId);
        if (customer == null) return "Customer not found.";

        var template = await _context.Templates.FirstOrDefaultAsync(t => t.Id == templateId);
        if (template == null) return "Template not found.";

        var subject = Replace(template.Subject, customer);
        var body = Replace(template.Body, customer);

        var message = $"Sending Email To: {customer.Email}\nSubject: {subject}\nBody: {body}";
        Console.WriteLine(message);

        _context.SendHistories.Add(new MessageLogging
        {
            TemplateId = templateId,
            CustomerId = customerId,
            Subject = subject,
            Body = body
        });

        await _context.SaveChangesAsync();

        return message;
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
