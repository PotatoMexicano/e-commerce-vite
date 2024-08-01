using ReStore.Domain.Entities;
using ReStore.Domain.InterfacesRepository;

namespace ReStore.Application.Services;
public interface IProductService
{
    Task<List<Product>> GetProducts(CancellationToken cancellation);
    Task<Product?> GetProduct(Int32 id, CancellationToken cancellation);
}

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<Product?> GetProduct(Int32 id, CancellationToken cancellation)
    {
        return await _productRepository.GetProduct(id, cancellation);
    }

    public async Task<List<Product>> GetProducts(CancellationToken cancellation)
    {
        return await _productRepository.GetProductsAsync(cancellation);
    }
}
