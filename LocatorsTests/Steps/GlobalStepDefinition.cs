using Drivers;
using LocatorsPracticalTask.Pages;
using OpenQA.Selenium;
using Reqnroll;

namespace Tests.Steps
{
    [Binding]
    public class GlobalStepDefinitions
    {
        private IWebDriver driver = DriverFactory.GetDriver();
        private HomePage? homePage;
        private GlobalSearchPage? globalSearchPage;

        GlobalStepDefinitions()
        {
            if (driver == null)
            {
                throw new NotImplementedException();
            }
            homePage = new HomePage(driver);
            globalSearchPage = new GlobalSearchPage(driver);
        }

        [Given(@"I am on the EPAM home page")]
        public void GivenIAmOnTheHomePage()
        {
            driver.Navigate().GoToUrl("https://www.epam.com/");
            homePage = new HomePage(driver);
            homePage.AcceptCookies();
        }
    }
}
