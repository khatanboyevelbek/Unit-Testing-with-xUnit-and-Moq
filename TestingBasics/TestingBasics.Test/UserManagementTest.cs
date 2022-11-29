using Moq;
using TestingBasics.Functionalities;

namespace TestingBasics.Test
{

    public class ShoppingCardTest
    {
        public readonly Mock<IDbService> dbServiceMock = new();

        [Fact]
        public void AddProductTest()
        {
            Product product = new(1, "Keyboard", 23.5);
            dbServiceMock.Setup(x =>
              x.SaveShoppingCartItem(product))
                .Returns(true);

            // Arrange
            ShoppingCard shoppingCard = new(dbServiceMock.Object);

            // Act
            bool result = shoppingCard.AddProduct(product);

            // Assert
            Assert.True(result);
            dbServiceMock.Verify(x => x.SaveShoppingCartItem(It.IsAny<Product>()), Times.Once());

        }

        [Fact]
        public void RemoveProductTest()
        {
            Product product = new(2, "Monitor", 345);
            dbServiceMock.Setup(x => x.RemoveShoppingCartItem(product.Id)).Returns(true);

            // Arrange
            ShoppingCard shoppingCard = new(dbServiceMock.Object);

            // Act
            bool result = shoppingCard.RemoveProduct(product.Id);

            // Assert
            Assert.True(result);
        }
    }
}