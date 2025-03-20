using ParkingAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ParkingAPI.Repositories.Interfaces
{
    public interface ITarifaRepository
    {
        Task<IEnumerable<Tarifa>> GetAll();
        Task<Tarifa> GetById(int id);
        Task<Tarifa> Create(Tarifa tarifa);
        Task<Tarifa> Update(Tarifa tarifa);
        Task<Tarifa> Delete(int id);
    }
}
