using DomainDrivenDesign.Domain.Abstractions;
using DomainDrivenDesign.Domain.Products;
using DomainDrivenDesign.Domain.Shared;

namespace DomainDrivenDesign.Domain.Categories
{
    /// <summary>
    /// Represents a category within the domain.
    /// </summary>
    /// <remarks>
    /// A <see cref="Category"/> serves as a classification for products, enabling organization and management within the system.
    /// </remarks>
    public sealed class Category : Entity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Category"/> class with the specified identifier.
        /// </summary>
        /// <param name="id">The unique identifier for the category.</param>
        private Category(Guid id) : base(id)
        {
            // Private constructor to enforce the use of public constructors for object creation.
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Category"/> class with the specified identifier and name.
        /// </summary>
        /// <param name="id">The unique identifier for the category.</param>
        /// <param name="name">The name of the category.</param>
        public Category(Guid id, Name name) : base(id)
        {
            Name = name;
            Products = new List<Product>();
        }

        /// <summary>
        /// Gets the name of the category.
        /// </summary>
        public Name Name { get; private set; }

        /// <summary>
        /// Gets the collection of products associated with the category.
        /// </summary>
        public ICollection<Product> Products { get; private set; }

        /// <summary>
        /// Changes the name of the category.
        /// </summary>
        /// <param name="name">The new name for the category.</param>
        public void ChangeName(string name)
        {
            Name = new(name);
        }
    }
}