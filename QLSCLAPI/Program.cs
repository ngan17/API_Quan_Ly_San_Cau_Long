using Microsoft.EntityFrameworkCore;
using QLSCLAPI.Models;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers()
    .AddJsonOptions(x =>
        x.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<QuanLySanCauLongContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

Console.WriteLine("▶️ Using connection string: " + builder.Configuration.GetConnectionString("DefaultConnection"));

app.UseAuthorization();
app.MapControllers();

// ✅ Cấu hình cổng cho Railway
var port = Environment.GetEnvironmentVariable("PORT") ?? "3000";
app.Urls.Add($"http://*:{port}");

app.Run();
