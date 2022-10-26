using Microsoft.EntityFrameworkCore;
using ODataWebApi.Models;

namespace ODataWebApi.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options){  }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Product> Products { get; set; }

    }
}
