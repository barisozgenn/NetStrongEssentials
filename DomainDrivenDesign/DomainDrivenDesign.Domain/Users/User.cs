using DomainDrivenDesign.Domain.Abstractions;
using DomainDrivenDesign.Domain.Shared;

namespace DomainDrivenDesign.Domain.Users;
public sealed class User : Entity
{
    private User(Guid id) : base(id)
    {

    }
    //NOTE: Here is private and can not be called for DDD/Factories we are using CreateUser factory to have more control and encapsulations.
    private User(Guid id, Name name, Email email, Password password, Address address) : base(id)
    {
        Name = name;
        Email = email;
        Password = password;
        Address = address;
    }

    public Name Name { get; private set; }
    public Email Email { get; private set; }
    public Password Password { get; private set; }
    public Address Address { get; private set; }

    // NOTE: The CreateUser Factory simplifies object creation by encapsulating the details and applying necessary business rules.
    public static User CreateUser(string name, string email, string password, string country, string city, string street, string postalCode, string fullAddress)
    {
        //Business Rules
        User user = new(
            id: Guid.NewGuid(),
            name: new(name),
            email: new(email),
            password: new(password),
            address: new(country, city, street, fullAddress, postalCode));

        return user;
    }

    public void ChangeName(string name)
    {
        Name = new(name);
    }

    public void ChangeAddress(string country, string city,string street, string postalCode, string fullAddress)
    {
        Address = new(country, city, street, fullAddress, postalCode);
    }

    public void ChangeEmail(string email)
    {
        Email = new(email);
    }

    public void ChangePassword(string password)
    {
        Password = new(password);
    }
}

