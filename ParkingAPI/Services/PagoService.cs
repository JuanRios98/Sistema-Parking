using ParkingAPI.Models;
using ParkingAPI.Repositories.Interfaces;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ParkingAPI.Services
{
    public class PagoService
    {
        private readonly IPagoRepository _pagoRepository;

       public PagoService(IPagoRepository pagoRepository)
        {
            _pagoRepository = pagoRepository;
        }
        public async Task<IEnumerable<Pago>> GetAllPago()
        {
            try
            {
                return await _pagoRepository.GetAllPago();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al obtener la lista", ex);
            }
        }
        public async Task<Pago> GetbyIdPago(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("El id no puede ser menor o igual a 0");
            }
            var pago = await _pagoRepository.GetbyIdPago(id);
            if (pago == null)
            {
                throw new KeyNotFoundException("El pago no existe");
            }
            return pago;
        }
        public async Task<Pago> CreatePago(Pago pago)
        {
            if (pago == null)
            {
                throw new ArgumentException("El pago no puede ser nulo");
            }
            if (pago.Monto <= 0)
            {
                throw new ArgumentException("El precio no puede ser menor o igual a 0");
            }
            return await _pagoRepository.CreatePago(pago);
        }
        public async Task<Pago> UpdatePago(int id, Pago pago)
        {
            if (pago == null)
            {
                throw new ArgumentException("El pago no puede ser nulo");
            }
            if (pago.Monto <= 0)
            {
                throw new ArgumentException("El precio no puede ser menor o igual a 0");
            }
            return await _pagoRepository.UpdatePago(id, pago);
        }
        public async Task<Pago> DeletePago(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("El id no puede ser menor o igual a 0");
            }
            return await _pagoRepository.DeletePago(id);
        }


    }
}
