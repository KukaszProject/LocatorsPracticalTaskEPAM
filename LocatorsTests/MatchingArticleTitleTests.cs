using LocatorsPracticalTask.Core;
using LocatorsPracticalTask.Pages;
using OpenQA.Selenium;

namespace LocatorsPracticalTask.Tests
{
    public class MatchingArticleTitleTests : TestBase
    {
        [Test]
        public void ValidateMatchingTitle()
        {
            var home = new HomePage(Driver);
            var insights = new InsightsPage(Driver);
            var article = new ArticleDetailsPage(Driver);

            home.AcceptCookies();
            home.GoToInsights();
            insights.ClickOnArrow(2);
            insights.GetTitleOnCarousel();
            insights.ClickOnReadMore();
            article.GetCurrentArticleTitle();

            Assert.IsTrue(article.IsArticleTitleMatching(insights.GetTitleOnCarousel()),
                "The article title does not match the expected title from the carousel.");
        }
    }
}
