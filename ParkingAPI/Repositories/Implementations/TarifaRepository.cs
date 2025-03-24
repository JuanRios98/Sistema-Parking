using Microsoft.EntityFrameworkCore;
using ParkingAPI.Data;
using ParkingAPI.Models;
using ParkingAPI.Repositories.Interfaces;

namespace ParkingAPI.Repositories.Implementations
{
    public class TarifaRepository : ITarifaRepository
    {

        private readonly ApplicationDbContext _context;

        public TarifaRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<Tarifa>> GetAllTarifa()
        {
            return await _context.Tarifa.ToListAsync();
        }

        public async Task<Tarifa> GetbyIdTarifa(int id)
        {
            return await _context.Tarifa.FindAsync(id);
        }

        public async Task<Tarifa> CreateTarifa(Tarifa tarifa)
        {
            _context.Tarifa.Add(tarifa);
            await _context.SaveChangesAsync();
            return tarifa;
        }

        public async Task<Tarifa> UpdateTarifa(int id, Tarifa tarifa)
        {
            var tarifaU = await _context.Tarifa.FindAsync(id);
            if (tarifaU == null)
            {
                return null;
            }

            tarifaU.Tipo = tarifa.Tipo;
            tarifaU.Monto = tarifa.Monto;
            tarifaU.VehiculoTipo = tarifa.VehiculoTipo;
            tarifaU.FechaActualizacion = tarifa.FechaActualizacion;

            await _context.SaveChangesAsync();
            return tarifa;
        }

        public async Task<Tarifa> DeleteTarifa(int id)
        {
            var tarifa = await _context.Tarifa.FindAsync(id);
            if (tarifa == null)
            {
                return null;
            }
            _context.Tarifa.Remove(tarifa);
            await _context.SaveChangesAsync();
            return tarifa;
        }
    }
}
