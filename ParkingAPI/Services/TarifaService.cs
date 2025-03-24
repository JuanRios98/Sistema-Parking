using ParkingAPI.Models;
using ParkingAPI.Repositories.Interfaces;
using System;
using System.Threading.Tasks;

namespace ParkingAPI.Services
{
    public class TarifaService
    {
        private readonly ITarifaRepository _tarifaRepository;

        public TarifaService(ITarifaRepository tarifaRepository)
        {
            _tarifaRepository = tarifaRepository;
        }


        public async Task<IEnumerable<Tarifa>> GetAllTarifa()
        {
            try
            {
                return await _tarifaRepository.GetAllTarifa();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al obtener la lista", ex);
            }
        }

        public async Task<Tarifa> GetbyIdTarifa(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("El id no puede ser menor o igual a 0");
            }
            var tarifa = await _tarifaRepository.GetbyIdTarifa(id);
            if (tarifa == null)
            {
                throw new KeyNotFoundException("La tarifa no existe");
            }
            return tarifa;
        }

        public async Task<Tarifa> CreateTarifa(Tarifa tarifa)
        {
            if (tarifa == null)
            {
                throw new ArgumentException("La tarifa no puede ser nula");
            }
            if (tarifa.Monto <= 0)
            {
                throw new ArgumentException("El precio no puede ser menor o igual a 0");
            }
            return await _tarifaRepository.CreateTarifa(tarifa);
        }

        public async Task<Tarifa> UpdateTarifa(int id, Tarifa tarifa)
        {
            if (tarifa == null)
            {
                throw new ArgumentException("La tarifa no puede ser nula");
            }
            if (tarifa.Monto <= 0)
            {
                throw new ArgumentException("El precio no puede ser menor o igual a 0");
            }
            return await _tarifaRepository.UpdateTarifa(id, tarifa);
        }

        public async Task<Tarifa> DeleteTarifa(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("El id no puede ser menor o igual a 0");
            }
            return await _tarifaRepository.DeleteTarifa(id);
        }
    }
}
