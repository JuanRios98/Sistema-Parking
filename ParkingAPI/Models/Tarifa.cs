namespace ParkingAPI.Models
{
    public class Tarifa
    {
        public int Id { get; set; }
        public string Tipo { get; set; }
        public string VehiculoTipo { get; set; }
        public int Monto { get; set; }
       
        public DateTime FechaActualizacíon { get; set; }



    }
}
