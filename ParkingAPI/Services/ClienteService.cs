using ParkingAPI.Models;
using ParkingAPI.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace ParkingAPI.Services
{
    public class ClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<IEnumerable<Cliente>> GetAllClientes()
        {

            try
            {
                return await _clienteRepository.GetAll();

            }
            catch (Exception ex)
            { 
                throw new Exception("Error al obtener la lista",ex);
            }
        }

        public async Task<Cliente> GetClientebyId(int id)
        {
            if (id <= 0)
            {
                throw new Exception("El id no puede ser menor o igual a 0");
            }

            var cliente = await _clienteRepository.GetbyId(id);

            if (cliente == null)
            {
                throw new Exception("El cliente no existe");
            }

            return cliente;
        }

        public async Task<Cliente> CreateCliente(Cliente cliente)
        {
            return await _clienteRepository.Create(cliente);
        }

        public async Task<Cliente> UpdateCliente(int id, Cliente cliente)
        {
            return await _clienteRepository.Update(id, cliente);
        }

        public async Task<Cliente> DeleteCliente(int id)
        {
            return await _clienteRepository.Delete(id);
        }

    }
}
