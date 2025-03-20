using ParkingAPI.Data;
using Microsoft.EntityFrameworkCore;
using ParkingAPI.Repositories.Implementations;
using ParkingAPI.Repositories.Interfaces;
using ParkingAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

// Inyeccion de controlador

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Inyeccíon Repositorio

builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<ICeldaRepository, CeldaRepository>();

// Inyeccion Servicios

builder.Services.AddScoped<ClienteService>();
builder.Services.AddScoped<CeldaService>();

//Conexion a la base de datos
builder.Services.AddDbContext<ApplicationDbContext>
    (options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


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
