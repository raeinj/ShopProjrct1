using AutoMapper;
using WebApplication2.Application.DTOs;
using WebApplication2.Domain.Models;

namespace WebApplication2.Domain.ProfileMapper;

public class Factory : Profile
{
    public Factory()
    {
        CreateMap(typeof(Product), typeof(ProductDto));
        CreateMap(typeof(ProductDto), typeof(Product));
    }
}