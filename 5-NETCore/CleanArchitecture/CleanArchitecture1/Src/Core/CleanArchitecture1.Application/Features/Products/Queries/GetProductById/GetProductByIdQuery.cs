using CleanArchitecture1.Application.Wrappers;
using CleanArchitecture1.Domain.Products.DTOs;
using MediatR;

namespace CleanArchitecture1.Application.Features.Products.Queries.GetProductById
{
    public class GetProductByIdQuery : IRequest<BaseResult<ProductDto>>
    {
        public long Id { get; set; }
    }
}
