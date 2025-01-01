using DomainDrivenDesign.Domain.Abstractions;
using DomainDrivenDesign.Domain.Categories;
using DomainDrivenDesign.Domain.Orders;
using DomainDrivenDesign.Domain.Products;
using DomainDrivenDesign.Domain.Users;
using DomainDrivenDesign.Infrastructure.Context;
using DomainDrivenDesign.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace DomainDrivenDesign.Infrastructure
{
    /// <summary>
    /// Provides extension methods for registering Infrastructure services.
    /// </summary>
    /// <remarks>
    /// Contains methods to register repositories, database contexts, and other infrastructure-related services with the dependency injection container.
    /// </remarks>
    public static class DependencyInjection
    {
        /// <summary>
        /// Registers Infrastructure layer services with the specified <see cref="IServiceCollection"/>.
        /// </summary>
        /// <param name="services">The service collection to which services will be added.</param>
        /// <returns>The updated <see cref="IServiceCollection"/>.</returns>
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            // Register ApplicationDbContext with scoped lifetime.
            // Scoped lifetime ensures a single instance per request.
            services.AddScoped<ApplicationDbContext>();

            // Register IUnitOfWork to resolve to ApplicationDbContext.
            // This allows the use of IUnitOfWork abstraction across the application.
            services.AddScoped<IUnitOfWork>(provider => provider.GetRequiredService<ApplicationDbContext>());

            // Register repositories with scoped lifetime.
            // Scoped lifetime ensures a single instance per request, preventing issues with multiple instances.
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();

            return services;
        }
    }
}