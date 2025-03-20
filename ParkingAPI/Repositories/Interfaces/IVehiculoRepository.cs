using ParkingAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ParkingAPI.Repositories.Interfaces
{
    public interface IVehiculoRepository
    {
        Task<IEnumerable<Vehiculo>> GetAll();
        Task<Vehiculo> GetById(int id);
        Task<Vehiculo> Create(Vehiculo vehiculo);
        Task<Vehiculo> Update(Vehiculo vehiculo);

    }
}
