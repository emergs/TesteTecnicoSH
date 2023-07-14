using Microsoft.EntityFrameworkCore;
using TesteTecnico.Models;

namespace TesteTecnico.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<ClienteModel> Cliente { get; set; }
    }
}
