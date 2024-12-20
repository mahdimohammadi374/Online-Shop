using Application.Contracts.Specification;
using Domain.Entities;

namespace Application.Features.ProductBrands.Queries.Get;

public class ProductBrandGetSpec : BaseSpecification<ProductBrand>
{
    public ProductBrandGetSpec(long id):base(x=>x.Id == id)
    {
    }

    public ProductBrandGetSpec()
    {
    }
}
