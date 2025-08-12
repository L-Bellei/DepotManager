namespace Depot.API.Features.Registrations.Requests;

public sealed record AddressRequest
(
    string Street, 
    int Number, 
    string City,
    string Region, 
    string PostalCode, 
    string Country, 
    string Phone
);
