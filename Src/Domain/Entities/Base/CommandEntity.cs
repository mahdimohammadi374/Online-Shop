namespace Domain.Entities.Base;

public class CommandEntity : ICommandEntity
{
    public string Description { get; set; }
    public bool IsActive { get; set; } = true;
    public bool IsDeleted { get; set; } = false;
    public string Summary { get; set; }
}

public interface ICommandEntity
{
    public string Description { get; set; }
    public bool IsActive { get; set; } 
    public bool IsDeleted { get; set; } 
    public string Summary { get; set; }
}