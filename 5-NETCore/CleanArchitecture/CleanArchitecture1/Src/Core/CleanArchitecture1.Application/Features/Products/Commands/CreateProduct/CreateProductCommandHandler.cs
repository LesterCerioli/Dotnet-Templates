using CleanArchitecture1.Application.Interfaces;
using CleanArchitecture1.Application.Interfaces.Repositories;
using CleanArchitecture1.Application.Wrappers;
using CleanArchitecture1.Domain.Products.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture1.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork) : IRequestHandler<CreateProductCommand, BaseResult<long>>
    {
        public async Task<BaseResult<long>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product(request.Name, request.Price, request.BarCode);

            await productRepository.AddAsync(product);
            await unitOfWork.SaveChangesAsync();

            return product.Id;
        }
    }
}
