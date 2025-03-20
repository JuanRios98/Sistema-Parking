using Microsoft.EntityFrameworkCore;
using ParkingAPI.Models;
using ParkingAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging.Abstractions;




namespace ParkingAPI.Controllers
{

    [Route("api/celda")]
    [ApiController]

    public class CeldaController : ControllerBase
    {

        public readonly CeldaService _celdaService;

        public CeldaController(CeldaService celdaService)
        {
            _celdaService = celdaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Celda>>> GetAllCeldas()
        {
            try
            { 
                var Celdas = await _celdaService.GetAllCeldas();
                return Accepted(Celdas);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensaje = "Ocurrio un error interno", error = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Celda>> GetbyId(int id)
        {
            try
            {
                var celda = await _celdaService.GetbyId(id);
                return Accepted(celda);
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
        public async Task<ActionResult<Celda>> CreateCelda(Celda celda)
        {
                var Celda = await _celdaService.CreateCelda(celda);
                return CreatedAtAction(nameof(GetAllCeldas), new { id = Celda.Id }, Celda);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Celda>> UpdateCelda(int id,[FromBody] Celda celda)
        {
            celda.Id = id;
            var CeldaU = await _celdaService.UpdateCelda(id, celda);

            if (CeldaU == null)
            {
                return NotFound(new { mensaje = "La celda no existe" });
            }
            return Ok(CeldaU);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Celda>> DeleteCelda(int id)
        {
            await _celdaService.DeleteCelda(id);
            return NoContent();
        }





    }
}
