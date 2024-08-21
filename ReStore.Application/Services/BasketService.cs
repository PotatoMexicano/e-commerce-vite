using ReStore.Domain.Entities;
using ReStore.Domain.InterfacesRepository;

namespace ReStore.Application.Services;

public interface IBasketService
{
    Task<Basket?> GetBasket(String? buyerId, CancellationToken cancellation);
    Task<Basket?> InsertBasket(Basket basket, CancellationToken cancellation);
    Task<Basket?> UpdateBasket(Basket basket, CancellationToken cancellation);
}

public class BasketService : IBasketService
{
    private readonly IBasketRepository _repository;

    public BasketService(IBasketRepository repository)
    {
        _repository = repository;
    }

    public async Task<Basket?> GetBasket(String? buyerId, CancellationToken cancellation)
    {
        return await _repository.GetBasketAsync(buyerId, cancellation);
    }

    public async Task<Basket?> InsertBasket(Basket basket, CancellationToken cancellation)
    {
        return await _repository.InsertBasketAsync(basket, cancellation);
    }

    public async Task<Basket?> UpdateBasket(Basket basket, CancellationToken cancellation)
    {
        return await _repository.UpdateBasketAsync(basket, cancellation);
    }
}
