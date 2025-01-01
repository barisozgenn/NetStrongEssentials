using DomainDrivenDesign.Domain.Abstractions;
using DomainDrivenDesign.Domain.Categories;
using DomainDrivenDesign.Domain.Shared;

namespace DomainDrivenDesign.Domain.Products
{
    /// <summary>
    /// Represents a product within the domain.
    /// </summary>
    /// <remarks>
    /// A <see cref="Product"/> aggregates properties like name, quantity, price, and category association.
    /// Implements the <see cref="Entity"/> base class to inherit the unique identifier.
    /// </remarks>
    public sealed class Product : Entity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Product"/> class with the specified identifier.
        /// </summary>
        /// <param name="id">The unique identifier for the product.</param>
        private Product(Guid id) : base(id)
        {
            // Private constructor to enforce the use of public constructors for object creation.
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Product"/> class with the specified details.
        /// </summary>
        /// <param name="id">The unique identifier for the product.</param>
        /// <param name="name">The name of the product.</param>
        /// <param name="quantity">The quantity of the product available.</param>
        /// <param name="price">The price details of the product.</param>
        /// <param name="categoryId">The unique identifier of the category the product belongs to.</param>
        public Product(Guid id, Name name, int quantity, Money price, Guid categoryId) : base(id)
        {
            Name = name;
            Quantity = quantity;
            Price = price;
            CategoryId = categoryId;
            Category = null!; // To be set by the repository or ORM.
        }

        /// <summary>
        /// Gets the name of the product.
        /// </summary>
        public Name Name { get; private set; }

        /// <summary>
        /// Gets the quantity of the product available.
        /// </summary>
        public int Quantity { get; private set; }

        /// <summary>
        /// Gets the price details of the product.
        /// </summary>
        public Money Price { get; private set; }

        /// <summary>
        /// Gets the unique identifier of the category the product belongs to.
        /// </summary>
        public Guid CategoryId { get; private set; }

        /// <summary>
        /// Gets the category associated with the product.
        /// </summary>
        public Category Category { get; private set; }

        /// <summary>
        /// Updates the product's details with the specified information.
        /// </summary>
        /// <param name="name">The new name for the product.</param>
        /// <param name="quantity">The new quantity available.</param>
        /// <param name="amount">The new price amount.</param>
        /// <param name="currency">The new currency for the price.</param>
        /// <param name="categoryId">The new category identifier.</param>
        public void Update(string name, int quantity, decimal amount, string currency, Guid categoryId)
        {
            Name = new(name);
            Quantity = quantity;
            Price = new(amount, Currency.FromCode(currency));
            CategoryId = categoryId;
        }
    }
}