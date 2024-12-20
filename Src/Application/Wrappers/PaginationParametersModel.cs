namespace Application.Wrappers;

public class PaginationParametersModel
{
    private const int MaxPageSize = 50;
    private int _pageSize;
    private int _pageIndex;
    public int PageSize { get => _pageSize; set => _pageSize = value > MaxPageSize ? MaxPageSize : value; }
    public int PageIndex { get => _pageIndex; set => _pageIndex = value <= 0 ? 1 : value; }
}
