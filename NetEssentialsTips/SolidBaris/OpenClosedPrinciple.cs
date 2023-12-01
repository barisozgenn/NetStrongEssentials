namespace SolidBaris.OpenClosedPrinciple;
//OCP:Open-Closed Principle: The system should be designed to allow extension without modifying existing architecture.
//Extensible without modifying existing code
abstract class Shape
{
    public abstract double Area();
}
class Circle : Shape
{
    public double Radius { get; set; }
    public override double Area() => Math.PI * Radius * Radius;
}
class Rectangle : Shape
{
    public double a { get; set; }
    public double b { get; set; }
    public override double Area() => a * b;
}

