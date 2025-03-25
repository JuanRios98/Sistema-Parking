using Microsoft.AspNetCore.Mvc;
using System;
using ParkingAPI.Services;
using System.Threading.Tasks;
using ParkingAPI.Models;


namespace ParkingAPI.Controllers
{
    [Route("api/parking")]
    [ApiController]
    public class ParkingController : ControllerBase
    {
        private readonly ParkingService _parkingService;
        public ParkingController(ParkingService parkingService)
        {
            _parkingService = parkingService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Parking>>> GetAllParking()
        {
            try
            {
                var parkings = await _parkingService.GetAllParking();
                return Ok(parkings);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensaje = "Ocurrio un error interno", error = ex.Message });
            }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Parking>> GetbyId(int id)
        {
            try
            {
                var parking = await _parkingService.GetbyIdParking(id);
                return Ok(parking);
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
        public async Task<ActionResult<Parking>> CreateParking(Parking parking)
        {
            try
            {
                var newParking = await _parkingService.CreateParking(parking);
                return CreatedAtAction(nameof(GetbyId), new { id = newParking.Id }, newParking);
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
        public async Task<ActionResult<Parking>> UpdateParking(int id, Parking parking)
        {
            try
            {
                var updatedParking = await _parkingService.UpdateParking(id, parking);
                return Ok(updatedParking);
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
        public async Task<ActionResult<Parking>> DeleteParking(int id)
        {
            try
            {
                return await _parkingService.DeleteParking(id);
               
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
