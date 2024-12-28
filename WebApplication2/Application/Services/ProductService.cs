using AutoMapper;
using WebApplication2.Application.DTOs;
using WebApplication2.Application.Interface;
using WebApplication2.Domain.InterFaces;
using WebApplication2.Domain.Models;

namespace WebApplication2.Application.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;
    

    public ProductService( IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    
    public async Task<IEnumerable<ProductDto>> GetProductsAsync()
    {
        var product = await _productRepository
            .GetAllProductsAsync();
      return  _mapper.Map<IEnumerable<ProductDto>>(product);
    }

    public async Task<ProductDto> GetProductByIdAsync(int id)
    {
        var productbyid = await _productRepository
            .GetProductByIdAsync(id);
        return _mapper.Map<ProductDto>(productbyid);
    }

    public async Task AddProductAsync(Product product)
    {
       await _productRepository.AddProductAsync(product);
    }

    public async Task UpdateProductAsync(Product product)
    {
        await _productRepository.UpdateProductAsync(product);
    }

    public async Task DeleteProductAsync(int id)
    {
        await _productRepository.DeleteProductAsync(id);
    }
}