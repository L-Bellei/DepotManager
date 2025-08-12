using Depot.API.Common.Entities;
using Depot.API.Common.Enums;
using Depot.API.Data;

namespace Depot.API.Common.Interfaces.Repositories;

public interface IProductRepository : IBaseRepository<DepotContext, Product>
{
    Task<IEnumerable<Product>> GetByProductTypeAsync(EProductType productType);
}
