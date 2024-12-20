using Application.Contracts.Specification;
using Domain.Entities;
using System.Linq.Expressions;

namespace Application.Features.Products.Queries.Get;

public class ProductGetSpec : BaseSpecification<Product>
{

    public ProductGetSpec()
    {
        AddInclude(x => x.ProductBrand);
        AddInclude(x => x.ProductType);
    }

    public ProductGetSpec(long id) : base(x=>x.Id == id)
    {
        AddInclude(x => x.ProductBrand);
        AddInclude(x => x.ProductType);
    }
}
