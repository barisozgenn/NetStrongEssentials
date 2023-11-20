﻿using DomainDrivenDesign.Domain.Abstractions;
using DomainDrivenDesign.Domain.Products;
using DomainDrivenDesign.Domain.Shared;

namespace DomainDrivenDesign.Domain.Orders;
//NOTE: sealed class: prevents this class from being inherited into another class.

public sealed class OrderLine : Entity
{
    private OrderLine(Guid id) : base(id)
    {

    }
    public OrderLine(Guid id, Guid orderId, Guid productId, int quantity, Money price) : base(id)
    {
        ProductId = productId;
        Quantity = quantity;
        Price = price;
    }

    public Guid OrderId { get; private set; }
    public Guid ProductId { get; private set; } 
    public Product Product { get; private set; }
    public int Quantity { get; private set; }
    public Money Price { get; private set; }  
}