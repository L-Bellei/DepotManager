namespace Depot.API.Features.Registrations.Requests;

public sealed record EmployeeRequest
(
    string Name, 
    Guid SectorId, 
    int Age, 
    DateTime DateOfBirth
);