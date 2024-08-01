using Microsoft.EntityFrameworkCore;
using ReStore.Domain.Entities;
using ReStore.Domain.InterfacesRepository;
using ReStore.Infra.Data.Context;

namespace ReStore.Infra.Data.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly StoreContext _storeContext;

    public ProductRepository(StoreContext storeContext)
    {
        _storeContext = storeContext;
    }

    public async Task<Product?> GetProduct(Int32 id, CancellationToken cancellation)
    {
        return await _storeContext.Products.FindAsync(id, cancellation);
    }

    public async Task<List<Product>> GetProductsAsync(CancellationToken cancellation = default)
    {
        return await _storeContext.Products.ToListAsync(cancellation);
    }
}
