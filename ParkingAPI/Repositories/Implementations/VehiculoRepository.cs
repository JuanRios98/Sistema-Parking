using ParkingAPI.Models;
using ParkingAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using ParkingAPI.Data;
using Microsoft.AspNetCore.Identity;

namespace ParkingAPI.Repositories.Implementations
{
    public class VehiculoRepository : IVehiculoRepository
    {

    public readonly ApplicationDbContext _context;

    public VehiculoRepository(ApplicationDbContext context)
    {
       _context = context;
    }

        public async Task<IEnumerable<Vehiculo>> GetAllVehiculo() 
        {
            return await _context.Vehiculo.ToListAsync();
        }

        public async Task<Vehiculo> GetbyIdVehiculo(int id) 
        {
            return await _context.Vehiculo.FindAsync(id);
        }

        public async Task<Vehiculo> CreateVehiculo(Vehiculo vehiculo)
        {
            _context.Vehiculo.Add(vehiculo);
            await _context.SaveChangesAsync();
            return vehiculo ;
        }

        public async Task<Vehiculo> UpdateVehiculo(int id, Vehiculo vehiculo)
        {
            var Vehiculo = await _context.Vehiculo.FindAsync(id);
            if (Vehiculo == null)
            {
                return null;
            }

            Vehiculo.Placa = vehiculo.Placa;
            vehiculo.ClienteId = vehiculo.ClienteId;

            await _context.SaveChangesAsync();
            return Vehiculo;
        }

        public async Task<Vehiculo> DeleteVehiculo(int id)
        {
            var Vehiculo = await _context.Vehiculo.FindAsync(id);
            if (Vehiculo == null)
            {
                return null;
            }
            _context.Vehiculo.Remove(Vehiculo);
            await _context.SaveChangesAsync();
            return Vehiculo;
        }


    }
}
