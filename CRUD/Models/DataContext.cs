using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace CRUD.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Product> Product { get; set; }
    }
}
