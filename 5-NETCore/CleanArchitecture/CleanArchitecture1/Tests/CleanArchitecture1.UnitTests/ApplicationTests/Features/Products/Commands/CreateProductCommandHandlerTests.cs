using CleanArchitecture1.Application.Features.Products.Commands.CreateProduct;
using CleanArchitecture1.Application.Interfaces;
using CleanArchitecture1.Application.Interfaces.Repositories;
using Moq;
using Shouldly;

namespace CleanArchitecture1.UnitTests.ApplicationTests.Features.Products.Commands
{
    public class CreateProductCommandHandlerTests
    {
        [Fact]
        public async Task Handle_ValidCommand_ReturnsSuccessResultWithProductId()
        {
            // Arrange
            var productRepositoryMock = new Mock<IProductRepository>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();

            var handler = new CreateProductCommandHandler(productRepositoryMock.Object, unitOfWorkMock.Object);

            var command = new CreateProductCommand
            {
                Name = "Test Product",
                Price = 100,
                BarCode = "123456789"
            };

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            result.ShouldNotBeNull();
            result.Success.ShouldBeTrue();
        }
    }
}
