using Microsoft.EntityFrameworkCore;
using RESTAPI_Alimentos.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
//Registrando servicio de DbContext para inyeccion de dependencias
builder.Services.AddDbContext<API_AlimentosContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ConexionDefault")));



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

app.UseAuthorization();

app.MapControllers();

app.Run();
