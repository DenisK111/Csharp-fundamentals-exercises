using MVCFramework.MVCViewEngine;
using System.Globalization;

namespace MVCViewEngine.Tests
{
    public class ViewEngineTests
    {
        private IViewEngine viewEngine = new ViewEngine();
        [Theory]
        [InlineData("testCleanHtml", "testCleanHtml")]
        [InlineData("forifelse","forifelseVe")]
        
        public void TestViewEngine(string htmlexpected,string cshtml)
        {
            var expected = File.ReadAllText($"{htmlexpected}.html");
            var result = viewEngine.GenerateView(File.ReadAllText($"{cshtml}.html"));

            Assert.Equal(expected, result);
        }
        [Theory]
        [InlineData("viewModelTest", "viewModelTestVe","Pesho",2.00,"16/09/2021")]
        public void TestViewModel(string htmlexpected,string cshtml,string name, decimal price, string dateofBirth)
        {
            var expected = File.ReadAllText($"{htmlexpected}.html");
            var result = viewEngine.GenerateView(File.ReadAllText($"{cshtml}.html"),new TestViewModel()
            {
                Name = name,
                Price = price,
                DateOfBirth = DateTime.ParseExact(dateofBirth, "dd/MM/yyyy", CultureInfo.InvariantCulture)
            });

           

        }

        [Fact]
        public void TestTemplateViewModel()
        {
            var result = viewEngine.GenerateView(@"@foreach(var num in @Model)
{
<span>@num</span>
}", new List<int> { 1, 2, 3 });
            var expected = @"<span>1</span>
<span>2</span>
<span>3</span>
";
            Assert.Equal(expected, result);
            }
    }

    public class TestViewModel
    {
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }

        public DateTime DateOfBirth { get; set; }

    }
}