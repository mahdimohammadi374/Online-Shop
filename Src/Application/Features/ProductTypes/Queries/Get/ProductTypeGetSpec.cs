using Application.Contracts.Specification;
using Domain.Entities;

namespace Application.Features.ProductTypes.Queries.Get;

public class ProductTypeGetSpec : BaseSpecification<ProductType>
{
    public ProductTypeGetSpec()
    {
        
    }
    public ProductTypeGetSpec(long id):base(x=>x.Id == id)
    {
        
    }
}
