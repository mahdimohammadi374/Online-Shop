using Application.Contracts;
using Application.Features.ProductBrands.Queries.GetAll;
using Application.Features.ProductTypes.Queries.Get;
using Domain.Entities;
using MediatR;

namespace Application.Features.ProductTypes.Queries.GetAll;

public class ProductTypeGetAllHandler : IRequestHandler<ProductTypeGetAllQuery, IEnumerable<ProductType>>
{
    private readonly IUnitOfWork _unitOfWork;
    public ProductTypeGetAllHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<ProductType>> Handle(ProductTypeGetAllQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Repository<ProductType>().ListAsyncSpec(new ProductTypeGetSpec(),cancellationToken);
    }
}
