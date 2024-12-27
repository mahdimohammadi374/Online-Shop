using Application.Contracts.Specification;
using Application.Features.Products.Queries.GetAll;
using Application.Wrappers;
using Domain.Entities;
using MediatR;
using System.Linq.Expressions;

namespace Application.Features.Products.Queries.Get;

public class ProductGetSpec : BaseSpecification<Product>
{

    public ProductGetSpec(ProductGetAllQuery request) :
        base(Expression.ExpressionSpec(request)
        )
    {
        AddInclude(x => x.ProductBrand);
        AddInclude(x => x.ProductType);

        if (request.TypeSort == TypeSort.DESC)
        {
            switch (request.Sort)
            {
                case 1:
                    AddOrderByDesc(x => x.Title);
                    break;
                case 2:
                    AddOrderByDesc(x => x.ProductBrand.Title);
                    break;
                default:
                    AddOrderByDesc(x => x.Title);
                    break;
            }
        }
        else
        {
            switch (request.Sort)
            {
                case 1:
                    AddOrderBY(x => x.Id);
                    break;
                case 2:
                    AddOrderBY(x => x.Title);
                    break;
                case 3:
                    AddOrderBY(x => x.ProductBrand.Title);
                    break;
                default:
                    AddOrderBY(x => x.Title);
                    break;
            }
        }

        AddPagination(request.PageSize * (request.PageIndex - 1), request.PageSize, true);
    }

    
    public ProductGetSpec(long id) : base(x=>x.Id == id)
    {
        AddInclude(x => x.ProductBrand);
        AddInclude(x => x.ProductType);
    }
}

public class ProductsCountSpec : BaseSpecification<Product>
{
    public ProductsCountSpec(ProductGetAllQuery request) :
        base(Expression.ExpressionSpec(request)
        )
    {
        IsPaginEnabled = false;
    }
}

public static class Expression
{
    public static Expression<Func<Product, bool>> ExpressionSpec(ProductGetAllQuery request)
    {
        return x => (!request.BrandId.HasValue || x.ProductBrandId == request.BrandId) &&
                          (!request.TypeId.HasValue || x.ProductTypeId == request.TypeId) &&
                          (string.IsNullOrEmpty(request.Search) || x.Title.ToLower().Contains(request.Search));
    }

}