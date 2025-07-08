using log4net;
using OpenQA.Selenium;

namespace LocatorsPracticalTask.Pages
{
    public class ArticleDetailsPage : BasePage
    {
        public ArticleDetailsPage(IWebDriver driver) : base(driver) { }

        public string GetCurrentArticleTitle()
        {
            LogAction("Retrieving the current article title...");
            return Driver.Title;
        }
        public bool IsArticleTitleMatching(string expectedTitle)
        {
            LogAction($"Checking if the article title matches the expected title: {expectedTitle} ...");
            return GetCurrentArticleTitle().Contains(expectedTitle, StringComparison.OrdinalIgnoreCase);
        }
    }
}