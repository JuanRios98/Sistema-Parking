namespace ParkingAPI.Models
{
    public class Tarifa
    {
        public int Id { get; set; }
        public required string Tipo { get; set; }
        public required string VehiculoTipo { get; set; }
        public int Monto { get; set; }
        public DateTime FechaActualizacion { get; set; }



    }
}
