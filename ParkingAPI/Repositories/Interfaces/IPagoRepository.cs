using ParkingAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ParkingAPI.Repositories.Interfaces
{
    public interface IPagoRepository
    {
        Task<IEnumerable<Pago>> GetAllPago();
        Task<Pago> GetbyIdPago(int id);
        Task<Pago> CreatePago(Pago pago);
        Task<Pago> UpdatePago(int id,Pago pago);
        Task<Pago> DeletePago(int id);
    }
}
