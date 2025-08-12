using AutoMapper;
using Depot.API.Common.Entities;
using Depot.API.Common.Interfaces.Repositories;
using Depot.API.Common.Notifier;
using Depot.API.Features.Registrations.Requests;
using Depot.API.Features.Registrations.Responses;

namespace Depot.API.Features.Registrations.Services;

public sealed class EnterpriseRegistrationService(IEnterpriseRepository repo, INotifier notifier, IMapper mapper, ILogger<EnterpriseRegistrationService> logger) 
    : BaseRegistrationService<IEnterpriseRepository, Enterprise, EnterpriseRequest, EnterpriseResponse>(repo, notifier, mapper, logger)
{
}
