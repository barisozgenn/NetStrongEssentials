namespace SolidBaris.SingleResponsibilityPrinciple;
//SRP:Single Responsibility: Components should have only one responsibility or functionality.
//Each class has a single responsibility
class OrderProcessor
{
    public void ProcessOrder(Order order) { /* processing logic */ }
}
class EmailSender
{
    public void SendEmail(string to, string message) { /* email sending logic */ }
}
class Order{
    public string Id {get;set;}
}