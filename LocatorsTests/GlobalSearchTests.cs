using LocatorsPracticalTask.Core;
using LocatorsPracticalTask.Pages;
using OpenQA.Selenium;

namespace LocatorsPracticalTask.Tests
{

    [TestFixture]
    public class GlobalSearchTests : TestBase
    {

        [TestCase("BLOCKCHAIN")]
        [TestCase("Cloud")]
        [TestCase("Automation")]
        public void ValidateGlobalSearch(string term)
        {
            var home = new HomePage(Driver);
            var search = new GlobalSearchPage(Driver);

            home.AcceptCookies();
            home.ClickSearchIcon();
            search.Search(term);

            Assert.IsTrue(search.AllResultsContain(term), $"All results should contain: {term}");
        }
    }
}

