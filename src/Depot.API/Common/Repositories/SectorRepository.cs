using Depot.API.Common.Entities;
using Depot.API.Common.Interfaces.Repositories;
using Depot.API.Data;

namespace Depot.API.Common.Repositories;

public sealed class SectorRepository(DepotContext context) : BaseRepository<DepotContext, Sector>(context), ISectorRepository
{
}
