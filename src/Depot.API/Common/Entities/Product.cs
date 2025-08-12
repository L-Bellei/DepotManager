
using Depot.API.Common.Enums;

namespace Depot.API.Common.Entities;

public sealed class Product(DateTime createdAt, DateTime? updatedAt, string name, string description,
    Guid sectorId, EProductType productType, double price, int quantity, bool active, bool hasValidationDate) 
    : BaseNamedEntity(createdAt, updatedAt, name, description)
{
    public double Price { get; private set; } = price;
    public int Quantity { get; private set; } = quantity;
    public bool Active { get; private set; } = active;
    public bool HasValidationDate { get; private set; } = hasValidationDate;
    public EProductType ProductType { get; private set; } = productType;
    public Guid SectorId { get; private set; } = sectorId;
    public Sector Sector { get; private set; } = null!;

    public void ChangeType(EProductType productType)
        => ProductType = productType;

    public void ChangeSector(Guid sectorId)
        => SectorId = sectorId;
}
