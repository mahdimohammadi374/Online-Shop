using Application.Contracts;
using Application.Helper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System.Text;
using System.Web;

namespace Application.Common.BehaviorPipes;

public class CacheQueryBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IQueryCache, IRequest<TResponse>
{
    private readonly IDistributedCache _distributedCache;
    private readonly IHttpContextAccessor _httpContext;
    public CacheQueryBehavior(IDistributedCache distributedCache, IHttpContextAccessor httpContext)
    {
        _distributedCache = distributedCache;
        _httpContext = httpContext;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        TResponse response;
        var key = GenerateKey();
        var cachedResponse = await _distributedCache.GetAsync(key, cancellationToken);
        if (cachedResponse != null)
        {
            response = JsonConvert.DeserializeObject<TResponse>(Encoding.UTF8.GetString(cachedResponse));
        }
        else
        {
            response = await next();
            var seialized = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(response));
            await CreateNewCache(request, key, cancellationToken, seialized);
        }
        return response;
    }
    private Task CreateNewCache(TRequest request, string key, CancellationToken cancellationToken, byte[] seialized)
    {
        return _distributedCache.SetAsync(key, seialized,
            new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeToLive(request)
            }, cancellationToken);
    }
    private static TimeSpan TimeToLive(TRequest request)
    {
        return new TimeSpan(request.SaveHours, 0, 0, 0);
    }
    private string GenerateKey()
    {
        return IdGenerator.GenerateCacheKeyFromRequest(_httpContext.HttpContext.Request);
    }
}
