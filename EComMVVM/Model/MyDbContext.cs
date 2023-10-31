using Microsoft.EntityFrameworkCore;

namespace EComMVVM.Model
{
    public class MyDbContext : DbContext
    {

        public DbSet<Product> Products { get; set; }
        public DbSet<Panier> Paniers { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("Mydb");
        }

    }
}
