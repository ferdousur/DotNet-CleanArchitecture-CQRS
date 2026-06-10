using CleanMediator.Applicaiotn.Dtos;
using CleanMediator.Domain;
using CleanMediator.Interfaces;
using MediatR;

namespace CleanMediator.Features.Categories.Command;

public record CreateCategoryCommand(string Name, int? ParentCategoryId) : IRequest<ResponseCategoryDto>;

public class CategoryHandler : IRequestHandler<CreateCategoryCommand, ResponseCategoryDto>
{
    private readonly IRepository<Category> _repo;
    public CategoryHandler(IRepository<Category> repo)
    {
        _repo = repo;
    }
    public async Task<ResponseCategoryDto> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = new Category
        {
            CategoryName = request.Name,
            ParentCategoryId = request.ParentCategoryId
        };

        await _repo.CreateAsync(category);
        await _repo.SaveChangesAsync();

        var categoryDto = new ResponseCategoryDto
        (
             category.CategoryName,
             category.ParentCategoryId,
             null
        );

        return categoryDto;
    }
}