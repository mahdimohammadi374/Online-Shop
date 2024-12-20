using Application.Contracts;
using Application.Features.Products.Queries.Get;
using Application.Models.Products;
using Domain.Entities;
using MediatR;

namespace Application.Features.Products.Queries.GetAll;

public class ProductGetAllQuery : IRequest<IEnumerable<ProductsGetQueryModel>>, IQueryCache
{
    public int SaveHours => 1;
}
