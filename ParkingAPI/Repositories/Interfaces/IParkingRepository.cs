using ParkingAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ParkingAPI.Repositories.Interfaces
{
    public interface IParkingRepository
    {
        Task<IEnumerable<Parking>> GetAll();
        Task<Parking> GetbyId(int id);
        Task<Parking> Create(Parking parking);
        Task<Parking> Update(Parking parking);
        Task<Parking> Delete(int id);
    }
}
