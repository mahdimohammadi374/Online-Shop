using Application.Common.Mapping;
using Application.Features.Common;
using Domain.Entities;

namespace Application.Models.ProductBrands;

public class ProductBrandGetQueryModel : CommandQueryModel, IMapFrom<ProductBrand>
{
    public long Id { get; set; }
    public string Title { get; set; }
    public bool IsDeleted { get; set; }
}
