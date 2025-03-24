using Microsoft.EntityFrameworkCore;
using ParkingAPI.Models;
using ParkingAPI.Repositories.Implementations;
using ParkingAPI.Repositories.Interfaces;
using System.Reflection.Metadata.Ecma335;
using System.Text.RegularExpressions;


namespace ParkingAPI.Services
{
    public class CeldaService
    {
        private readonly ICeldaRepository _celdaRepository;

        public CeldaService(ICeldaRepository celdaRepository)
        {
            _celdaRepository = celdaRepository;
        }

        private bool ValidarTipoVehiculo(string tipo)
        {
            return tipo.Equals("Moto", StringComparison.OrdinalIgnoreCase)
                || tipo.Equals("Carro", StringComparison.OrdinalIgnoreCase) ;
        }

     
        public async Task<IEnumerable<Celda>> GetAllCeldas()
        {
            try
            {
                return await _celdaRepository.GetAll();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al obtener la lista", ex);
            }
        }

        public async Task<Celda> GetbyId(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("El id no puede ser menor o igual a 0");
            }
            var celda = await _celdaRepository.GetbyId(id);
            if (celda == null)
            {
                throw new KeyNotFoundException("La celda no existe");
            }
            return celda;
        }

        public async Task<Celda> CreateCelda(Celda celda)
        {
            if (celda == null)
            {
                throw new ArgumentException("La celda no puede ser nula");
            }

            if (string.IsNullOrWhiteSpace(celda.Codigo))
            {
                throw new ArgumentException("El codigo de celda no puede estar vacio y contener espacios");
            }

            celda.Codigo = celda.Codigo.Trim();

            if (!Regex.IsMatch(celda.Codigo, @"^[A-Za-z0-9]{2,10}$"))
            {
                throw new ArgumentException("El codigo debe tener solo letras y numeros, sin caracteres especiales");
            }

            if (!ValidarTipoVehiculo(celda.Tipo))
            {
                throw new ArgumentException("El tipo de vehiculo solo puede ser moto o carro");
            }

            var celdasE = await _celdaRepository.GetbyId(celda.Id);
            if (celdasE != null)
            {
                throw new InvalidOperationException("La celda con ese codigo ya existe");
            }

            await _celdaRepository.Create(celda);
            return celda;
        }

        public async Task<Celda> UpdateCelda(int id, Celda celda)
        {
            
            if (celda.Id == null || celda.Id == 0)
            {
                throw new ArgumentException("El Id de la celda no puede ser nulo o cero.");
            }

            var celdaExistente = await _celdaRepository.GetbyId(celda.Id);
            if (celdaExistente == null)
            {
                throw new KeyNotFoundException("No se encontró la celda con el Id especificado.");
            }

            if (string.IsNullOrWhiteSpace(celda.Codigo))
            {
                throw new ArgumentException("El código de la celda no puede estar vacío o contener espacios.");
            }

            celda.Codigo = celda.Codigo.Trim();

            if (!Regex.IsMatch(celda.Codigo, @"^[A-Za-z0-9]{2,10}$"))
            {
                throw new ArgumentException("El código debe tener entre 5 y 10 caracteres alfanuméricos, sin caracteres especiales.");
            }

         
            if (!ValidarTipoVehiculo(celda.Tipo))
            {
                throw new ArgumentException("El tipo de vehículo solo puede ser 'moto' o 'carro'.");
            }
            await _celdaRepository.Update(id, celda);
            return celda;
          
        }

        public async Task<Celda> DeleteCelda(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("El id no puede ser menor o igual a 0");
            }
            var tarifa = await _celdaRepository.GetbyId(id);
            if (tarifa == null)
            {
                throw new KeyNotFoundException("La tarifa no fue encontrada");
            }

            try
            {
                return await _celdaRepository.Delete(id);
            }
            catch (Exception ex)
            {
                throw new KeyNotFoundException("Error al eliminar la celda", ex);
            }
        }
    }
}
