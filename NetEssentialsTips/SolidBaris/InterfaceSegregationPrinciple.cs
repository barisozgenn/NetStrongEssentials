namespace SolidBaris.InterfaceSegregationPrinciple;
//ISP:Interface Segregation Principle: Code should not be forced to depend on methods it doesn't use, promoting a clear and concise interface.
// Interfaces are focused and not overloaded
interface IWorker
{
    void Work();
}
class Robot : IWorker
{
    public void Work() { /* working logic */ }
}


