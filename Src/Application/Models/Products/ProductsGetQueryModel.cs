using Application.Common.Mapping;
using Application.Common.Mapping.Resolver;
using Application.Features.Common;
using AutoMapper;
using Domain.Entities;

namespace Application.Models.Products;

public class ProductsGetQueryModel : CommandQueryModel, IMapFrom<Product>
{
    public long Id { get; set; }
    public string Title { get; set; }
    public decimal Price { get; set; }
    public string PictureUrl { get; set; }
    public bool IsDeleted { get; set; } = false;
    public string ProductBrandTitle { get; set; }
    public string ProductTypeTitle { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Product, ProductsGetQueryModel>()
            .ForMember(x=>x.PictureUrl, c=>c.MapFrom<ProductImageUrlResolver>())
            .ForMember(x=>x.ProductTypeTitle , c=>c.MapFrom(v=>v.ProductType.Title))
            .ForMember(x => x.ProductBrandTitle, c => c.MapFrom(v => v.ProductBrand.Title));
    }
}
