using ParkingAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ParkingAPI.Repositories.Interfaces
{
    public interface IVehiculoRepository
    {
        Task<IEnumerable<Vehiculo>> GetAllVehiculo();
        Task<Vehiculo> GetbyIdVehiculo(int id);
        Task<Vehiculo> CreateVehiculo(Vehiculo vehiculo);
        Task<Vehiculo> UpdateVehiculo(int id,Vehiculo vehiculo);
        Task<Vehiculo> DeleteVehiculo(int id);

    }
}
