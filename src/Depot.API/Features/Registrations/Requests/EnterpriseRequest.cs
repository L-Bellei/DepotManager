namespace Depot.API.Features.Registrations.Requests;

public sealed record EnterpriseRequest
(
    string Name, 
    string Description,
    AddressRequest? Address,
    Guid? AddressId
);
