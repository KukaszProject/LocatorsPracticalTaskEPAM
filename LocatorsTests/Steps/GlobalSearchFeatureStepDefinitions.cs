using Drivers;
using LocatorsPracticalTask.Pages;
using OpenQA.Selenium;
using Reqnroll;

namespace Tests.Steps
{
    [Binding]
    public class GlobalSearchFeatureStepDefinitions
    {
        private IWebDriver driver = DriverFactory.GetDriver();
        private HomePage? homePage;
        private GlobalSearchPage? globalSearchPage;

        GlobalSearchFeatureStepDefinitions()
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

        [Given("I navigate to the Global Search")]
        public void GivenINavigateToTheGlobalSearch()
        {
            homePage?.ClickSearchIcon();
        }

        [When(@"I enter ""(.*)"" in the search field")]
        public void WhenIEnterKeywordInTheSearchField(string keyword)
        {
            globalSearchPage?.Search(keyword);
        }

        [When("I click the find button")]
        public void WhenIClickTheFindButton()
        {
            globalSearchPage?.ClickFindButton();
        }


        [Then("I should see search results related to \"(.*)\"")]
        public void ThenIShouldSeeSearchResultsRelatedToKeyword(string keyword)
        {
            Assert.NotNull(globalSearchPage, "Global Search page should be initialized.");
            Assert.That(globalSearchPage.AllResultsContain(keyword), $"All results should contain: {keyword}", true);
        }
    }
}
