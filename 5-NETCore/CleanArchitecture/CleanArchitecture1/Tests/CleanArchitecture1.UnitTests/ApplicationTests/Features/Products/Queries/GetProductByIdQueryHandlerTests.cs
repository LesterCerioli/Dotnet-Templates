using CleanArchitecture1.Application.Features.Products.Queries.GetProductById;
using CleanArchitecture1.Application.Interfaces;
using CleanArchitecture1.Application.Interfaces.Repositories;
using CleanArchitecture1.Application.Wrappers;
using CleanArchitecture1.Domain.Products.Entities;
using Moq;
using Shouldly;

namespace CleanArchitecture1.UnitTests.ApplicationTests.Features.Products.Queries
{
    public class GetProductByIdQueryHandlerTests
    {
        [Fact]
        public async Task Handle_ProductExists_ReturnsSuccessResultWithProductDto()
        {
            // Arrange
            var productId = 1;
            var productName = "Test Product";
            var productPrice = 1000;
            var productBarCode = "123456789";

            var productRepositoryMock = new Mock<IProductRepository>();
            productRepositoryMock.Setup(repo => repo.GetByIdAsync(productId))
                                 .ReturnsAsync(new Product(productName, productPrice, productBarCode) { Id = productId });

            var translatorMock = new Mock<ITranslator>();

            var handler = new GetProductByIdQueryHandler(productRepositoryMock.Object, translatorMock.Object);

            var query = new GetProductByIdQuery { Id = productId };

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            result.ShouldNotBeNull();
            result.Success.ShouldBeTrue();
            result.Data.ShouldNotBeNull();
            result.Data.Id.ShouldBe(productId);
            result.Data.Name.ShouldBe(productName);
            result.Data.Price.ShouldBe(productPrice);
            result.Data.BarCode.ShouldBe(productBarCode);
        }

        [Fact]
        public async Task Handle_ProductNotExists_ReturnsNotFoundResult()
        {
            // Arrange
            var productId = 1;

            var productRepositoryMock = new Mock<IProductRepository>();
            productRepositoryMock.Setup(repo => repo.GetByIdAsync(productId));

            var translatorMock = new Mock<ITranslator>();
            translatorMock.Setup(translator => translator.GetString(It.IsAny<string>()))
                          .Returns("Product not found");

            var handler = new GetProductByIdQueryHandler(productRepositoryMock.Object, translatorMock.Object);

            var query = new GetProductByIdQuery { Id = productId };

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            result.ShouldNotBeNull();
            result.Success.ShouldBeFalse();
            result.Errors.ShouldContain(err => err.ErrorCode == ErrorCode.NotFound);
            result.Data.ShouldBeNull();
        }
    }
}
