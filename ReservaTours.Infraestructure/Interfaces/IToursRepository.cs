using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReservaTours.Domain.Entities;


namespace ReservaTours.Infraestructure.Interfaces
{ 
public interface ITourRepository
{
    Task<IEnumerable<Tour>> GetAllAsync();
    Task<Tour> GetByIdAsync(int id);
    Task<Tour> AddAsync(Tour tour);
    Task<Tour> UpdateAsync(Tour tour);
    Task<bool> DeleteAsync(int id);
    }
}
