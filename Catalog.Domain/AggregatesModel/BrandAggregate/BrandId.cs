namespace Catalog.Domain.AggregatesModel.BrandAggregate;

public record BrandId(Guid Value) : IStrongestId;