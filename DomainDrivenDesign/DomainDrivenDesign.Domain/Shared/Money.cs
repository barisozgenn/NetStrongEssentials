namespace DomainDrivenDesign.Domain.Shared;
//NOTE: sealed class: prevents this class from being inherited into another class.
public sealed record Money(decimal Amount, Currency Currency)
{
    public static Money operator +(Money a, Money b)
    {
        if (a.Currency != b.Currency){throw new ArgumentException("Cannot add values with different currencies!");}
        return new(a.Amount + b.Amount, a.Currency);
    }
    public static Money Zero() => new(0, Currency.None);
    public static Money Zero(Currency currency) => new(0, currency);
    public bool IsZero() => this == Zero(Currency);
}

