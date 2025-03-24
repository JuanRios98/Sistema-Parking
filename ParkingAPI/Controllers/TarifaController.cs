using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ParkingAPI.Models;
using ParkingAPI.Services;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace ParkingAPI.Controllers
{
    [Route("api/tarifa")]
    [ApiController]
    public class TarifaController : ControllerBase


    {
        private readonly TarifaService _tarifaService;

        public TarifaController(TarifaService tarifaService)
        {
            _tarifaService = tarifaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tarifa>>> GetAllTarifa()
        {
            try
            {
                var tarifas = await _tarifaService.GetAllTarifa();
                return Ok(tarifas);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensaje = "Ocurrio un error interno", error = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Tarifa>> GetbyId(int id)
        {
            try
            {
                var tarifa = await _tarifaService.GetbyIdTarifa(id);
                return Ok(tarifa);
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
        public async Task<ActionResult<Tarifa>> CreateTarifa([FromBody] Tarifa tarifa)
        {
            try
            {
                var tarifaCreada = await _tarifaService.CreateTarifa(tarifa);
                return CreatedAtAction(nameof(GetbyId), new { id = tarifaCreada.Id }, tarifaCreada);
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
        public async Task<ActionResult<Tarifa>> UpdateTarifa(int id, [FromBody] Tarifa tarifa)
        {
            try
            {
                var tarifaActualizada = await _tarifaService.UpdateTarifa(id, tarifa);
                return Ok(tarifaActualizada);
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
        public async Task<ActionResult> DeleteTarifa(int id)
        {
            try
            {
                await _tarifaService.DeleteTarifa(id);
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
