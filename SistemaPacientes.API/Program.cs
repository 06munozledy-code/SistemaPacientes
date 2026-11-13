using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using SistemaPacientes.Application.Interfaces;
using SistemaPacientes.Application.Services;
using SistemaPacientes.Domain.Interfaces;
using SistemaPacientes.Infrastructure.Data;
using SistemaPacientes.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Base de datos
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Repositorio y servicio genéricos (inyección de dependencias por interfaces)
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped(typeof(IService<>), typeof(Service<>));

// CORS (para que el frontend pueda consumir la API)
builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirFrontend", policy =>
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});

// Controladores: no exige las propiedades de navegación y evita ciclos en el JSON
builder.Services.AddControllers(o =>
        o.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true)
    .AddJsonOptions(o =>
        o.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("PermitirFrontend");

app.UseAuthorization();

app.MapControllers();

app.Run();