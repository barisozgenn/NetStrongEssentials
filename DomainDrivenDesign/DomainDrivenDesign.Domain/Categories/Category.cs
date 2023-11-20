using DomainDrivenDesign.Domain.Abstractions;
using DomainDrivenDesign.Domain.Products;
using DomainDrivenDesign.Domain.Shared;

namespace DomainDrivenDesign.Domain.Categories;
//NOTE: sealed class: prevents this class from being inherited into another class.
public sealed class Category : Entity
{
    private Category(Guid id) : base(id)
    {

    }
    public Category(Guid id, Name name): base(id)
    {
        Name = name;
    }

    public Name Name { get; private set; }
    public ICollection<Product> Products { get; private set; }

    public void ChangeName(string name)
    {
        Name = new(name);
    }
}
