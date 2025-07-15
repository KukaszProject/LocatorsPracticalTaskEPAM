using System;
using Drivers;
using LocatorsPracticalTask.Pages;
using OpenQA.Selenium;
using Reqnroll;

namespace Tests.Steps
{
    [Binding]
    public class MatchingArticleFeatureStepDefinitions
    {
        private IWebDriver driver = DriverFactory.GetDriver();
        private InsightsPage? insightsPage;
        private HomePage? homePage;
        private ArticleDetailsPage? articleDetailsPage;
        public MatchingArticleFeatureStepDefinitions()
    {
            if (driver == null)
            {
                throw new ArgumentNullException(nameof(driver), "Driver cannot be null.");
            }
            homePage = new HomePage(driver);
            insightsPage = new InsightsPage(driver);
            articleDetailsPage = new ArticleDetailsPage(driver);
        }

        [Given("I navigate to the Insights Page")]
        public void GivenINavigateToTheInsightsPage()
        {
            homePage?.GoToInsights();
        }

        [When("I click on the arrow twice")]
        public void WhenIClickOnTheArrowTwice()
        {
            insightsPage?.ClickOnArrow(2);
        }

        [When("I click on the read more button")]
        public void WhenIClickOnTheReadMoreButton()
        {
            insightsPage?.ClickOnReadMore();
        }

        [When("I get the current article title")]
        public void WhenIGetTheCurrentArticleTitle()
        {
            articleDetailsPage?.GetCurrentArticleTitle();
        }

        [Then("The article title should match the expected title")]
        public void ThenTheArticleTitleShouldMatchTheExpectedTitle()
        {
            Assert.NotNull(articleDetailsPage, "ArticleDetailsPage is null.");
            Assert.NotNull(insightsPage, "InsightsPage is null.");
            Assert.That(articleDetailsPage.IsArticleTitleMatching(insightsPage.GetTitleOnCarousel()),
                "The article title does not match the expected title from the carousel.", true);
        }
    }
}
