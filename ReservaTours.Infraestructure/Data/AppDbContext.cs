using Microsoft.EntityFrameworkCore;
using ReservaTours.Domain.Entities;

namespace ReservaTours.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Tour> Tours { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
    }
}
