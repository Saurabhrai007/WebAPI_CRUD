using APICore.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace APICore.Data
{
    public class AplDBContext : DbContext
    {
        public AplDBContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Employee> employees { get; set; }
    }
}
