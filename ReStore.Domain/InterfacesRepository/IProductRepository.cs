using ReStore.Domain.Entities;

namespace ReStore.Domain.InterfacesRepository;
public interface IProductRepository
{
    Task<List<Product>> GetProductsAsync(String orderBy, String searchTerm, CancellationToken cancellation);
    Task<Product?> GetProduct(Int32 id, CancellationToken cancellation);
}
