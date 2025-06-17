//using LocatorsPracticalTask.Drivers;
//using LocatorsPracticalTask.Pages;
//using OpenQA.Selenium;

//namespace LocatorsPracticalTask.Tests
//{
//    public class GlobalSearchTests
//    {
//        private IWebDriver? driver;
//        private HomePage? home;
//        private GlobalSearchPage? searchPage;

//        [SetUp]
//        public void SetUp()
//        {
//            driver = WebDriverFactory.CreateDriver();
//            home = new HomePage(driver);
//            searchPage = new GlobalSearchPage(driver);
//        }

//        [TestCase("Blockchain")]
//        [TestCase("Cloud")]
//        [TestCase("Automation")]
//        [Test]
//        public void SearchSiteGlobally(string keyword)
//        {
//            home?.GoTo();
//            //searchPage?.ClickSearchIcon();
//            home?.AcceptCookies();
//            //home?.ClickSearchIcon();
//            searchPage?.ClickSearchIcon();
//            searchPage?.Search(keyword);

//            Assert.IsTrue(searchPage?.AllResultsContain(keyword), "Search results do not contain the keyword.");
//        }


//        [TearDown]
//        public void TearDown()
//        {
//            driver?.Quit();
//            driver?.Dispose();
//        }
//    }
//}


using LocatorsPracticalTask.Drivers;
using LocatorsPracticalTask.Pages;
using NUnit.Framework;
using OpenQA.Selenium;

[TestFixture]
public class TestCases
{
    private IWebDriver? _driver;

    [SetUp]
    public void Setup()
    {
        _driver = DriverFactory.GetDriver();
        _driver.Navigate().GoToUrl("https://www.epam.com/");
    }

    [TearDown]
    public void TearDown()
    {
        _driver?.Quit();
        _driver?.Dispose();
    }

    [TestCase(".NET")]
    [TestCase("JavaScript")]
    public void TestCase1_ValidateJobSearch(string keyword)
    {
        var home = new HomePage(_driver);
        home.ConfirmHumanCheckbox();
        home.AcceptCookies();
        home.GoToCareers();

        var careers = new CareersPage(_driver);
        careers.SearchJobs(keyword);
        careers.OpenLastJob();

        var job = new JobDetailsPage(_driver);
        Assert.IsTrue(job.ContainsKeyword(keyword), $"Job page should contain keyword: {keyword}");
    }

    [TestCase("BLOCKCHAIN")]
    [TestCase("Cloud")]
    [TestCase("Automation")]
    public void TestCase2_GlobalSearch(string term)
    {
        var home = new HomePage(_driver);
        home.AcceptCookies();
        home.ClickSearchIcon();

        var search = new GlobalSearchPage(_driver);
        search.Search(term);

        Assert.IsTrue(search.AllResultsContain(term), $"All results should contain: {term}");
    }

    [TearDown]
    public void Cleanup()
    {
        _driver?.Quit();
        _driver?.Dispose();
    }
}

