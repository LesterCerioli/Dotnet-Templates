using CleanArchitecture1.Application.Wrappers;
using MediatR;

namespace CleanArchitecture1.Application.Features.Products.Commands.DeleteProduct
{
    public class DeleteProductCommand : IRequest<BaseResult>
    {
        public long Id { get; set; }
    }
}
