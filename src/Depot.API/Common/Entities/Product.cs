
using Depot.API.Common.Enums;

namespace Depot.API.Common.Entities;

public sealed class Product(DateTime createdAt, DateTime? updatedAt, string name, string description, 
    Guid sectorId, EProductType productType) : BaseNamedEntity(createdAt, updatedAt, name, description)
{
    public EProductType ProductType { get; private set; } = productType;
    public Guid SectorId { get; private set; } = sectorId;
    public Sector Sector { get; private set; } = null!;

    public void ChangeType(EProductType productType)
        => ProductType = productType;

    public void ChangeSector(Guid sectorId) 
        => SectorId = sectorId;
}
