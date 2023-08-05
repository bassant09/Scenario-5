using AppNest_Project.Models;
using Microsoft.EntityFrameworkCore;

namespace AppNest_Project.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        
        public DbSet<User> Users { get; set; }
        public DbSet<Images> Images{ get; set; }
        public DbSet<Shelter> Shelters { get; set; }
        public DbSet<Resources> Resources { get; set; }
        public DbSet<Booking> Books { get; set; }
    }
}
