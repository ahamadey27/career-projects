using Microsoft.EntityFrameworkCore;
using equipment_maintenance_log.Models; 

var builder = WebApplication.CreateBuilder(args);

// Ensure the app binds to the assigned (HTTP) port so it runs on 5057
builder.WebHost.UseUrls("http://localhost:5057");

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
// Register controllers so we can use controller-based routing
builder.Services.AddControllers();

builder.Services.AddDbContext<MaintenanceContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

// Running only on HTTP 5057 for local development. HTTPS redirection is
// disabled to avoid the "Failed to determine the https port for redirect" warning
// when an HTTPS endpoint is not configured.
// If you later want HTTPS, call app.UseHttpsRedirection() and enable HTTPS in launchSettings.

// Use controller routing for endpoints implemented in Controllers/*
app.MapControllers();

app.Run();
