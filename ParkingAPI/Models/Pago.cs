using Microsoft.Identity.Client;

namespace ParkingAPI.Models
{
    public class Pago
    {
        public int Id { get; set; }
        public int? ParkingId { get; set; }
        public int? ClienteId { get; set; }
        public int Monto { get; set; }

        public Cliente? Cliente { get; set; }
        public Parking? Parking { get; set; }
    }
}
