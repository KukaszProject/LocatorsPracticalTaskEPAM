using OpenQA.Selenium;

namespace LocatorsPracticalTask.Pages
{
    public class ArticleDetailsPage : BasePage
    {
        public ArticleDetailsPage(IWebDriver driver) : base(driver) { }

        public string GetCurrentArticleTitle()
        {
            Log.Info("Retrieving the current article title...");
            return Driver.Title;
        }
        public bool IsArticleTitleMatching(string expectedTitle)
        {
            Log.Info($"Checking if the article title matches the expected title: {expectedTitle} ...");
            return GetCurrentArticleTitle().Contains(expectedTitle, StringComparison.OrdinalIgnoreCase);
        }
    }
}