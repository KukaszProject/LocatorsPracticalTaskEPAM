using log4net;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace LocatorsPracticalTask.Pages
{
    public class GlobalSearchPage : BasePage
    {
        public GlobalSearchPage(IWebDriver driver) : base(driver) { }

        private IWebElement FindButton => Driver.FindElement(By.XPath("//button[.//span[contains(text(),'Find')]]"));
        private By SearchInput => By.TagName("input");
        private By Results => By.CssSelector(".search-results__item a");

        public GlobalSearchPage Search(string term)
        {
            LogAction($"Searching for term: {term} on the Global Search page...");
            var searchInput = Wait.Until(ExpectedConditions.ElementIsVisible(SearchInput));
            searchInput.SendKeys(term);
            return this;
        }
        public GlobalSearchPage ClickFindButton()
        {
            LogAction("Clicking the Find button on the Global Search page...");
            FindButton.Click();
            return this;
        }

        public bool AllResultsContain(string term)
        {
            LogAction($"Checking if all results contain the term: {term} ...");

            var allResults = Wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(Results));
            if (allResults.Count == 0)
            {
                LogWarning("No results found.");
                return false;
            }
            if (string.IsNullOrWhiteSpace(term))
            {
                LogWarning("Search term is empty or null.");
                return false;
            }
            LogAction($"Number of results found: {allResults.Count}");
            LogAction("Verifying if all results contain the search term...");

            foreach (var result in allResults)
            {
                var text = result.Text.Trim().ToLower();
                if (!text.Contains(term.ToLower()))
                {
                    LogWarning($"Result '{text}' does not contain the term '{term}'.");
                    return false;
                }
            }
            LogAction("All results contain the search term.");
            return true;
        }
    }
}
