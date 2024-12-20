using Application.Models.Products;
using AutoMapper;
using Domain.Entities;
using Microsoft.Extensions.Configuration;

namespace Application.Common.Mapping.Resolver;

public class ProductImageUrlResolver : IValueResolver<Product, ProductsGetQueryModel, string>
{
    private readonly IConfiguration _configuration;

    public ProductImageUrlResolver(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string Resolve(Product source, ProductsGetQueryModel destination, string destMember, ResolutionContext context)
    {
        if(!string.IsNullOrEmpty(source.PictureUrl))
            return _configuration["BackendUrl"] + _configuration["ImageLocation:ProductImageLocation"] + source.PictureUrl;
        return null;
    }
}
