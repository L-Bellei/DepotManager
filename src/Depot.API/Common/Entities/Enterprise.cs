namespace Depot.API.Common.Entities;

public sealed class Enterprise(DateTime createdAt, DateTime? updatedAt, string name, string description, Guid addressId) :
    BaseNamedEntity(createdAt, updatedAt, name, description)
{
    public Guid AddressId { get; set; } = addressId;
    public Address Address { get; private set; } = null!;
    public ICollection<Sector> Sectors { get; } = [];
    public void ChangeAddress(Guid addressId)
        => AddressId = addressId;
}

