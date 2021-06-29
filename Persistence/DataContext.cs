using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class DataContext : DbContext
    { 
        public DataContext(DbContextOptions options) : base(options)
        {        
        }

        public DbSet<Portfolio> Portfolios { get; set; }
        public DbSet<Security> Securities { get; set; }
        public DbSet<Holding> Holdings { get; set; }    
    }
}