using DomainDrivenDesign.Domain.Abstractions;
using DomainDrivenDesign.Domain.Users;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace DomainDrivenDesign.Application
{
    /// <summary>
    /// Provides extension methods for configuring application-specific services.
    /// </summary>
    /// <remarks>
    /// This static class extends the <see cref="IServiceCollection"/> interface,
    /// enabling fluent syntax when configuring services within the application.
    /// </remarks>
    public static class DependencyInjection
    {
        /// <summary>
        /// Adds application-specific services to the provided <see cref="IServiceCollection"/>.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to which services will be added.</param>
        /// <returns>The updated <see cref="IServiceCollection"/> with application services registered.</returns>
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            // Configure MediatR for handling requests and notifications within the application.
            services.AddMediatR(config =>
            {
                // Register all MediatR handlers from the executing assembly and the assembly containing the Entity class.
                config.RegisterServicesFromAssemblies(
                    Assembly.GetExecutingAssembly(), // Registers handlers from the current application assembly.
                    typeof(Entity).Assembly);        // Registers handlers from the Domain.Abstractions assembly.
            });

            // Return the modified IServiceCollection to support method chaining.
            return services;
        }
    }
}
