using DomainDrivenDesign.Domain.Abstractions;
using DomainDrivenDesign.Domain.Users;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace DomainDrivenDesign.Application;// This static class extends the IServiceCollection interface, allowing for fluent syntax when configuring services.
// NOTE: This static class extends the IServiceCollection interface, allowing for fluent syntax when configuring services.
public static class DependencyInjection
{
    // Extension method to add application-specific services to the IServiceCollection.
    public static IServiceCollection AddApplication(
        this IServiceCollection services)
    {
        // Use MediatR to register Mediator and handlers.
        services.AddMediatR(cfr =>
        {
            // Register services from the executing assembly (typically the application assembly)
            // and the assembly containing the Entity class.
            cfr.RegisterServicesFromAssemblies(
                Assembly.GetExecutingAssembly(), // Register services from the application assembly.
                typeof(Entity).Assembly);        // Register services from the assembly containing the Entity class.
        });

        // Return the modified IServiceCollection to support method chaining.
        return services;
    }
}

