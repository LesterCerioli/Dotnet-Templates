using CleanArchitecture1.Application.Interfaces.Repositories;
using CleanArchitecture1.Application.Wrappers;
using CleanArchitecture1.Domain.Products.DTOs;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture1.Application.Features.Products.Queries.GetPagedListProduct
{
    public class GetPagedListProductQueryHandler(IProductRepository productRepository) : IRequestHandler<GetPagedListProductQuery, PagedResponse<ProductDto>>
    {
        public async Task<PagedResponse<ProductDto>> Handle(GetPagedListProductQuery request, CancellationToken cancellationToken)
        {
            return await productRepository.GetPagedListAsync(request.PageNumber, request.PageSize, request.Name);
        }
    }
}
