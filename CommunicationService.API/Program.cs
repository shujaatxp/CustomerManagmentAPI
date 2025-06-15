using CommunicationService.Application.Interfaces;
using CommunicationService.Application.Services;
using CommunicationService.Domain.Entities;
using CommunicationService.Domain.Interfaces;
using CommunicationService.Infrastructure.Data;
using CommunicationService.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// Configure Swagger (no JWT security since no auth here)
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "CommunicationService API", Version = "v1" });
});

// Configure DbContext with SQLite
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register repositories
builder.Services.AddScoped<IRepository<Template>, GenericRepository<Template>>();
builder.Services.AddScoped<IRepository<Customer>, GenericRepository<Customer>>();

// Register services
builder.Services.AddScoped<CommunicationService.Application.Interfaces.ITemplateService, TemplateService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<ICommunicationService, CommunicationService.Application.Services.CommunicationService>();

// No authentication or authorization middleware

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();
