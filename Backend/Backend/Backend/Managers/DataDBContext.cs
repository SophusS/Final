using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Managers
{
    public class DataDBContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
    }
}
