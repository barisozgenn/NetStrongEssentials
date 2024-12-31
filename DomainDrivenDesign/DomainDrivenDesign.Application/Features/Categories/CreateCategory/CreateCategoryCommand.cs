using MediatR;

namespace DomainDrivenDesign.Application.Features.Categories.CreateCategory
{
    /// <summary>
    /// Command to create a new category with the specified name.
    /// </summary>
    /// <param name="Name">The name of the category to be created.</param>
    public sealed record CreateCategoryCommand(string Name) : IRequest;
}
