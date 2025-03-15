namespace ParkingAPI.Models
{
    public class Vehiculo
    {
        public int Id { get; set; }
        public int? ClienteId { get; set; }
        public required string Placa { get; set; }

        public Cliente? Cliente { get; set; }

    }
}
