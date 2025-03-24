using ParkingAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ParkingAPI.Repositories.Interfaces
{
    public interface ITarifaRepository
    {
        Task<IEnumerable<Tarifa>> GetAllTarifa();
        Task<Tarifa> GetbyIdTarifa(int id);
        Task<Tarifa> CreateTarifa(Tarifa tarifa);
        Task<Tarifa> UpdateTarifa(int id, Tarifa tarifa);
        Task<Tarifa> DeleteTarifa(int id);
    }
}
