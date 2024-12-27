using Application.Models.ProductBrands;
using Domain.Entities;
using MediatR;

namespace Application.Features.ProductBrands.Queries.GetAll;

public class ProductBrandsGetAllQuery : IRequest<IEnumerable<ProductBrandGetQueryModel>>
{
}
