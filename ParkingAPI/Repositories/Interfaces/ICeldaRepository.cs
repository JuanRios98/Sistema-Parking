using ParkingAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;



namespace ParkingAPI.Repositories.Interfaces
{
    public interface ICeldaRepository
    {
        Task<IEnumerable<Celda>> GetAll();
        Task<Celda> GetbyId(int id);
        Task<Celda> Create(Celda celda);
        Task<Celda> Update(int id, Celda celda);
        Task<Celda> Delete(int id);
    }
}
