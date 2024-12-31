using DomainDrivenDesign.Domain.Categories;
using MediatR;

namespace DomainDrivenDesign.Application.Features.Categories.GetAllCategory;
/// <summary>
/// Query to retrieve all categories.
/// </summary>
public sealed record GetAllCategoryQuery(): IRequest<List<Category>>;

