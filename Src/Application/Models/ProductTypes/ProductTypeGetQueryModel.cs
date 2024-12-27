using Application.Common.Mapping;
using Application.Features.Common;
using Domain.Entities;

namespace Application.Models.ProductTypes;

public class ProductTypeGetQueryModel : CommandQueryModel, IMapFrom<ProductType>
{
    public long Id { get; set; }
    public string Title { get; set; }
    public bool IsDeleted { get; set; }
}
