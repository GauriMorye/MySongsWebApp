using Microsoft.EntityFrameworkCore;
using MySongsWebApp.Models;

namespace MySongsWebApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }
        public DbSet<MySongs> Songs { get; set; }
    }
}
