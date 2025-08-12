namespace Depot.API.Features.Registrations.Responses;

public sealed record EmployeeResponse
(
    Guid Id,
    string Name, 
    Guid SectorId, 
    int Age, 
    DateTime DateOfBirth,
    SectorResponse Sector
);