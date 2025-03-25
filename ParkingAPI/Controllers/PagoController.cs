using ParkingAPI.Models;
using ParkingAPI.Services;
using ParkingAPI.Repositories.Interfaces;
using System;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;



namespace ParkingAPI.Controllers
{

    [Route("api/pago")]
    [ApiController]

    public class PagoController : ControllerBase
    {
        private readonly PagoService _pagoService;

        public PagoController(PagoService pagoService)
        {
            _pagoService = pagoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pago>>> GetAllPago()
        {
            try
            {
                var pagos = await _pagoService.GetAllPago();
                return Ok(pagos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensaje = "Ocurrio un error interno", error = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Pago>> GetbyIdPago(int id)
        {
            try
            {
                var pago = await _pagoService.GetbyIdPago(id);
                return Ok(pago);
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
        public async Task<ActionResult<Pago>> CreatePago(Pago pago)
        {
            try
            {
                var newPago = await _pagoService.CreatePago(pago);
                return CreatedAtAction(nameof(GetbyIdPago), new { id = newPago.Id }, newPago);
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
        public async Task<ActionResult<Pago>> UpdatePago(int id, Pago pago)
        {
            try
            {
                var PagoU = await _pagoService.UpdatePago(id, pago);
                return Ok(PagoU);
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
        public async Task<ActionResult<Pago>> DeletePago(int id)
        {
            try
            {
                var pago = await _pagoService.DeletePago(id);
                return Ok(pago);
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
