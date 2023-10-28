using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Net.NetworkInformation;
using System.Reflection;
using WorldLeagueDraw.Application.Interfaces;
using WorldLeagueDraw.Infrastructure.Persistence.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//TODO: infrastructure katmanında tanımlanmalı.
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Ping).Assembly));
//TODO: infrastructure katmanında tanımlanmalı.
builder.Services.AddDbContext<WorldLeagueDrawDbContext>(options =>
               options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
//TODO: infrastructure katmanında tanımlanmalı.
builder.Services.AddScoped<IWorldLeagueDrawDbContext>(provider => provider.GetService<WorldLeagueDrawDbContext>());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
