namespace INStock.Tests
{
    using NUnit.Framework;
    using Moq;
    using INStock.Contracts;

    public class ProductStockTests
    {
        Mock<Product> mockProduct; 
        [SetUp]

        public void SetUp()
        {
            mockProduct = new Mock<Product>("Pizza", 45m,5);

            
            


        }

        [Test]

        public void CheckMockingWorks()
        {

            Assert.AreEqual(mockProduct.Object.Label, "Pizza");
            Assert.AreEqual(mockProduct.Object.Price, 45m);
            Assert.AreEqual(mockProduct.Object.Quantity, 5);
        }

    }
}
