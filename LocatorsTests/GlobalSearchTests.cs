using LocatorsPracticalTask.Drivers;
using LocatorsPracticalTask.Pages;
using OpenQA.Selenium;

namespace LocatorsPracticalTask.Tests
{

    [TestFixture]
    public class GlobalSearchTests
    {
        private IWebDriver? driver;

        [SetUp]
        public void Setup()
        {
            driver = DriverFactory.GetDriver();
            driver?.Navigate().GoToUrl("https://www.epam.com/");
        }

        [TestCase("BLOCKCHAIN")]
        [TestCase("Cloud")]
        [TestCase("Automation")]
        public void ValidateGlobalSearch(string term)
        {
            var home = new HomePage(driver);
            home.AcceptCookies();
            home.ClickSearchIcon();

            var search = new GlobalSearchPage(driver);
            search.Search(term);

            Assert.IsTrue(search.AllResultsContain(term), $"All results should contain: {term}");
        }

        [TearDown]
        public void Teardown()
        {
            driver?.Quit();
            driver?.Dispose();
        }
    }
}

