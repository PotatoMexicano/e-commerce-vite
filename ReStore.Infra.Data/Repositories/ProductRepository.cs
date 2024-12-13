using Microsoft.EntityFrameworkCore;
using ReStore.Domain.Entities;
using ReStore.Domain.Extensions;
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

    public async Task<List<Product>> GetProductsAsync(String orderBy, String searchTerm, CancellationToken cancellation = default)
    {
        IQueryable<Product> query = _storeContext.Products
            .Sort(orderBy)
            .Search(searchTerm)
            .AsQueryable();

        return await query.ToListAsync(cancellation);

    }
}
