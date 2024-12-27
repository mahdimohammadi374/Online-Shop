using Application.Contracts;
using Application.Features.ProductBrands.Queries.GetAll;
using Application.Features.ProductTypes.Queries.Get;
using Application.Models.ProductTypes;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ProductTypes.Queries.GetAll;

public class ProductTypeGetAllHandler : IRequestHandler<ProductTypeGetAllQuery, IEnumerable<ProductTypeGetQueryModel>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public ProductTypeGetAllHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ProductTypeGetQueryModel>> Handle(ProductTypeGetAllQuery request, CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.Repository<ProductType>().ListAsyncSpec(new ProductTypeGetSpec(),cancellationToken);
        return _mapper.Map<IEnumerable<ProductTypeGetQueryModel>>(result);
    }
}
