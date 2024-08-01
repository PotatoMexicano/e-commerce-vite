using Microsoft.AspNetCore.Mvc;
using ReStore.Application.Services;
using ReStore.Domain.Entities;

namespace ReStore.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
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
        return await _productService.GetProduct(id, cancellation);
    }
}
