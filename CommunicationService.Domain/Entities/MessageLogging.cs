public class MessageLogging
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid TemplateId { get; set; }
    public Guid CustomerId { get; set; }
    public string Subject { get; set; }
    public string Body { get; set; }
    public DateTime SentAt { get; set; } = DateTime.UtcNow;
}
