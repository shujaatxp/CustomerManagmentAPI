public class MessageLoggingDto
{
    public Guid Id { get; set; }
    public Guid TemplateId { get; set; }
    public Guid CustomerId { get; set; }
    public string Subject { get; set; }
    public string Body { get; set; }
    public DateTime SentAt { get; set; }
}
