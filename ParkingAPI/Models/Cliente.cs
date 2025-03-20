namespace ParkingAPI.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public required string Nombre { get; set; }
        public int Identificacion { get; set; }
        public required string TipoPlan { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
    }
}
