using Microsoft.EntityFrameworkCore;
using CommunicationService.Domain.Entities;

namespace CommunicationService.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public DbSet<Template> Templates => Set<Template>();
    public DbSet<Customer> Customers => Set<Customer>();
    public DbSet<MessageLogging> SendHistories { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
