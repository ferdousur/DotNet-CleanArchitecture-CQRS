using FluentValidation;
using MediatR;

namespace CleanMediator.Behaviors;

public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> 
                                                            where TRequest : IRequest<TRequest>
{
    private readonly IEnumerable<IValidator<TRequest>> _validator; 

    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validator)
    {
        _validator=validator;
    }
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var failures= _validator.Select(v=> v.Validate(request))
                    .SelectMany(result=> result.Errors)
                    .Where(error=> error!=null)
                    .ToList(); 
        if(failures.Any())
        {
            throw new ValidationException(failures);
        }
        return await next(); 
    }
}