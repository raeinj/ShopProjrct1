using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Domain.InterFaces;
using WebApplication2.Domain.Models;
using WebApplication2.Infrastructure.Context;

namespace WebApplication2.Infrastructure.Repossittories;

public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _context;

    public ProductRepository(AppDbContext context)
    {
        _context = context; 
    }
    
    
    public async Task<IEnumerable<Product>> GetAllProductsAsync()
    {
        return await _context.Products.ToListAsync();
    }

    public async Task<Product> GetProductByIdAsync(int id)
    {
        return await _context.Products.FindAsync(id);
    }

    public async Task AddProductAsync(Product product)
    {
        await _context.Products.AddAsync(product);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateProductAsync(Product product)
    {
       _context.Products.Update(product);
       _context.SaveChangesAsync();
       
    }

    public async Task DeleteProductAsync(int Id)
    {
        var product = _context.Products.FindAsync(Id);
        if (product != null)
        {
            _context.Products.Remove(await product);
            await _context.SaveChangesAsync();
        }
    }
}