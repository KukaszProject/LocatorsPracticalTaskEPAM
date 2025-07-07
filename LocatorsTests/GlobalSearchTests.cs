using Core.Utilities;
using LocatorsPracticalTask.Pages;

namespace LocatorsTests
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
            search.ClickFindButton();

            Assert.IsTrue(search.AllResultsContain(term), $"All results should contain: {term}");
        }
    }
}

