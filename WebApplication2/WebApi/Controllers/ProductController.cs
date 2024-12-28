using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using WebApplication2.Application.Interface;
using WebApplication2.Domain.InterFaces;
using WebApplication2.Domain.Models;

namespace WebApplication2.WebApi.Controllers;

[ApiController]
[Route("Api/Product")]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController( IProductService productService )
    {
        _productService = productService;
    }

    #region Get : Api/Product
    [HttpGet]
    public async Task<ActionResult> GetProducts()
    {
        var Product = await _productService
            .GetProductsAsync();
        if (Product == null)
        {
            return NotFound(nameof(Product));
        }
        return Ok(Product);

    }
    #endregion
    
    

    #region Get: Api/Product/Id
    [HttpGet("{id}")]
    public async Task<ActionResult> GetProductById(int id)
    {
       var ProductById = await _productService.GetProductByIdAsync(id);
       if (ProductById == null)
       {
           return NotFound(nameof(ProductById));
       }
       return Ok(ProductById);
       
    }
    #endregion
    
    

    #region Post : Api/Product
    [HttpPost]
    public async Task<ActionResult> AddProduct([FromBody] Product product)
    {
        if (product == null)
        {
            return BadRequest("product is null");
        }
        await _productService.AddProductAsync(product);
        return CreatedAtAction(nameof(GetProductById), new
        {
            id = product.ProductId
        }, product);
    }
    #endregion
    
    

    #region PUT: api/product/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProduct(int id, [FromBody] Product product)
    {
        if (id != product.ProductId)
        {
            return BadRequest("Product ID mismatch.");
        }

        var existingProduct = await _productService.GetProductByIdAsync(id);
        if (existingProduct == null)
        {
            return NotFound();
        }

        await _productService.UpdateProductAsync(product);
        return NoContent();
    }
    #endregion
    
    
    
    #region DELETE: api/product/{id}
   
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        var existingProduct = await _productService.GetProductByIdAsync(id);
        if (existingProduct == null)
        {
            return NotFound();
        }

        await _productService.DeleteProductAsync(id);
        return NoContent();
    }
    #endregion
}

    
