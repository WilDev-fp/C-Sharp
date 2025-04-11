using Microsoft.EntityFrameworkCore;
using RentalCarsWithRepositoryDesignPattern.Infrastructure.Context;
using System;

var builder = WebApplication.CreateBuilder(args);

var conString = builder.Configuration.GetConnectionString("RentalDb") ??
     throw new InvalidOperationException("Connection string 'RentalDb'" +
    " not found.");
builder.Services.AddDbContext<RentalCarContext>(
    options => {
        options.UseSqlServer(conString);
    });

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

/*
using (var serviceScope = app.Services.CreateScope())
{
    var dbContext = serviceScope.ServiceProvider.GetRequiredService<RentalCarContext>();
    await dbContext.Database.EnsureCreatedAsync();
    // or dbContext.Database.EnsureCreatedAsync();
}
*/

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
