using CleanMediator.Applicaiotn.Dtos;
using CleanMediator.CommonForPagination;
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

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCategory(int id, [FromBody] CategoryDto dto)
    {
        var result= await _mediatr.Send(new UpdateCategoryCommand(id, dto));
        return Ok(result); 
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCategory(int id)
    {
        var result= await _mediatr.Send(new DeleteCategoryCommand(id));
        return Ok(result); 
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery]PaginationParams dto)
    {
        var result= await _mediatr.Send(new GetAllCategoryQuery(dto));
        return Ok(result); 
    }


    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result= await _mediatr.Send(new GetByIdCategoryQuery(id));
        return Ok(result); 
    }

}