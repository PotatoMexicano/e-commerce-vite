using Microsoft.AspNetCore.Mvc;
using ReStore.Application.Services;
using ReStore.Domain.Entities;

namespace ReStore.API.Controllers;

public class ProductsController : BaseApiController
{

    private readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<ActionResult<List<Product>>> GetProducts(CancellationToken cancellation = default)
    {
        List<Product> products = await _productService.GetProducts(cancellation);

        return Ok(products);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Product?>> GetProduct(Int32 id, CancellationToken cancellation = default)
    {
        Product? product = await _productService.GetProduct(id, cancellation);

        return product is null ? (ActionResult<Product?>)NotFound() : (ActionResult<Product?>)product;
    }
}
