using Microsoft.EntityFrameworkCore;
using ParkingAPI.Models;


namespace ParkingAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Vehiculo> Vehiculo { get; set; }
        public DbSet<Celda> Celda { get; set; }
        public DbSet<Parking> Parking { get; set; }
        public DbSet<Pago> Pago { get; set; }

        public DbSet<Tarifa> Tarifa { get; set; }

    }
}


