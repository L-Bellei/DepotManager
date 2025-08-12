using Depot.API.Common.Entities;
using Depot.API.Common.Interfaces.Repositories;
using Depot.API.Data;

namespace Depot.API.Common.Repositories;

public sealed class EmployeeRepository(DepotContext context) : BaseRepository<DepotContext, Employee>(context), IEmployeeRepository
{
}
