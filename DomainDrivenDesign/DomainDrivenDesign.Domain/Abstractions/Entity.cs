namespace DomainDrivenDesign.Domain.Abstractions;

//NOTE: abstract class: An abstract class can only be inherited by another classes, providing a template for shared methods and properties.
public abstract class Entity : IEquatable<Entity>
{
    //NOTE: We used 'init' to ensure that it cannot be modified after acquisition; Only single time it is filled.
    public Guid Id { get; init; }
    public Entity(Guid id)
    {
        Id = id;
    }
    //NOTE: Determines whether the specified object is equal to the current entity also by their guid ID, its using suggested by DDD
    // it is like unboxing and converts objects to type and it is a bit lower than IEquatable.Equals method.
    public override bool Equals(object? obj)
    {
        if(obj is null)
        {
            return false;
        }

        if(obj is not Entity entity)
        {
            return false;
        }

        if(obj.GetType() != GetType())
        {
            return false;
        }

        return entity.Id == Id;
    }

    //NOTE: it works for hash set lists and determines whether the specified list is equal to the current entity also by their guid ID, its using suggested by DDD
    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
    //NOTE: It comes from IEquatable<Entity> , compare objects without unboxing
    public bool Equals(Entity? other)
    {
        if (other is null)
        {
            return false;
        }

        if (other is not Entity entity)
        {
            return false;
        }

        if (other.GetType() != GetType())
        {
            return false;
        }

        return entity.Id == Id;
    }
}