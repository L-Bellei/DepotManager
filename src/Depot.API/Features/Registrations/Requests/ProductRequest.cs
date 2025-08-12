using Depot.API.Common.Enums;

namespace Depot.API.Features.Registrations.Requests;

public sealed record ProductRequest
(
    string Name,
    string Description,
    Guid SectorId,
    EProductType ProductType,
    double Price,
    int Quantity,
    bool Active = true,
    bool HasValidationDate = false
);
