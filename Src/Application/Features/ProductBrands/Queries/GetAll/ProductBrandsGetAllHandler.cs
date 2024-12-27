using Application.Contracts;
using Application.Models.ProductBrands;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ProductBrands.Queries.GetAll;

public class ProductBrandsGetAllHandler : IRequestHandler<ProductBrandsGetAllQuery, IEnumerable<ProductBrandGetQueryModel>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public ProductBrandsGetAllHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ProductBrandGetQueryModel>> Handle(ProductBrandsGetAllQuery request, CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.Repository<ProductBrand>().GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<ProductBrandGetQueryModel>>(result);
    }
}
