namespace Depot.API.Features.Registrations.Responses;

public sealed record AddressResponse
(
    Guid Id,
    string Street, 
    int Number, 
    string City,
    string Region, 
    string PostalCode, 
    string Country, 
    string Phone
);
