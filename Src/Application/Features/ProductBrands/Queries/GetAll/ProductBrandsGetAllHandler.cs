using Application.Contracts;
using Domain.Entities;
using MediatR;

namespace Application.Features.ProductBrands.Queries.GetAll;

public class ProductBrandsGetAllHandler : IRequestHandler<ProductBrandsGetAllQuery, IEnumerable<ProductBrand>>
{
    private readonly IUnitOfWork _unitOfWork;
    public ProductBrandsGetAllHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<ProductBrand>> Handle(ProductBrandsGetAllQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Repository<ProductBrand>().GetAllAsync(cancellationToken);
    }
}
