using MediatR;
using System;

namespace DomainDrivenDesign.Domain.Abstractions
{
    /// <summary>
    /// Represents the base entity with a unique identifier.
    /// </summary>
    /// <remarks>
    /// This abstract class serves as a base for all domain entities, ensuring each has a unique <see cref="Id"/>.
    /// Implements <see cref="IEquatable{T}"/> to provide a standardized way of comparing entities based on their identifiers.
    /// </remarks>
    public abstract class Entity : IEquatable<Entity>
    {
        /// <summary>
        /// Gets the unique identifier for the entity.
        /// </summary>
        /// <remarks>
        /// The 'init' accessor ensures that the <see cref="Id"/> can only be set during object initialization, promoting immutability.
        /// </remarks>
        public Guid Id { get; init; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Entity"/> class with the specified identifier.
        /// </summary>
        /// <param name="id">The unique identifier for the entity.</param>
        protected Entity(Guid id)
        {
            Id = id;
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current entity based on their unique identifiers.
        /// </summary>
        /// <param name="obj">The object to compare with the current entity.</param>
        /// <returns><c>true</c> if the specified object is equal to the current entity; otherwise, <c>false</c>.</returns>
        public override bool Equals(object? obj)
        {
            if (obj is null || GetType() != obj.GetType())
            {
                return false;
            }

            return obj is Entity entity && entity.Id == Id;
        }

        /// <summary>
        /// Returns a hash code for the current entity based on its unique identifier.
        /// </summary>
        /// <returns>A hash code for the current entity.</returns>
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        /// <summary>
        /// Determines whether the specified <see cref="Entity"/> is equal to the current entity based on their unique identifiers.
        /// </summary>
        /// <param name="other">The entity to compare with the current entity.</param>
        /// <returns><c>true</c> if the specified entity is equal to the current entity; otherwise, <c>false</c>.</returns>
        public bool Equals(Entity? other)
        {
            if (other is null || GetType() != other.GetType())
            {
                return false;
            }

            return other.Id == Id;
        }
    }
}