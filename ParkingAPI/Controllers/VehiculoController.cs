using ParkingAPI.Models;
using ParkingAPI.Services;
using ParkingAPI.Repositories.Interfaces;
using System;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;




namespace ParkingAPI.Controllers
{
    [Route("api/vehiculo")]
    [ApiController]
    public class VehiculoController : Controller
    {
        private readonly VehiculoService _vehiculoService;

        public VehiculoController(VehiculoService vehiculoService)
        {
            _vehiculoService = vehiculoService;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vehiculo>>> GetAllVehiculo()
        {
            try
            {
                var vehiculos = await _vehiculoService.GetAllVehiculo();
                return Ok(vehiculos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensaje = "Ocurrio un error interno", error = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Vehiculo>> GetbyId(int id)
        {
            try
            {
                var vehiculo = await _vehiculoService.GetbyIdVehiculo(id);
                return Ok(vehiculo);
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
                return StatusCode(500, new { mensaje = "Ocurrio un error interno", error = ex.Message });
            }
        }

        [HttpPost]
        public async Task<ActionResult<Vehiculo>> CreateVehiculo([FromBody] Vehiculo vehiculo)
        {
            try
            {
                var newVehiculo = await _vehiculoService.CreateVehiculo(vehiculo);
                return CreatedAtAction(nameof(GetbyId), new { id = newVehiculo.Id }, newVehiculo);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensaje = "Ocurrio un error interno", error = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Vehiculo>> UpdateVehiculo(int id, [FromBody] Vehiculo vehiculo)
        {
            try
            {
                var updatedVehiculo = await _vehiculoService.UpdateVehiculo(id, vehiculo);
                return Ok(updatedVehiculo);
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
                return StatusCode(500, new { mensaje = "Ocurrio un error interno", error = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteVehiculo(int id)
        {
            try
            {
                await _vehiculoService.DeleteVehiculo(id);
                return NoContent();
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
                return StatusCode(500, new { mensaje = "Ocurrio un error interno", error = ex.Message });
            }
        }
    }
}
