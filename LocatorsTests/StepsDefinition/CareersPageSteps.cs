using Business.Pages;
using Reqnroll;

namespace Tests.Steps
{
    [Binding]
    public class CareersPageSteps
    {
        private readonly CareersPage careersPage;
        private readonly JobDetailsPage jobDetailsPage;

        CareersPageSteps(DriverContext context)
        {
            careersPage = new CareersPage(context.Driver);
            jobDetailsPage = new JobDetailsPage(context.Driver);
        }

        [When("I select remote work option")]
        public void WhenISelectRemoteWorkOption()
        {
            careersPage.SelectRemoteWorkOption();
        }

        [When(@"I enter ""(.*)"" in the job search field")]
        public void WhenIEnterInTheJobSearchField(string searchTerm)
        {
            careersPage.EnterKeyword(searchTerm);
        }

        [When(@"I select All Locations from location dropdown")]
        public void WhenISelectAllLocationsFromLocationDropdown()
        {
            careersPage.SelectLocation("All Locations");
        }

        [When("I click the search button")]
        public void WhenIClickTheSearchButton()
        {
            careersPage.ClickFindButton();
        }

        [When("I sort by date")]
        public void WhenISortByDate()
        {
            careersPage.SortByDate();
        }

        [When("I open latest job offer")]
        public void WhenIOpenLatestJobOffer()
        {
            careersPage.OpenLastJob();
        }

        [Then(@"I should see job listings related to ""(.*)""")]
        public void ThenIShouldSeeJobListingsRelatedTo(string keyword)
        {
            Assert.IsTrue(jobDetailsPage.ContainsKeyword(keyword), $"Job page should contain keyword: {keyword}");
        }
    }
}