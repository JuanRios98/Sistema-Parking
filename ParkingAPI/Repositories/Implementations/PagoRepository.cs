using ParkingAPI.Repositories.Interfaces;
using ParkingAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using ParkingAPI.Data;
using Microsoft.EntityFrameworkCore;


namespace ParkingAPI.Repositories.Implementations
{
    public class PagoRepository : IPagoRepository
    {
        private readonly ApplicationDbContext _context;

        public PagoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Pago>> GetAllPago()
        {
            return await _context.Pago.ToListAsync();
        }

        public async Task<Pago> GetbyIdPago(int id)
        {
            return await _context.Pago.FindAsync(id);
        }

        public async Task<Pago> CreatePago(Pago pago)
        {
            _context.Pago.Add(pago);
            await _context.SaveChangesAsync();
            return pago;
        }

        public async Task<Pago> UpdatePago(int id, Pago pago)
        {
            var pagoU = await _context.Pago.FindAsync(id);
            if (pagoU == null)
            {
                return null;
            }
            pagoU.ParkingId= pago.ParkingId;
            pagoU.Monto = pago.Monto;
            pagoU.ClienteId = pago.ClienteId;
            await _context.SaveChangesAsync();
            return pagoU;
        }

        public async Task<Pago> DeletePago(int id)
        {
            var pago = await _context.Pago.FindAsync(id);
            if (pago == null)
            {
                return null;
            }
            _context.Pago.Remove(pago);
            await _context.SaveChangesAsync();
            return pago;
        }









    }
}
