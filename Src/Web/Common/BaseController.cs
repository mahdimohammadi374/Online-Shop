using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Web.Common;

[Route("api/[controller]")]
[ApiController]
public class BaseController : ControllerBase
{
    private ISender sender = null!;
    protected ISender Mediator => sender ??= HttpContext.RequestServices.GetRequiredService<ISender>();
}
