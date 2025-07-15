using OpenQA.Selenium;

namespace LocatorsPracticalTask.Pages
{
    public class ArticleDetailsPage : BasePage
    {
        public ArticleDetailsPage(IWebDriver driver) : base(driver) { }

        public string GetCurrentArticleTitle()
        {
            return Driver.Title;
        }
        public bool IsArticleTitleMatching(string expectedTitle)
        {
            return GetCurrentArticleTitle().Contains(expectedTitle, StringComparison.OrdinalIgnoreCase);
        }
    }
}
