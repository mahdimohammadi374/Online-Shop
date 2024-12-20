
using Microsoft.AspNetCore.Http;
using System.Text;

namespace Application.Helper;

public class IdGenerator
{
    internal static string GenerateCacheKeyFromRequest(HttpRequest request)
    {
        var keyBuilder = new StringBuilder();
        keyBuilder.Append($"{request.Path}");

        foreach (var (key, value) in request.Query.OrderBy(x => x.Key))
            keyBuilder.Append($"|{key}--{value}");
        return keyBuilder.ToString();
    }
}
