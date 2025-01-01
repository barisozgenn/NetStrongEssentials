using DomainDrivenDesign.Domain.Abstractions;
using DomainDrivenDesign.Domain.Categories;
using DomainDrivenDesign.Domain.Orders;
using DomainDrivenDesign.Domain.Products;
using DomainDrivenDesign.Domain.Shared;
using DomainDrivenDesign.Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace DomainDrivenDesign.Infrastructure.Context
{
    /// <summary>
    /// Represents the application's database context, integrating all domain entities.
    /// Implements <see cref="IUnitOfWork"/> to coordinate transaction commits.
    /// </summary>
    /// <remarks>
    /// Inherits from <see cref="DbContext"/> to leverage Entity Framework Core's ORM capabilities.
    /// Configures entity mappings, relationships, and value conversions.
    /// </remarks>
    internal sealed class ApplicationDbContext : DbContext, IUnitOfWork
    {
        /// <summary>
        /// Configures the database connection and other options.
        /// </summary>
        /// <param name="optionsBuilder">The builder used to configure the context.</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // TODO: Move the connection string to a secure configuration source (e.g., appsettings.json or environment variables).
            optionsBuilder.UseSqlServer("Data Source=USE_YOUR_DATA_SOURCE\\SQLEXPRESS;Initial Catalog=DB_NAME;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

            // Optional: Configure logging for debugging purposes.
            // optionsBuilder.UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()));
        }

        /// <summary>
        /// Gets or sets the <see cref="DbSet{T}"/> for <see cref="User"/> entities.
        /// </summary>
        public DbSet<User> Users { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="DbSet{T}"/> for <see cref="Order"/> entities.
        /// </summary>
        public DbSet<Order> Orders { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="DbSet{T}"/> for <see cref="Product"/> entities.
        /// </summary>
        public DbSet<Product> Products { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="DbSet{T}"/> for <see cref="Category"/> entities.
        /// </summary>
        public DbSet<Category> Categories { get; set; }

        /// <summary>
        /// Configures the entity mappings, relationships, and value conversions.
        /// </summary>
        /// <param name="modelBuilder">The builder used to construct the model for this context.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure User entity properties and owned entities
            modelBuilder.Entity<User>()
                .Property(p => p.Name)
                .HasConversion(
                    name => name.Value,
                    value => new Name(value))
                .HasMaxLength(100); // Example constraint

            modelBuilder.Entity<User>()
               .Property(p => p.Email)
               .HasConversion(
                   email => email.Value,
                   value => new Email(value))
               .HasMaxLength(255); // Example constraint

            modelBuilder.Entity<User>()
               .Property(p => p.Password)
               .HasConversion(
                   password => password.Value,
                   value => new Password(value))
               .HasMaxLength(100); // Example constraint

            modelBuilder.Entity<User>()
                .OwnsOne(p => p.Address, addressBuilder =>
                {
                    addressBuilder.Property(a => a.Country).HasMaxLength(100);
                    addressBuilder.Property(a => a.City).HasMaxLength(100);
                    addressBuilder.Property(a => a.Street).HasMaxLength(200);
                    addressBuilder.Property(a => a.FullAddress).HasMaxLength(500);
                    addressBuilder.Property(a => a.PostalCode).HasMaxLength(20);
                });

            // Configure Category entity properties
            modelBuilder.Entity<Category>()
                .Property(p => p.Name)
                .HasConversion(
                    name => name.Value,
                    value => new Name(value))
                .HasMaxLength(100); // Example constraint

            // Configure Product entity properties and owned entities
            modelBuilder.Entity<Product>()
                .Property(p => p.Name)
                .HasConversion(
                    name => name.Value,
                    value => new Name(value))
                .HasMaxLength(200); // Example constraint

            modelBuilder.Entity<Product>()
                .OwnsOne(p => p.Price, priceBuilder =>
                {
                    priceBuilder
                        .Property(p => p.Currency)
                        .HasConversion(
                            currency => currency.Code,
                            code => Currency.FromCode(code))
                        .HasMaxLength(10); // Example constraint

                    priceBuilder
                        .Property(p => p.Amount)
                        .HasColumnType("money");
                });

            // Configure OrderLine entity owned properties
            modelBuilder.Entity<OrderLine>()
                .OwnsOne(p => p.Price, priceBuilder =>
                {
                    priceBuilder
                        .Property(p => p.Currency)
                        .HasConversion(
                            currency => currency.Code,
                            code => Currency.FromCode(code))
                        .HasMaxLength(10); // Example constraint

                    priceBuilder
                        .Property(p => p.Amount)
                        .HasColumnType("money");
                });

            // Additional configurations can be added here as needed.
        }

        /// <summary>
        /// Saves all changes made in this context to the underlying database.
        /// </summary>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>The number of state entries written to the database.</returns>
        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}