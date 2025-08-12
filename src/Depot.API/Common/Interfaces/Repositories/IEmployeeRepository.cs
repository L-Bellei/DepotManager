using Depot.API.Common.Entities;
using Depot.API.Data;

namespace Depot.API.Common.Interfaces.Repositories;

public interface IEmployeeRepository  :IBaseRepository<DepotContext, Employee>
{
}
