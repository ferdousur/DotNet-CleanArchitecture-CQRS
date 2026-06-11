using CleanMediator.Applicaiotn.Dtos;
using CleanMediator.Domain;
using CleanMediator.Interfaces;
using MediatR;

namespace CleanMediator.Features.Categories.Command;

public record UpdateCategoryCommand(int id, CategoryDto Dto) : IRequest<ResponseCategoryDto>;


public class UpdateCategoryHandler : IRequestHandler<UpdateCategoryCommand, ResponseCategoryDto>
{
    private readonly IRepository<Category> _repo;
    public UpdateCategoryHandler(IRepository<Category> repo)
    {
        _repo = repo;
    }
    public async Task<ResponseCategoryDto> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await _repo.GetByIdAsync(request.id);
        if (category == null) return null!;
        category.CategoryName = request.Dto.Name;
        category.ParentCategoryId = request.Dto.CategoryId;
        await _repo.SaveChangesAsync();

        var reesponseDto = new ResponseCategoryDto
        (
             category.CategoryName,
             category.ParentCategoryId,
             category.Children.Select(x => new CategoryDto
             (
                x.CategoryName,
                x.ParentCategoryId

             )).ToList()
        );
        return reesponseDto;

    }
}