using Application.Contracts;
using Application.Features.Products.Queries.Get;
using Application.Models.Products;
using Application.Wrappers;
using Domain.Entities;
using MediatR;

namespace Application.Features.Products.Queries.GetAll;

public class ProductGetAllQuery :RequestParametersBasic, IRequest<PaginationResponse<ProductsGetQueryModel>>, IQueryCache
{
    public long? BrandId { get; set; }
    public long? TypeId { get; set; }
    public int SaveHours => 1;
}
