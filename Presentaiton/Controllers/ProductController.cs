using CleanMediator.Applicaiotn.Dtos;
using CleanMediator.CommonForPagination;
using CleanMediator.Features.Categories.Command;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanMediator.Presentaiton.Controllers; 

[ApiController]
[Route("product")]
public class ProductController : ControllerBase
{
    private readonly IMediator _mediatr; 
    public ProductController(IMediator mediatr)
    {
        _mediatr=mediatr;
    }

    
}