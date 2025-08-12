namespace Depot.API.Features.Registrations.Responses;

public sealed record SectorResponse
(
    Guid Id,
    string Name, 
    string Description, 
    Guid? ResponsibleEmployeeId = null,
    EmployeeResponse? ResponsibleEmployee
);
