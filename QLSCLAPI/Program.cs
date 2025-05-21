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

app.Run("http://0.0.0.0:7271");
