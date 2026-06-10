using CleanMediator.Domain;
using CleanMediator.Interfaces;
using MediatR;

namespace CleanMediator.Features.Categories.Command;

public record DeleteCategoryCommand (int Id) : IRequest<bool>; 


public class DeleteCategoryHandler : IRequestHandler<DeleteCategoryCommand, bool>
{
    private readonly IRepository<Category> _repo;
    public DeleteCategoryHandler(IRepository<Category> repo)
    {
        _repo=repo; 
    }
    public async Task<bool> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        var result = await _repo.DeleteAsync(request.Id);
        await _repo.SaveChangesAsync();
        return result;
        
    }
}