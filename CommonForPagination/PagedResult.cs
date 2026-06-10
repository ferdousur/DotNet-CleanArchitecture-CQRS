namespace CleanMediator.CommonForPagination; 

public class PagedResult<T>
{
    public int PageNumber { get; set; }
    public int PageSize {get;set;}
    public int TotalItem {get;set;}

    public int TotalPageCount
    {
        get
        {
            return (int)Math.Ceiling((double)TotalItem/PageSize); 
        }
    }
    public bool HasPrevious => 1 < PageNumber ; 
    public bool HasNext => PageNumber < TotalPageCount;
    public List<T> Items {get;set;}=[]; 
}