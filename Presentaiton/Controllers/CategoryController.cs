using CleanMediator.Applicaiotn.Dtos;
using CleanMediator.Features.Categories.Command;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanMediator.Presentaiton.Controllers; 

[ApiController]
[Route("category")]
public class CategoryController : ControllerBase
{
    private readonly IMediator _mediatr; 
    public CategoryController(IMediator mediatr)
    {
        _mediatr=mediatr;
    }

    [HttpPost]
    public async Task<IActionResult> CreateCategory ([FromBody]CategoryDto dto)
    {
        var result= await _mediatr.Send(new CreateCategoryCommand(dto.Name, dto.CategoryId));
        return Ok(result);  
    }
}