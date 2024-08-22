using Microsoft.AspNetCore.Mvc;
using ReStore.Application.Services;
using ReStore.Domain.DTOs;
using ReStore.Domain.Entities;

namespace ReStore.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BasketController : BaseApiController
{
    private readonly IBasketService _basketService;
    private readonly IProductService _productService;

    public BasketController(IBasketService basketService, IProductService productService)
    {
        _basketService = basketService;
        _productService = productService;
    }

    [HttpGet(Name = "GetBasket")]
    public async Task<ActionResult<BasketDTO>> GetBasket(CancellationToken cancellation = default)
    {
        String? buyerId = Request.Cookies["buyerId"];

        if (buyerId == null) return NotFound();

        Basket? basket = await _basketService.GetBasket(buyerId, cancellation);

        if (basket == null) return NotFound();

        return basket.MapBasketToDTO();
    }

    [HttpPost]
    public async Task<ActionResult<BasketDTO>> AddItemToBasket(Int32 productId, Int32 quantity, CancellationToken cancellation = default)
    {
        String? buyerId = Request.Cookies["buyerId"];

        Basket? basket = await _basketService.GetBasket(buyerId, cancellation);

        if (basket == null)
        {
            buyerId = Guid.NewGuid().ToString();
            CookieOptions cookieOptions = new CookieOptions { IsEssential = true, Expires = DateTime.Now.AddDays(30) };
            Response.Cookies.Append("buyerId", buyerId, cookieOptions);
            basket = await _basketService.InsertBasket(new Basket { BuyerId = buyerId, }, cancellation);
        }

        Product? product = await _productService.GetProduct(productId, cancellation);

        if (product == null) return NotFound();
        if (basket == null) return BadRequest();

        basket.AddItem(product, quantity);

        Basket? result = await _basketService.UpdateBasket(basket, cancellation);

        if (result != null) return CreatedAtRoute("GetBasket", basket.MapBasketToDTO());

        return BadRequest(new ProblemDetails { Title = "Problem saving item to basket" });
    }

    [HttpDelete]
    public async Task<ActionResult> RemoveBasketItem(Int32 productId, Int32 quantity, CancellationToken cancellation = default)
    {
        String? buyerId = Request.Cookies["buyerId"];

        Basket? basket = await _basketService.GetBasket(buyerId, cancellation);

        if (basket == null) return NotFound();

        basket.RemoveItem(productId, quantity);

        basket = await _basketService.UpdateBasket(basket, cancellation);

        if (basket != null) return Ok();

        return BadRequest(new ProblemDetails { Title = "Problem removing item from the basket" });

    }


}
