using Microsoft.EntityFrameworkCore;
using RentalCarsWithRepositoryDesignPattern.Application.IRepositories;
using RentalCarsWithRepositoryDesignPattern.Application.IServices;
using RentalCarsWithRepositoryDesignPattern.Application.Services;
using RentalCarsWithRepositoryDesignPattern.Domain.Data;
using RentalCarsWithRepositoryDesignPattern.Infrastructure.Context;
using RentalCarsWithRepositoryDesignPattern.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

var conString = builder.Configuration.GetConnectionString("RentalDb") ??
     throw new InvalidOperationException("Connection string 'RentalDb'" +
    " not found.");
builder.Services
    .AddDbContext<RentalCarContext>(
        options =>
        {
            options.UseSqlServer(conString);
        })
    .AddTransient<IAutomobileService, AutomobileService>()
    .AddTransient<IUserService, UserService>()
    .AddTransient<IRentalService, RentalService>()
    .AddTransient<IRepositoryBase<Automobile>, AutomobileRepository>()
    .AddTransient<IRepositoryBase<Rental>, RentalRepository>()
    .AddTransient<IRepositoryBase<User>, UserRepository>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
