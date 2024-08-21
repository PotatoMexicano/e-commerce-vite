using ReStore.Domain.Entities;

namespace ReStore.Domain.InterfacesRepository;
public interface IBasketRepository
{
    Task<Basket> GetBasketAsync(String buyerId, CancellationToken cancellation);
    Task<Basket> InsertBasketAsync(Basket basket, CancellationToken cancellation);
    Task<Basket> UpdateBasketAsync(Basket basket, CancellationToken cancellation);
}
