namespace DomainDrivenDesign.Domain.Users;

public sealed record Password
{
    public string Value { get; init;  }
    public Password(string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            throw new ArgumentException("Password can not be null!");
        }

        if (value.Length < 6)
        {
            throw new ArgumentException("Password should be at least 6 characters!");
        }

        Value = value;
    }
}
