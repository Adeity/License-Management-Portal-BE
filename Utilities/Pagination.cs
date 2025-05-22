namespace LicenseManagementPortal.Utilities;

public class Pagination<T>
{
    public List<T> Items { get; }
    public int TotalItems { get; }
    public int PageNumber { get; }
    public int PageSize { get; }
    public bool NextPage { get; }
    public bool PreviousPage { get; }
    public int TotalPages { get; }

    public Pagination(List<T> items, int totalItems, int pageNumber, int pageSize)
    {
        Items = items;
        TotalItems = totalItems;
        PageNumber = pageNumber;
        PageSize = pageSize;
        TotalPages = (int)Math.Ceiling(totalItems / (double)pageSize);
        NextPage = pageNumber < TotalPages;
        PreviousPage = pageNumber > 1;
    }

}