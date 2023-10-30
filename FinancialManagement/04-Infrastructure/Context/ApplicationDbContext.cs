using FinancialManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinancialManagement.Infra.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private readonly IConfiguration _configuration;

        public DbSet<Expenses> Product { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration["ConnectionString"]);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
           => modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}