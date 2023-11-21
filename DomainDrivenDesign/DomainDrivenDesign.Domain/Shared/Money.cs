namespace DomainDrivenDesign.Domain.Shared;
//NOTE: sealed class: prevents this class from being inherited into another class.
public sealed record Money(decimal Amount, Currency Currency)
{
    // Define an operator overload for addition.
    // This operator allows you to use the '+' symbol to add two Money instances.
    public static Money operator +(Money a, Money b)
    {
        // Check if currencies match before performing addition.
        if (a.Currency != b.Currency)
        {
            throw new ArgumentException("Cannot add values with different currencies!");
        }
        // Create and return a new Money instance with the sum of amounts and the currency.
        // This operator allows you to use the '+' symbol to add two Money instances.
        // Example: Money result = money1 + money2;
        return new(a.Amount + b.Amount, a.Currency);
    }
    // Factory method to create a Money instance with zero amount and no specific currency.
    public static Money Zero() => new(0, Currency.None);
    // Factory method to create a Money instance with zero amount and a specified currency.
    public static Money Zero(Currency currency) => new(0, currency);
    // Check if the current Money instance represents zero amount.
    public bool IsZero() => this == Zero(Currency);
}


