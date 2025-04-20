
using ReservaTours.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReservaTours.Application.Interfaces
{
    public interface ITourRepository
    {
        Task<List<Tour>> GetAllAsync();
        Task<Tour> GetByIdAsync(int id);
        Task AddAsync(Tour tour);
        Task UpdateAsync(Tour tour);
        Task DeleteAsync(int id);
    }
}
