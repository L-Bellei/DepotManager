using Depot.API.Features.Registrations.Requests;
using Depot.API.Features.Registrations.Responses;

namespace Depot.API.Features.Registrations.Interfaces;

public interface ISectorRegistrationService : IBaseRegistrationService<SectorRequest, SectorResponse>
{
}
