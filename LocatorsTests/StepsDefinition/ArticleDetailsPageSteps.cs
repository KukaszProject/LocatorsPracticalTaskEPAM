using Business.Pages;
using Reqnroll;

namespace Tests.Steps
{
    [Binding]
    public class ArticleDetailsPageSteps
    {
        private readonly ArticleDetailsPage articleDetailsPage;
        private readonly InsightsPage insightsPage;

        ArticleDetailsPageSteps(DriverContext context)
        {
            articleDetailsPage = new ArticleDetailsPage(context.Driver);
            insightsPage = new InsightsPage(context.Driver);
        }

        [When("I get the current article title")]
        public void WhenIGetTheCurrentArticleTitle()
        {
            articleDetailsPage.GetCurrentArticleTitle();
        }

        [Then("The article title should match the expected title")]
        public void ThenTheArticleTitleShouldMatchTheExpectedTitle()
        {
            Assert.That(articleDetailsPage.IsArticleTitleMatching(insightsPage.GetTitleOnCarousel()),
                "The article title does not match the expected title from the carousel.", true);
        }
    }
}