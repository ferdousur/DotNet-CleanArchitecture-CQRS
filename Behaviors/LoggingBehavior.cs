using System.Diagnostics;
using MediatR;

namespace CleanMediator.Behaviors;

public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
                                                    where TRequest : IRequest<TResponse>
{
    private readonly ILogger<TResponse> _logger; 
    public LoggingBehavior(ILogger<TResponse> logger)
    {
        _logger=logger; 
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {

        try
        {
            _logger.LogInformation($"Start Request RequestName: {typeof(TRequest).Name}"); 
            var startTime=Stopwatch.StartNew(); 
            var response= await (next()); 
            startTime.Stop();
            _logger.LogInformation($"Request Done RequestName: {typeof(TRequest).Name}"); 
            _logger.LogInformation($"its Take {startTime.Elapsed.TotalMilliseconds}"); 
            return response; 
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An Error Occurred: {RequestName}", typeof(TRequest).Name);
            throw;
        }
    }
}