// ReservaTours.Infrastructure/Repositories/TourRepository.cs
using Microsoft.EntityFrameworkCore;
using ReservaTours.Application.Interfaces;
using ReservaTours.Domain.Entities;
using ReservaTours.Infrastructure.Data;

namespace ReservaTours.Infrastructure.Repositories
{
    public class TourRepository : ITourRepository
    {
        private readonly AppDbContext _context;

        public TourRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Tour>> GetAllAsync() => await _context.Tours.ToListAsync();
        public async Task<Tour> GetByIdAsync(int id) => await _context.Tours.FindAsync(id);
        public async Task AddAsync(Tour tour)
        {
            _context.Tours.Add(tour);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Tour tour)
        {
            _context.Tours.Update(tour);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var tour = await _context.Tours.FindAsync(id);
            if (tour != null)
            {
                _context.Tours.Remove(tour);
                await _context.SaveChangesAsync();
            }
        }
    }
}
