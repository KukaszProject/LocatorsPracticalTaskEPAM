using log4net;
using OpenQA.Selenium;

namespace LocatorsPracticalTask.Pages
{
    public class ArticleDetailsPage
    {
        private readonly IWebDriver driver;
        private ILog Log => LogManager.GetLogger(GetType());
        public ArticleDetailsPage(IWebDriver driver) => this.driver = driver;

        public string GetCurrentArticleTitle()
        {
            Log.Info("Retrieving the current article title...");
            return driver.Title;
        }
        public bool IsArticleTitleMatching(string expectedTitle)
        {
            Log.Info($"Checking if the article title matches the expected title: {expectedTitle} ...");
            return GetCurrentArticleTitle().Contains(expectedTitle, StringComparison.OrdinalIgnoreCase);
        }
    }
}