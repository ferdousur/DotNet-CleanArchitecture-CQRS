namespace CleanMediator.CommonForPagination; 

public class PaginationParams
{
    public int PageNumber {get;set;}=1;
    private int _pageSize {get;set;} = 10;  

    public int PageSize
    {
        get
        {
            return _pageSize;            
        }
        set
        {
            if(value > 100)
            {
                _pageSize=100;
            }
            else if( value <= 0)
            {
                _pageSize=10; 
            }
            else
            {
                _pageSize=value;
            }
        }
    }
}