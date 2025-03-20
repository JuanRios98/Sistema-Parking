namespace ParkingAPI.Models
{
    public class Celda
    {
        public int Id { get; set; }
        public required string Codigo { get; set; }
        
        public required string Tipo { get; set; }
        public string Estado { get; set; } = "Libre";
    }
}
