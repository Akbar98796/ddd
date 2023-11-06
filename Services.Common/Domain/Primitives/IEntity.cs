namespace Services.Common.Domain.Primitives;

public interface IEntity
{
    public Guid Id { get; }
}

public interface IEntity<StrongestId>
    where StrongestId : IStrongestId
{
    public StrongestId Id { get; }
}