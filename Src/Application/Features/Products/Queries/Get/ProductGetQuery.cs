using Application.Contracts;
using Domain.Entities;
using MediatR;

namespace Application.Features.Products.Queries.Get;

public class ProductGetQuery : IRequest<Product>, IQueryCache
{
    public long Id { get; set; }
    public int SaveHours { get => 1; }

    public ProductGetQuery(long id)
    {
        Id = id;
    }
}
