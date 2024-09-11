using CleanArchitecture1.Application.Parameters;
using CleanArchitecture1.Application.Wrappers;
using CleanArchitecture1.Domain.Products.DTOs;
using MediatR;

namespace CleanArchitecture1.Application.Features.Products.Queries.GetPagedListProduct
{
    public class GetPagedListProductQuery : PaginationRequestParameter, IRequest<PagedResponse<ProductDto>>
    {
        public string Name { get; set; }
    }
}
