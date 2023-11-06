namespace Catalog.Domain.AggregatesModel.CategoryAggregate;

public record CategoryId(Guid Value) : IStrongestId;
