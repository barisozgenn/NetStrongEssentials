namespace DomainDrivenDesign.Domain.Users;

public sealed record Email
{
    public string Value { get; init; }
    public Email(string value)
    {

        if (string.IsNullOrEmpty(value))
        {
            throw new ArgumentException("Email can not be empty!");
        }
        if (!value.Contains("@") || !value.Contains("."))
        {
            throw new ArgumentException("Email format is not correct!");
        }

        Value = value;
    }
}
