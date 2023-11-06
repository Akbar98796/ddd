namespace Catalog.Domain.AggregatesModel.ProductAggregate;

public record ProductId(Guid Value): IStrongestId;
