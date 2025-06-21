using LocatorsPracticalTask.Drivers;
using LocatorsPracticalTask.Pages;
using OpenQA.Selenium;

namespace LocatorsPracticalTask.Tests
{
    public class JobSearchTests
    {
        private IWebDriver? driver;

        [SetUp]
        public void Setup()
        {
            driver = DriverFactory.GetDriver();
            driver.Navigate().GoToUrl("https://www.epam.com/");
        }

        [TestCase(".NET")]
        [TestCase("JavaScript")]
        public void ValidateJobSearch(string keyword)
        {
            var home = new HomePage(driver);
            home.AcceptCookies();
            home.GoToCareers();

            var careers = new CareersPage(driver);
            careers.SearchJobs(keyword);
            careers.SortByDate();
            careers.OpenLastJob();

            var job = new JobDetailsPage(driver);
            Assert.IsTrue(job.ContainsKeyword(keyword), $"Job page should contain keyword: {keyword}");
        }

        [TearDown]
        public void TearDown()
        {
            driver?.Quit();
            driver?.Dispose();
        }
    }
}
