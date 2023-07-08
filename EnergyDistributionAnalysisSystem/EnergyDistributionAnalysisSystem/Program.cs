using EDAS.Api.Filters;
using EDAS.Application.Interfaces;
using EDAS.Application.Services;
using EDAS.Infrastructure.Logger;
using EDAS.Infrastructure.Persitence;
using Microsoft.EntityFrameworkCore;
using NLog.Web;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options =>
{
    options.Filters.Add<CustomExceptionFilter>();
});

builder.Services.AddScoped<IEnergyService, EnergyService>();
builder.Services.AddScoped<IRepository, EFRepository>();
builder.Services.AddDbContext<EnergyDistributionAnalysisSystemContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<ILoggerManager, LoggerManager>();
builder.Host.UseNLog();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors(options =>
{
    options.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader();
});

app.MapControllers();

app.Run();
