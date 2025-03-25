using Microsoft.AspNetCore.Identity;
using ParkingAPI.Models;
using ParkingAPI.Repositories.Interfaces;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ParkingAPI.Services
{
    public class ParkingService
    {
        private readonly IParkingRepository _parkingRepository;
        public ParkingService(IParkingRepository parkingRepository)
        {
            _parkingRepository = parkingRepository;
        }
        public async Task<IEnumerable<Parking>> GetAllParking()
        {
            try
            {
                return await _parkingRepository.GetAllParking();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al obtener la lista", ex);
            }
        }
        public async Task<Parking> GetbyIdParking(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("El id no puede ser menor o igual a 0");
            }
            var parking = await _parkingRepository.GetbyIdParking(id);
            if (parking == null)
            {
                throw new KeyNotFoundException("El parking no existe");
            }
            return parking;
        }
        public async Task<Parking> CreateParking(Parking parking)
        {
            if (parking == null)
            {
                throw new ArgumentException("El parking no puede ser nulo");
            }
            if (parking.TotalPagado <= 0)
            {
                throw new ArgumentException("La cantidad no puede ser menor o igual a 0");
            }
            return await _parkingRepository.CreateParking(parking);
        }
        public async Task<Parking> UpdateParking(int id, Parking parking)
        {
            if (parking == null)
            {
                throw new ArgumentException("El parking no puede ser nulo");
            }
            if (parking.TotalPagado <= 0)
            {
                throw new ArgumentException("La cantidad no puede ser menor o igual a 0");
            }
            return await _parkingRepository.UpdateParking(id, parking);
        }
        public async Task<Parking> DeleteParking(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("El id no puede ser menor o igual a 0");
            }
            return await _parkingRepository.DeleteParking(id);
        }
    }
}
