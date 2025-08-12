using Depot.API.Common.Entities;
using Depot.API.Common.Interfaces.Repositories;
using Depot.API.Data;

namespace Depot.API.Common.Repositories;

public sealed class AddressRepository(DepotContext context) : BaseRepository<DepotContext, Address>(context), IAddressRepository
{
}