using Microsoft.EntityFrameworkCore;
using ReStore.Domain.Entities;
using ReStore.Domain.InterfacesRepository;
using ReStore.Infra.Data.Context;

namespace ReStore.Infra.Data.Repositories;
public class BasketRepository : IBasketRepository
{
    private readonly StoreContext _storeContext;

    public BasketRepository(StoreContext storeContext)
    {
        _storeContext = storeContext;
    }

    public async Task<Basket?> GetBasketAsync(String? buyerId, CancellationToken cancellation)
    {
        return await _storeContext.Baskets
            .Include(i => i.Items)
            .ThenInclude(p => p.Product)
            .FirstOrDefaultAsync(x => x.BuyerId == buyerId, cancellationToken: cancellation);
    }

    public async Task<Basket?> InsertBasketAsync(Basket basket, CancellationToken cancellation)
    {
        try
        {
            _storeContext.Add(basket);
            await _storeContext.SaveChangesAsync(cancellation);
            return basket;
        }
        catch (Exception)
        {
            return null;
        }
    }

    public async Task<Basket?> UpdateBasketAsync(Basket basket, CancellationToken cancellation)
    {
        try
        {
            _storeContext.Update(basket);
            await _storeContext.SaveChangesAsync(cancellation);
            return basket;
        }
        catch (Exception)
        {
            return null;
        }
    }
}
