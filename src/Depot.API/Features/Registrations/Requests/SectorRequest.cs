namespace Depot.API.Features.Registrations.Requests;

public sealed record SectorRequest
(
    string Name, 
    string Description, 
    Guid? ResponsibleEmployee = null
);
