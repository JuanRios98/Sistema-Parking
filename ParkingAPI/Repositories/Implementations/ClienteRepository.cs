using ParkingAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using ParkingAPI.Repositories.Interfaces;
using ParkingAPI.Data;

namespace ParkingAPI.Repositories.Implementations
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ApplicationDbContext _context;

        public ClienteRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Cliente>> GetAll()
        {
            return await _context.Cliente.ToListAsync();
        }

        public async Task<Cliente> GetbyId(int id)
        {
            return await _context.Cliente.FindAsync(id);
        }

        public async Task<Cliente> Create(Cliente cliente)
        {
            _context.Cliente.Add(cliente);
            await _context.SaveChangesAsync();
            return cliente;
        }

        public async Task<Cliente> Update(int id, Cliente cliente)
        {
            var clientes = await _context.Cliente.FindAsync(id);

            if (clientes == null)
            {
                return null;
            }

            clientes.Nombre = cliente.Nombre;
            clientes.Identificacion = cliente.Identificacion;
            clientes.TipoPlan = cliente.TipoPlan;
            clientes.FechaInicio = cliente.FechaInicio;
            clientes.FechaFin = cliente.FechaFin;

            await _context.SaveChangesAsync();

            return clientes;


        }

        public async Task<Cliente> Delete(int id)
        {
            var cliente = await _context.Cliente.FindAsync(id);
            if (cliente == null)
            {
                return null;
            }
            _context.Cliente.Remove(cliente);
            await _context.SaveChangesAsync();
            return cliente;
        }

    }
}
