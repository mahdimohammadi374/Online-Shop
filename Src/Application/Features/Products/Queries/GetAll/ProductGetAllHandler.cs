using Application.Common.Mapping;
using Application.Contracts;
using Application.Features.Products.Queries.Get;
using Application.Models.Products;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System.Linq.Expressions;

namespace Application.Features.Products.Queries.GetAll;

public class ProductGetAllHandler : IRequestHandler<ProductGetAllQuery, IEnumerable<ProductsGetQueryModel>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;


    public ProductGetAllHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ProductsGetQueryModel>> Handle(ProductGetAllQuery request, CancellationToken cancellationToken)
    {
        var spec = new ProductGetSpec();
        var result = await _unitOfWork.Repository<Product>().ListAsyncSpec(spec, cancellationToken);
        return _mapper.Map<List<ProductsGetQueryModel>>(result);
    }  
}
