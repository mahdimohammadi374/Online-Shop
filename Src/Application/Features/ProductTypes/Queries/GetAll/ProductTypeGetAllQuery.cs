using Application.Models.ProductTypes;
using Domain.Entities;
using MediatR;

namespace Application.Features.ProductTypes.Queries.GetAll;

public class ProductTypeGetAllQuery : IRequest<IEnumerable<ProductTypeGetQueryModel>>
{
}
