
namespace Depot.API.Features.Registrations.Responses;

public sealed record EnterpriseResponse
(
    Guid Id,
    string Name, 
    string Description,
    AddressResponse? Address,
    Guid? AddressId
);
