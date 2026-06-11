using CleanMediator.CommonForPagination;
using Microsoft.EntityFrameworkCore;

namespace CleanMediator.Extensions;

public static class ExtensionQueryForPagination 
{
    public static async Task<PagedResult<T>> ToPagedResultAsync<T>(this IQueryable<T> query, 
        int pageNumber, 
        int pageSize)
    {
        var TotalCount=  await query.CountAsync();
        var items= await query.Skip((pageNumber-1)*pageSize)
                    .Take(pageSize)
                    .ToListAsync(); 

        return new PagedResult<T>
        {
            Items=items,
            PageNumber=pageNumber, 
            PageSize=pageSize, 
            TotalItem=TotalCount
        };
    }
}