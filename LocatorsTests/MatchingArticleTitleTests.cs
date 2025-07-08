using Core.Base;
using LocatorsPracticalTask.Pages;

namespace LocatorsTests
{
    public class MatchingArticleTitleTests : TestBase
    {
        [Test]
        public void ValidateMatchingTitle()
        {
            var home = new HomePage(Driver);
            var insightsPage = new InsightsPage(Driver);
            var articleDetailsPage = new ArticleDetailsPage(Driver);

            home.AcceptCookies()
                .GoToInsights()
                .ClickOnArrow(2)
                .ClickOnReadMore()
                .GetCurrentArticleTitle();

            Assert.That(articleDetailsPage.IsArticleTitleMatching(insightsPage.GetTitleOnCarousel()),
                "The article title does not match the expected title from the carousel.", true);
        }
    }
}
