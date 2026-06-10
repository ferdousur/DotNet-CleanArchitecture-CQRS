using CleanMediator.Applicaiotn.Dtos;
using CleanMediator.CommonForPagination;
using CleanMediator.Domain;
using CleanMediator.Interfaces;
using MediatR;

namespace CleanMediator.Features.Categories.Command;

public record GetByIdCategoryQuery(int Id) : IRequest<ResponseCategoryDto>;


public class GetByIdCategoryHandler : IRequestHandler<GetByIdCategoryQuery, ResponseCategoryDto>
{
    private readonly IRepository<Category> _repo;
    public GetByIdCategoryHandler(IRepository<Category> repo)
    {
        _repo = repo;
    }

    public async Task<ResponseCategoryDto> Handle(GetByIdCategoryQuery request, CancellationToken cancellationToken)
    {
        var result= await _repo.GetByIdAsync(request.Id); 
        if(result==null)
        {
            throw new KeyNotFoundException($"Category with id {request.Id} not found");
        }
        var responseDto= new ResponseCategoryDto
        (
            result.CategoryName, 
            result.ParentCategoryId, 
            result.Children.Select(x=> new CategoryDto
            (
                x.CategoryName, x.ParentCategoryId
            )).ToList()
        );

        return responseDto; 
    }
}