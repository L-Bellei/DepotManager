namespace Depot.API.Features.Registrations.Responses;

public sealed record ProductResponse
(
    Guid Id,
    string Name,
    string Description,
    Guid SectorId,
    string ProductType,
    double Price,
    int Quantity,
    bool Active,
    bool HasValidationDate,
    SectorResponse Sector
);