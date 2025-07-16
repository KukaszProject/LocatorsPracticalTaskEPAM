using Drivers;
using LocatorsPracticalTask.Pages;
using OpenQA.Selenium;
using Reqnroll;

namespace Tests.Steps
{
    [Binding]
    public class JobSearchFeatureStepDefinitions
    {
        private IWebDriver driver = DriverFactory.GetDriver();
        private HomePage? homePage;
        private CareersPage? careersPage;
        private JobDetailsPage? jobDetailsPage;

        JobSearchFeatureStepDefinitions()
        {
            if (driver == null)
            {
                throw new NotImplementedException();
            }   
            
            homePage = new HomePage(driver);
            careersPage = new CareersPage(driver);
            jobDetailsPage = new JobDetailsPage(driver);
        }

        [Given("I navigate to the Careers Page")]
        public void GivenINavigateToTheCareersPage()
        {
            homePage?.GoToCareers();
        }

        [When("I select remote work option")]
        public void WhenISelectRemoteWorkOption()
        {
            careersPage?.SelectRemoteWorkOption();
        }

        [When(@"I enter ""(.*)"" in the job search field")]
        public void WhenIEnterInTheJobSearchField(string searchTerm)
        {
            careersPage?.EnterKeyword(searchTerm);
        }

        [When(@"I select All Locations from location dropdown")]
        public void WhenISelectAllLocationsFromLocationDropdown()
        {
            careersPage?.SelectLocation("All Locations");
        }

        [When("I click the search button")]
        public void WhenIClickTheSearchButton()
        {
            careersPage?.ClickFindButton();
        }

        [When("I sort by date")]
        public void WhenISortByDate()
        {
            careersPage?.SortByDate();
        }

        [When("I open latest job offer")]
        public void WhenIOpenLatestJobOffer()
        {
            careersPage?.OpenLastJob();
        }

        [Then(@"I should see job listings related to ""(.*)""")]
        public void ThenIShouldSeeJobListingsRelatedTo(string keyword)
        {
            Assert.IsNotNull(jobDetailsPage, "Careers page is not initialized.");
            Assert.IsTrue(jobDetailsPage.ContainsKeyword(keyword), $"Job page should contain keyword: {keyword}");
            driver.Quit();
        }
    }
}
