using LocatorsPracticalTask.Drivers;
using LocatorsPracticalTask.Pages;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocatorsPracticalTask.Tests
{
    public class MatchingArticleTitleTests
    {
        private IWebDriver? driver;

        [SetUp]
        public void Setup()
        {
            driver = DriverFactory.GetDriver();
            driver.Navigate().GoToUrl("https://www.epam.com/");
        }

        [Test]
        public void ValidateMatchingTitle()
        {
            var home = new HomePage(driver);
            var insights = new InsightsPage(driver);
            var article = new ArticleDetailsPage(driver);

            home.AcceptCookies();
            home.GoToInsights();
            insights.ClickOnArrow(2);
            insights.GetTitleOnCarousel();
            insights.ClickOnReadMore();
            article.GetCurrentArticleTitle();

            Assert.IsTrue(article.IsArticleTitleMatching(insights.GetTitleOnCarousel()),
                "The article title does not match the expected title from the carousel.");
        }

        [TearDown]
        public void TearDown()
        {
            driver?.Quit();
            driver?.Dispose();
        }
    }
}
