using Application.Contracts;
using Domain.Entities;
using Domain.Exceptions;
using MediatR;

namespace Application.Features.Products.Queries.Get;

public class ProductGetHandler : IRequestHandler<ProductGetQuery, Product>
{
    private readonly IUnitOfWork _uow;
    public ProductGetHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<Product> Handle(ProductGetQuery request, CancellationToken cancellationToken)
    {
        var spec = new ProductGetSpec(request.Id);
        var result= await _uow.Repository<Product>().GetEntityWithSpec(spec, cancellationToken);
        if (result is null) throw new NotFoundEntityException();
       return result;
    }
}
