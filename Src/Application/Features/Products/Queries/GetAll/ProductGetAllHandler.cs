using Application.Common.Mapping;
using Application.Contracts;
using Application.Features.Products.Queries.Get;
using Application.Models.Products;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System.Linq.Expressions;

namespace Application.Features.Products.Queries.GetAll;

public class ProductGetAllHandler : IRequestHandler<ProductGetAllQuery, PaginationResponse<ProductsGetQueryModel>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;


    public ProductGetAllHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<PaginationResponse<ProductsGetQueryModel>> Handle(ProductGetAllQuery request, CancellationToken cancellationToken)
    {
        var spec = new ProductGetSpec(request);
        var count = await _unitOfWork.Repository<Product>().CountSpecAsync(new ProductsCountSpec(request),cancellationToken);
        var result = await _unitOfWork.Repository<Product>().ListAsyncSpec(spec, cancellationToken);

        var response = new PaginationResponse<ProductsGetQueryModel>()
        {
            Count = count,
            PageIndex = request.PageIndex,
            PageSize = request.PageSize,
            Result = _mapper.Map<List<ProductsGetQueryModel>>(result)
        };
        return response;
    }  
}
