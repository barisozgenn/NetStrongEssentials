﻿using DomainDrivenDesign.Domain.Abstractions;
using DomainDrivenDesign.Domain.Categories;
using DomainDrivenDesign.Domain.Shared;

namespace DomainDrivenDesign.Domain.Products;
//NOTE: sealed class: prevents this class from being inherited into another class.
public sealed class Product : Entity
{
    private Product(Guid id) : base(id)
    {
    }
    public Product(Guid id, Name name, int quantity, Money price, Guid categoryId) : base(id)
    {
        Name = name;
        Quantity = quantity;
        Price = price;
        CategoryId = categoryId;
    }

    public Name Name { get; private set; }
    public int Quantity { get; private set; }
    public Money Price { get; private set; }
    public Guid CategoryId { get; private set; }
    public Category Category { get; private set; }

    public void Update(string name, int quantity, decimal amount, string currency, Guid categoryId)
    {
        Name = new(name);
        Quantity = quantity;
        Price = new(amount, Currency.FromCode(currency));
        CategoryId = categoryId;
    }
}
