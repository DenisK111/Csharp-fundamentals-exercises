namespace INStock.Tests
{
    using INStock.Contracts;
    using NUnit.Framework;
    using System;
    using System.Collections;
    using System.Collections.Generic;

    [TestFixture]
    public class ProductTests
    {
        [TestCase("Pasta",5.60,4)]
        [TestCase("Pizza",0.01,0)]
        [TestCase("Pasta",1.4142144145,int.MaxValue)]

        public void ConstructorWorksCorrectlyPositiveTest(string label,decimal price,int quantity)
        {

            Assert.IsNotNull(new Product(label, price, quantity));

        }

        [TestCase(null,0.01,1)]
        [TestCase("",0.01,1)]
        [TestCase(" ",0.01,1)]
        [TestCase(" d",0,0)]
        [TestCase(" d",0.01,-1)]

        public void ConstructorThrowsExceptionNegativeTest(string label,decimal price,int quantity)
        {
            Assert.Throws<ArgumentException>(() => new Product(label, price, quantity));

        }
        [TestCaseSource("CreateProductArrayToCheckCompareTo")]
        public void CompareToShouldReturnCorrectValues((IProduct[] products,int expected) input )
        {
            var product1 = input.products[0];
            var product2 = input.products[1];
            var expected = input.expected;

            var result = product1.CompareTo(product2);
            Assert.AreEqual(expected,result);
        }

        [TestCaseSource("CreateProductArrayToCheckEquals")]

        public void EqualsShouldReturnCorrectValues((IProduct[] products, bool expected) input)
        {
            var product1 = input.products[0];
            var product2 = input.products[1];
            var expected = input.expected;

            var result = product1.Equals(product2);
            Assert.AreEqual(expected, result);
        }


        private static IEnumerable<(IProduct[],int)> CreateProductArrayToCheckCompareTo() 
        {
            
            yield return  (new Product[] { new Product("Pasta", 5.60m, 4), new Product("Pasta", 5.61m, 4) },-1);
            yield return (new Product[] { new Product("Pasta", 5.60m, 4), new Product("Pasta", 5.60m, 4) }, 0);
            yield return (new Product[] { new Product("Pasta", 5.60m, 4), new Product("Pasta", 5.59m, 4) }, 1);
        }

        private static IEnumerable<(IProduct[], bool)> CreateProductArrayToCheckEquals()
        {

            yield return (new Product[] { new Product("Pasta", 5.60m, 4), new Product("Pasta", 5.61m, 4) }, true);
            yield return (new Product[] { new Product("Pastas", 5.60m, 4), new Product("Pastad", 5.60m, 4) }, false);
            yield return (new Product[] { new Product("d12rd2d1", 5.60m, 4), new Product("asda", 5.59m, 4) }, false);
        }


    }
}