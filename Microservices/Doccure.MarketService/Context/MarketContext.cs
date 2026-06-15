using Doccure.MarketService.Entities;
using Microsoft.EntityFrameworkCore;

namespace Doccure.MarketService.Context
{
    public class MarketContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-R7AR1ND;initial catalog=DoccureMarketDb;integrated security=true");
        }
        public DbSet<Product> Products { get; set; }
    }
}
