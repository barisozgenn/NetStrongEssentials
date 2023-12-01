namespace SolidBaris.DependencyInversionPrinciple;
//DIP:Dependency Inversion Principle: High-level modules should not depend on low-level modules; both should depend on abstractions, promoting a flexible and decoupled architecture.
// Good: High-level modules depend on abstractions
class LightBulb
{
    public void TurnOn() { /* turn on logic */ }
}
class Switch
{
    private readonly LightBulb _bulb;
    public Switch(LightBulb bulb)
    {
        _bulb = bulb;
    }
    public void Toggle()
    {
        if (true/* some condition */)
            _bulb.TurnOn();
    }
}
