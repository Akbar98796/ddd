namespace Services.Common.Domain.Primitives;

public abstract class Entity<StrongestId> : IEntity<StrongestId> 
    where StrongestId : IStrongestId
{
    public virtual StrongestId Id { get; protected set; }

    protected Entity() {}

    protected Entity(StrongestId id) =>
        Id = id;


    public static bool operator ==(Entity<StrongestId>? left, Entity<StrongestId>? right) =>
        left != null && left.Equals(right);

    public static bool operator !=(Entity<StrongestId>? left, Entity<StrongestId>? right) =>
        !(left == right);

    public override bool Equals(object? obj)
    {
        if(obj == null)
        {
            return false;
        }

        if(obj.GetType() != GetType())
        {
            return false;
        }

        if(obj is not Entity<StrongestId> entity)
        {
            return false;
        }

        return entity.Id.Value == Id.Value;
    }

    public override int GetHashCode() =>
        Id.GetHashCode();
}

public abstract class Entity : IEntity
{
    public virtual Guid Id { get; protected set; }

    protected Entity() { }

    protected Entity(Guid id) =>
        Id = id;


    public static bool operator ==(Entity? left, Entity? right) =>
        left != null && left.Equals(right);

    public static bool operator !=(Entity? left, Entity? right) =>
        !(left == right);

    public override bool Equals(object? obj)
    {
        if (obj == null)
        {
            return false;
        }

        if (obj.GetType() != GetType())
        {
            return false;
        }

        if (obj is not Entity entity)
        {
            return false;
        }

        return entity.Id == Id;
    }

    public override int GetHashCode() =>
        Id.GetHashCode();
}
