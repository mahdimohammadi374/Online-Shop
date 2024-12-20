using Application.Features.ProductBrands.Queries.GetAll;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Web.Common;

namespace Web.Controllers;

public class ProductBrandController : BaseController
{
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] ProductBrandsGetAllQuery query)
        => Ok(await Mediator.Send(query));
}
