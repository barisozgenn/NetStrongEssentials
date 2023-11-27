using Microsoft.EntityFrameworkCore;

namespace RedisExampleBaris.API.Models
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //Seed
            modelBuilder.Entity<Product>().HasData(
                new Product()
                {
                    Id = 1,
                    Name = "Pencil Baris 1"
                },
                new Product()
                {
                    Id = 2,
                    Name = "Pencil Baris 1"

                },
                new Product()
                {
                    Id = 3,
                    Name = "Pencil Baris 1"

                });










            base.OnModelCreating(modelBuilder);
        }

    }
}
