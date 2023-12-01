namespace SolidBaris.LiskovSubstitutionPrinciple;
//LSP:Liskov Substitution Principle: Substitutable components or services should seamlessly replace each other without issues.
// Subtypes can substitute base types
class Bird
{
    public virtual void Fly() { /* flying logic */ }
}
class Penguin : Bird
{
    public override void Fly() { /* penguins can't fly, but still override */ }
}
