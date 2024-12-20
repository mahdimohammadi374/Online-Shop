using Domain.Entities.Base;

namespace Domain.Entities;

public class ProductBrand : BaseAuditableEntity, ICommandEntity
{
    public string Title { get; set; }
    public string Description { get ; set ; }
    public bool IsActive { get; set; } = true;
    public string Summary { get ; set ; }
}
