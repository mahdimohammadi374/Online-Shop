using Application.Features.ProductTypes.Queries.GetAll;
using Microsoft.AspNetCore.Mvc;
using Web.Common;

namespace Web.Controllers;

public class ProductTypeController : BaseController
{
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery]ProductTypeGetAllQuery query)
        => Ok(await Mediator.Send(query));
}
