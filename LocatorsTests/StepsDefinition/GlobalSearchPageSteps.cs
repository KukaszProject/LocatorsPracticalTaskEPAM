using Business.Pages;
using Reqnroll;

namespace Tests.Steps
{
    [Binding]
    public class GlobalSearchPageSteps
    {
        private readonly GlobalSearchPage globalSearchPage;

        GlobalSearchPageSteps(DriverContext context)
        {
            globalSearchPage = new GlobalSearchPage(context.Driver);
        }

        [When(@"I enter ""(.*)"" in the search field")]
        public void WhenIEnterKeywordInTheSearchField(string keyword)
        {
            globalSearchPage.Search(keyword);
        }

        [When("I click the find button")]
        public void WhenIClickTheFindButton()
        {
            globalSearchPage.ClickFindButton();
        }

        [Then("I should see search results related to \"(.*)\"")]
        public void ThenIShouldSeeSearchResultsRelatedToKeyword(string keyword)
        {
            Assert.That(globalSearchPage.AllResultsContain(keyword), $"All results should contain: {keyword}", true);
        }
    }
}
