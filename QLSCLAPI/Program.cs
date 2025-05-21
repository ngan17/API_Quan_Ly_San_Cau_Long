using Microsoft.EntityFrameworkCore;
using QLSCLAPI.Models;
using System;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<QuanLySanCauLongContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        sqlOptions => sqlOptions.EnableRetryOnFailure()
    ));


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// in chuỗi kết nối để kiểm tra đúng chưa
Console.WriteLine("▶️ Using connection string: " + builder.Configuration.GetConnectionString("DefaultConnection"));

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();

app.MapControllers();

var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";

builder.WebHost.ConfigureKestrel(serverOptions =>
{
    serverOptions.ListenAnyIP(Int32.Parse(port));
});

app.Run(); // KHÔNG truyền cổng cố định
