using ParkingAPI.Repositories.Interfaces;
using ParkingAPI.Data;
using ParkingAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ParkingAPI.Repositories.Implementations
{
    public class ParkingRepository : IParkingRepository

    {
        private readonly ApplicationDbContext _context;

        public ParkingRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Parking>> GetAllParking()
        {
            return await _context.Parking.ToListAsync();
        }

        public async Task<Parking> GetbyIdParking(int id)
        {
            return await _context.Parking.FindAsync(id);
        }

        public async Task<Parking> CreateParking(Parking parking)
        {
            _context.Parking.Add(parking);
            await _context.SaveChangesAsync();
            return parking;
        }

        public async Task<Parking> UpdateParking(int id, Parking parking)
        {
            var parkingU = await _context.Parking.FindAsync(id);
            if (parkingU == null)
            {
                return null;
            }
            parkingU.TarifaId = parking.TarifaId;
            parkingU.VehiculoId = parking.VehiculoId;
            parkingU.CeldaId = parking.CeldaId;
            parkingU.FechaEntrada = parking.FechaEntrada;
            parkingU.FechaSalida = parking.FechaSalida;
            parkingU.TotalPagado = parking.TotalPagado;
            parkingU.Estado = parking.Estado;
            await _context.SaveChangesAsync();
            return parkingU;
        } 

        public async Task<Parking> DeleteParking(int id)
        {
            var parking = await _context.Parking.FindAsync(id);
            if (parking == null)
            {
                return null;
            }
            _context.Parking.Remove(parking);
            await _context.SaveChangesAsync();
            return parking;
        }
    }
}
