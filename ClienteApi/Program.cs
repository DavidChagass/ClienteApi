using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ClienteApi.Data;
using ClienteApi;
using System;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ClienteApiContext>(options => options.UseInMemoryDatabase("clientedb"));



// Add services to the container.
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



app.MapClienteEndpoints();

app.Run();

