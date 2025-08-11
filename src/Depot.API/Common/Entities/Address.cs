
namespace Depot.API.Common.Entities;

public sealed class Address(DateTime createdAt, DateTime? updatedAt, string street, int number, string city, 
    string region, string postalCode, string country, string phone) : BaseEntity(createdAt, updatedAt)
{
    public string Street { get; private set; } = street;
    public int Number { get; private set; } = number;
    public string City { get; private set; } = city;
    public string Region { get; private set; } = region;
    public string PostalCode { get; private set; } = postalCode;
    public string Country { get; private set; } = country;
    public string Phone { get; private set; } = phone;
    public Enterprise Enterprise { get; private set; } = null!;

    public void ChangeAddressInfo(string? street = null, int? number = null, string? city = null, 
        string? region = null, string? postalCode = null, string? country = null, string? phone = null)
    {
        Street = street ?? Street;
        Number = number ?? Number;
        City = city ?? City;
        Region = region ?? Region;
        PostalCode = postalCode ?? PostalCode;
        Country = country ?? Country;
        Phone = phone ?? Phone;
    }
}
