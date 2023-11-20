namespace DomainDrivenDesign.Domain.Shared;

//NOTE: sealed class: prevents this class from being inherited into another class.
public sealed record Name
{
    public string Value { get; init; }//NOTE:We used 'init' to ensure that it cannot be modified after the first acquisition in constructor
    public Name(string value)
    {
        if (string.IsNullOrEmpty(value)){throw new ArgumentException("Name cannot be empty!");}
        if (value.Length < 2){throw new ArgumentException("Name cannot be less than 3 characters!");}
        Value = value;
    }
}

