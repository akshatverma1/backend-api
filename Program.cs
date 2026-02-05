using Microsoft.EntityFrameworkCore;
using StudioBackendAPI.Data;
using StudioBackendAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add Controllers + Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Database Connection (SQL Server)
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    )
);

// Email Service
builder.Services.AddScoped<EmailService>();

var app = builder.Build();

// Enable Swagger (Works on Railway also)
app.UseSwagger();
app.UseSwaggerUI();

// Map Controllers
app.MapControllers();

// ✅ Railway Deployment Fix (Dynamic PORT Binding)
var port = Environment.GetEnvironmentVariable("PORT") ?? "5000";
app.Urls.Add($"http://0.0.0.0:{port}");

app.Run();
