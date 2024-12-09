using Domain.Entities.Base;

namespace Domain.Entities;

public class ProductType : BaseAuditableEntity, ICommandEntity
{
    public string Title { get; set; }
    public string Description { get; set; }
    public bool IsActive { get; set; } = true;
    public bool IsDeleted { get; set; } = false;
    public string Summary { get; set; }
}
