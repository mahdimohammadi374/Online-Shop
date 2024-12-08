using Domain.Entities.Base;

namespace Domain.Entities;

public class Product : BaseAuditableEntity, ICommandEntity
{
    public string Title { get; set; }
    public decimal Price { get; set; }
    public string PictureUrl { get; set; }
    public string Description { get; set; }
    public bool IsActive { get; set; }
    public bool IsDeleted { get; set; }
    public string Summary { get; set; }

    #region Relations
    public long ProductBrandId { get; set; }
    public ProductBrand ProductBrand { get; set; }
    public long ProductTypeId { get; set; }
    public ProductType ProductType { get; set; }
    #endregion
}
