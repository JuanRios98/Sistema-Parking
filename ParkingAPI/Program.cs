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
builder.Services.AddScoped<IVehiculoRepository, VehiculoRepository>();
builder.Services.AddScoped<IPagoRepository, PagoRepository>();
builder.Services.AddScoped<IParkingRepository, ParkingRepository>();
builder.Services.AddScoped<ITarifaRepository, TarifaRepository>();


// Inyeccion Servicios

builder.Services.AddScoped<ClienteService>();
builder.Services.AddScoped<CeldaService>();
builder.Services.AddScoped<VehiculoService>();
builder.Services.AddScoped<PagoService>();
builder.Services.AddScoped<ParkingService>();
builder.Services.AddScoped<TarifaService>();

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
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
