namespace Domain.Entities.Base;

public class CommandEntity : ICommandEntity
{
    public string Description { get; set; }
    public bool IsActive { get; set; } = true;
    public string Summary { get; set; }
}

public interface ICommandEntity
{
    public string Description { get; set; }
    public bool IsActive { get; set; } 
    public string Summary { get; set; }
}