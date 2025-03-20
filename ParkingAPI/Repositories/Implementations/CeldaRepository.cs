using ParkingAPI.Models;
using ParkingAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using ParkingAPI.Data;
using System.Formats.Asn1;

namespace ParkingAPI.Repositories.Implementations
{
    public class CeldaRepository : ICeldaRepository
    {
        private readonly ApplicationDbContext _context;

        public CeldaRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<Celda>> GetAll()
        {
            return await _context.Celda.ToListAsync();
        }

        public async Task<Celda> GetbyId(int id)
        {
            return await _context.Celda.FindAsync(id);
        }

        public async Task<Celda> Create(Celda celda)
        {
            _context.Celda.Add(celda);
            await _context.SaveChangesAsync();
            return celda;
        }

        public async Task<Celda> Update(int id, Celda celda)
        {
            var celdas = await _context.Celda.FindAsync(id);

            if (celdas == null)
            {
                return null;
            }

            celdas.Codigo = celda.Codigo;
            celdas.Tipo = celda.Tipo;
            celdas.Estado = celda.Estado;

            await _context.SaveChangesAsync();

            return celdas;
        }

        public async Task<Celda> Delete(int id)
        {
            var celda = await _context.Celda.FindAsync(id);

            if (celda == null)
            {
                return null;
            }

            _context.Celda.Remove(celda);
            await _context.SaveChangesAsync();
            return celda;
        }

      
    }
}
