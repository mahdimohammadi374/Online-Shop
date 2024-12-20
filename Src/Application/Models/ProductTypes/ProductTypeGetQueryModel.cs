using Application.Common.Mapping;
using Application.Features.Common;
using Domain.Entities;

namespace Application.Models.ProductTypes;

public class ProductTypeGetQueryModel : CommandQueryModel, IMapFrom<ProductType>
{
    public string Title { get; set; }
}
