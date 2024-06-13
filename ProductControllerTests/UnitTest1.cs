using Microsoft.AspNetCore.Mvc;
using Moq;
using ProductManagement.Controllers;
using ProductManagement.Interface;
using ProductManagement.Models;
using ProductsManagement.Services;

namespace ProductControllerTests
{
    public class ProductControllerTests
    {
        private readonly Mock<IProductService> _mockProductService;
        private readonly ProductController _controller;

        public ProductControllerTests()
        {
            _mockProductService = new Mock<IProductService>();
            _controller = new ProductController(_mockProductService.Object);
        }

        [Fact]
        public void Get_ReturnsAllProducts()
        {
            // Arrange
            var products = new List<Product> { new Product { Id = 1, Name = "Product1" } };
            _mockProductService.Setup(service => service.GetAll()).Returns(products);

            // Act
            var result = _controller.Get();

            // Assert
            var actionResult = Assert.IsType<ActionResult<List<Product>>>(result);
            var returnValue = Assert.IsType<List<Product>>(actionResult.Value);
            Assert.Equal(products.Count, returnValue.Count);
        }

        [Fact]
        public void Get_ReturnsProductById()
        {
            // Arrange
            var product = new Product { Id = 1, Name = "Product1" };
            _mockProductService.Setup(service => service.GetById(1)).Returns(product);

            // Act
            var result = _controller.Get(1);

            // Assert
            var actionResult = Assert.IsType<ActionResult<Product>>(result);
            var returnValue = Assert.IsType<Product>(actionResult.Value);
            Assert.Equal(product.Id, returnValue.Id);
        }

        [Fact]
        public void Get_ReturnsNotFound_WhenProductNotExists()
        {
            // Arrange
            _mockProductService.Setup(service => service.GetById(1)).Returns((Product)null);

            // Act
            var result = _controller.Get(1);

            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public void Add_ReturnsCreatedAtActionResult()
        {
            // Arrange
            var product = new Product { Id = 1, Name = "Product1" };

            // Act
            var result = _controller.Add(product);

            // Assert
            var actionResult = Assert.IsType<CreatedAtActionResult>(result);
            var returnValue = Assert.IsType<Product>(actionResult.Value);
            Assert.Equal(product.Id, returnValue.Id);
        }

        [Fact]
        public void Update_ReturnsNoContent_WhenValid()
        {
            // Arrange
            var product = new Product { Id = 1, Name = "Product1" };

            // Act
            var result = _controller.Update(1, product);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public void Update_ReturnsBadRequest_WhenIdMismatch()
        {
            // Arrange
            var product = new Product { Id = 2, Name = "Product1" };

            // Act
            var result = _controller.Update(1, product);

            // Assert
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public void Delete_ReturnsNoContent_WhenValid()
        {
            // Act
            var result = _controller.Delete(1);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }
    }
}