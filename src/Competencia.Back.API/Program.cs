using Competencia.Back.DAL.Interfaces;
using Competencia.Back.DAL.Repositorio;
using Competencia.Back.DL.Interfaces;
using Competencia.Back.DL.Services;
using Competencia.Back.Entities.Entities;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<CompetenciaDbContext>((options) => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IPersonaRepositorio, PersonaRepositorio>();
builder.Services.AddScoped<IOficinaRepositorio, OficinaRepositorio>();
builder.Services.AddScoped<IReservaRepositorio, ReservaRepositorio>();
builder.Services.AddScoped<IPersonaServices, PersonaServices>();
builder.Services.AddScoped<IOficinaServices, OficinaServices>();
builder.Services.AddScoped<IReservaServices, ReservaServices>();
var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
