using Application.Common.Mapping;
using Application.Features.Common;
using Domain.Entities;

namespace Application.Models.ProductBrands;

public class ProductBrandGetQueryModel : CommandQueryModel, IMapFrom<ProductBrand>
{
    public string Title { get; set; }
}
