using ParkingAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace ParkingAPI.Repositories.Interfaces
{
    public interface IClienteRepository
    {
        Task<IEnumerable<Cliente>> GetAllCliente();
        Task<Cliente> GetbyIdCliente(int id);
        Task<Cliente> CreateCliente(Cliente cliente);
        Task<Cliente> UpdateCliente(int id, Cliente cliente);
        Task<Cliente> DeleteCliente(int id);
    }
}
