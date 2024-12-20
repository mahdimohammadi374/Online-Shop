using MediatR;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace Application.Common.BehaviorPipes;

public class PerformanceBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    private readonly ILogger<TRequest> _logger;
    private readonly Stopwatch _stopwatch;
    public PerformanceBehavior( ILogger<TRequest> logger)
    {
        _stopwatch =new Stopwatch();
        _logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        _stopwatch.Start();

        var response = await next();

        _stopwatch.Stop();
        var duration = _stopwatch.ElapsedMilliseconds;
        _logger.LogWarning($"{duration}");
        if(duration < 500) return response;

        var requestName = typeof(TRequest).Name;
        _logger.LogWarning($"reuest {requestName} took {duration} Milliseconds");
        return response;
    }
}
