namespace ParkingAPI.Models
{
    public class Parking
    {
        
            public int Id { get; set; }
            public int? VehiculoId { get; set; }
            public int? CeldaId { get; set; }
            public int? TarifaId { get; set; }
            public DateTime FechaEntrada { get; set; } = DateTime.Now;
            public DateTime? FechaSalida { get; set; }
            public int? TotalPagado { get; set; }
            public string Estado { get; set; } = "Activo"; // Activo, Finalizado

    }
}
