using ParkingAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ParkingAPI.Repositories.Interfaces
{
    public interface IParkingRepository
    {
        Task<IEnumerable<Parking>> GetAllParking();
        Task<Parking> GetbyIdParking(int id);
        Task<Parking> CreateParking(Parking parking);
        Task<Parking> UpdateParking(int id, Parking parking);
        Task<Parking> DeleteParking(int id);
    }
}
