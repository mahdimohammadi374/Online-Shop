using Application.Features.Products.Queries.Get;
using Application.Features.Products.Queries.GetAll;
using Domain.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Web.Common;

namespace Web.Controllers;

public class ProductController : BaseController
{
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] ProductGetAllQuery query)
        => Ok(await Mediator.Send(query));

    [HttpGet("GetById")]
    public async Task<IActionResult> Get([FromQuery]long id)
        => Ok(await Mediator.Send(new ProductGetQuery(id)));
}
