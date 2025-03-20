using ParkingAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace ParkingAPI.Repositories.Interfaces
{
    public interface IClienteRepository
    {
        Task<IEnumerable<Cliente>> GetAll();
        Task<Cliente> GetbyId(int id);
        Task<Cliente> Create(Cliente cliente);
        Task<Cliente> Update(int id, Cliente cliente);
        Task<Cliente> Delete(int id);
    }
}
