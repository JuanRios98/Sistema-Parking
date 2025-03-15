namespace ParkingAPI.Models
{
    public class Celda
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        
        public string Tipo { get; set; }
        public string Estado { get; set; } = "Libre";
    }
}
