
namespace IoCBaris;

public class IoCManualExample
{
    public IoCManualExample()
    {
        IServiceCollection services = new ServiceCollection(); // Creating a collection to register services
        //NOT: first Type of the service, second is Instance of this type
        //They are adding Singleton in Default settings of Net
        services.Add(new ServiceDescriptor(typeof(ILog), new ConsoleLog(4))); // Registering ConsoleLog as a service
        services.AddSingleton(new ServiceDescriptor(typeof(ConsoleLog), new ConsoleLog(4))); //or like this
        services.Add(new ServiceDescriptor(typeof(TextLog), new TextLog(),
                            ServiceLifetime.Singleton)); // or like this

        ServiceProvider provider = services.BuildServiceProvider(); // Building a concrete service provider/container
        //We added them as  services and now getting them
        provider.GetService<ConsoleLog>(); // Resolving and retrieving an instance of ConsoleLog from the service provider
        provider.GetService<TextLog>(); // Resolving and retrieving an instance of TextLog from the service provider
    }
}
