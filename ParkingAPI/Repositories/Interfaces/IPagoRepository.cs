using ParkingAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ParkingAPI.Repositories.Interfaces
{
    public interface IPagoRepository
    {
        Task<IEnumerable<Pago>> GetAll();
        Task<Pago> GetById(int id);
        Task<Pago> Create(Pago pago);
        Task<Pago> Update(Pago pago);
        Task<Pago> Delete(int id);
    }
}
