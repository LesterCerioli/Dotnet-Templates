using CleanArchitecture1.Application.Features.Products.Commands.CreateProduct;
using CleanArchitecture1.Application.Features.Products.Commands.DeleteProduct;
using CleanArchitecture1.Application.Features.Products.Commands.UpdateProduct;
using CleanArchitecture1.Application.Features.Products.Queries.GetPagedListProduct;
using CleanArchitecture1.Application.Features.Products.Queries.GetProductById;
using CleanArchitecture1.Application.Wrappers;
using CleanArchitecture1.Domain.Products.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CleanArchitecture1.WebApi.Controllers.v1
{
    [ApiVersion("1")]
    public class ProductController : BaseApiController
    {

        [HttpGet]
        public async Task<PagedResponse<ProductDto>> GetPagedListProduct([FromQuery] GetPagedListProductQuery model)
            => await Mediator.Send(model);

        [HttpGet]
        public async Task<BaseResult<ProductDto>> GetProductById([FromQuery] GetProductByIdQuery model)
            => await Mediator.Send(model);

        [HttpPost, Authorize]
        public async Task<BaseResult<long>> CreateProduct(CreateProductCommand model)
            => await Mediator.Send(model);

        [HttpPut, Authorize]
        public async Task<BaseResult> UpdateProduct(UpdateProductCommand model)
            => await Mediator.Send(model);

        [HttpDelete, Authorize]
        public async Task<BaseResult> DeleteProduct([FromQuery] DeleteProductCommand model)
            => await Mediator.Send(model);

    }
}
