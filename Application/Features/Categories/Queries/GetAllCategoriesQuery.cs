using CleanMediator.Applicaiotn.Dtos;
using CleanMediator.CommonForPagination;
using CleanMediator.Domain;
using CleanMediator.Interfaces;
using MediatR;

namespace CleanMediator.Features.Categories.Command;

public record GetAllCategoryQuery(PaginationParams Pagination) : IRequest<PagedResult<ResponseCategoryDto>>;


public class GetAllCategoryHandler : IRequestHandler<GetAllCategoryQuery, PagedResult<ResponseCategoryDto>>
{
    private readonly IRepository<Category> _repo;
    public GetAllCategoryHandler(IRepository<Category> repo)
    {
        _repo = repo;
    }

    public async Task<PagedResult<ResponseCategoryDto>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
    {
        var result= await _repo.GetAllAsync(request.Pagination);

        var mappedItem=result.Items.Select(x=>  new ResponseCategoryDto
        (
            x.CategoryName, 
            x.ParentCategoryId, 
            x.Children.Select(c=> new CategoryDto
            (
                c.CategoryName, c.ParentCategoryId
            )).ToList()
        )).ToList();

        return new PagedResult<ResponseCategoryDto>
        {
             Items=mappedItem, 
             PageNumber=result.PageNumber, 
             PageSize=result.PageSize, 
             TotalItem= result.TotalItem
        };
    }
}