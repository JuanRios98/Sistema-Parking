using Microsoft.EntityFrameworkCore;
using ParkingApi.Models;


namespace ParkingAPI.Data
{
    public class ApplicationDbConnections : DbContext
    {
        public ApplicationDbConnections(DbContextOptions<ApplicationDbConnections> options) : base(options)
        {
        }
        public DbSet<Cliente> Cliente { get; set }
        public DbSet<Vehiculo> Vehiculo { get; set }
        public DbSet<Celda> Celda { get; set; }
        public DbSet<Tarifa> Tarifa { get; set; }
        public DbSet<Parking> Parking { get; set; }
        public DbSet<Pago> Pago { get; set; }


    }
}


