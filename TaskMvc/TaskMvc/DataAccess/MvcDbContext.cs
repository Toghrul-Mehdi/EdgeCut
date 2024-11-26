using Microsoft.EntityFrameworkCore;
using TaskMvc.Models;

namespace TaskMvc.DataAccess
{
    public class MvcDbContext : DbContext
    {
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public MvcDbContext(DbContextOptions opt) : base(opt) { }
    }
}
