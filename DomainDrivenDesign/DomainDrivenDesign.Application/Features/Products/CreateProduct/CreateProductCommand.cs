using MediatR;

namespace DomainDrivenDesign.Application.Features.Products.CreateProduct;
//NOTE: We defined here parameter which are required in Domain layer model

public sealed record CreateProductCommand(
    string Name, 
    int Quantity, 
    decimal Amount, 
    string Currency,
    Guid CategoryId) : IRequest;
