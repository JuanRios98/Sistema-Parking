using Microsoft.EntityFrameworkCore;
using ParkingAPI.Models;
using ParkingAPI.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace ParkingAPI.Controllers
{
    [Route("api/cliente")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly ClienteService _clienteService;


        public ClienteController(ClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetClientes()
        {
            try
            {
                var clientes = await _clienteService.GetAllCliente();
                return Ok(clientes);


            }
            catch (Exception ex)
            { 
                return StatusCode(500, new { mensaje = "Ocurrio un error interno", error = ex.Message });

            }
    }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> GetCliente(int id)
        {
            try
            {
                var cliente = await _clienteService.GetbyIdCliente(id);
                return Ok(cliente);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { mensaje = ex.Message });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensaje = "Ocurrió un error interno", error = ex.Message });
            }
        }

        [HttpPost]
        public async Task<ActionResult<Cliente>> CreateCliente(Cliente cliente)
        {
            var newCliente = await _clienteService.CreateCliente(cliente);
            return CreatedAtAction(nameof(GetCliente), new { id = newCliente.Id }, newCliente);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Cliente>> UpdateCliente(int id,[FromBody] Cliente cliente)
        {
            cliente.Id = id;
            var clienteU = await _clienteService.UpdateCliente(id, cliente);

            if (clienteU == null)
            {
                return NotFound();
            }
            return Ok(clienteU);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCliente(int id)
        {
            await _clienteService.DeleteCliente(id);
            return NoContent();
        }
    }
}
