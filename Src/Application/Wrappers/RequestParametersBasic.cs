namespace Application.Wrappers;

public abstract class RequestParametersBasic
{
    private string _search { get; set; }
    public TypeSort TypeSort { get; set; }
    public int Sort { get; set; } = 1;

    public string Search { get => _search; set
        {
            _search = value?.ToLower();
        } }
}
public enum TypeSort
{
    DESC = 1,
    ASC
}