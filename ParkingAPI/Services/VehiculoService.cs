using ParkingAPI.Models;

using ParkingAPI.Repositories.Interfaces;
using System.Diagnostics.Contracts;

namespace ParkingAPI.Services
{
    public class VehiculoService
    {
        private readonly IVehiculoRepository _vehiculoRepository;

        public VehiculoService(IVehiculoRepository vehiculoRepository)
        {
            _vehiculoRepository = vehiculoRepository;
        }

        public async Task<IEnumerable<Vehiculo>> GetAllVehiculo()
        {
            try
            {
                return await _vehiculoRepository.GetAllVehiculo();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al obtener la lista", ex);
            }
        }

        public async Task<Vehiculo> GetbyIdVehiculo(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("El id no puede ser menor o igual a 0");
            }
            var vehiculo = await _vehiculoRepository.GetbyIdVehiculo(id);
            if (vehiculo == null)
            {
                throw new KeyNotFoundException("El vehiculo no existe");
            }
            return vehiculo;
        }

        public async Task<Vehiculo> CreateVehiculo(Vehiculo vehiculo)
        {
            if (vehiculo == null)
            {
                throw new ArgumentException("El vehiculo no puede ser nulo");
            }
            if (string.IsNullOrWhiteSpace(vehiculo.Placa))
            {
                throw new ArgumentException("La placa no puede ser nula o vacia");
            }
            if (vehiculo.ClienteId <= 0)
            {
                throw new ArgumentException("El cliente no puede ser nulo o vacio");
            }
            return await _vehiculoRepository.CreateVehiculo(vehiculo);
        }

        public async Task<Vehiculo> UpdateVehiculo(int id, Vehiculo vehiculo)
        {
            if (id <= 0)
            {
                throw new ArgumentException("El id no puede ser menor o igual a 0");
            }
            if (vehiculo == null)
            {
                throw new ArgumentException("El vehiculo no puede ser nulo");
            }
            if (string.IsNullOrWhiteSpace(vehiculo.Placa))
            {
                throw new ArgumentException("La placa no puede ser nula o vacia");
            }
            if (vehiculo.ClienteId <= 0)
            {
                throw new ArgumentException("El cliente no puede ser nulo o vacio");
            }
            return await _vehiculoRepository.UpdateVehiculo(id, vehiculo);
        }

        public async Task<Vehiculo> DeleteVehiculo(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("El id no puede ser menor o igual a 0");
            }
            return await _vehiculoRepository.DeleteVehiculo(id);
        }
    }
}
