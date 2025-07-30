using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace Business.Pages
{
    public class GlobalSearchPage : BasePage
    {
        public GlobalSearchPage(IWebDriver driver) : base(driver) { }

        private IWebElement FindButton => Driver.FindElement(By.XPath("//button[.//span[contains(text(),'Find')]]"));
        private By SearchInput => By.TagName("input");
        private By Results => By.CssSelector(".search-results__item a");

        public GlobalSearchPage Search(string term)
        {
            Log.Info($"Searching for term: {term} on the Global Search page...");
            var searchInput = Wait.Until(ExpectedConditions.ElementIsVisible(SearchInput));
            searchInput.SendKeys(term);
            return this;
        }
        public GlobalSearchPage ClickFindButton()
        {
            Log.Info("Clicking the Find button on the Global Search page...");
            FindButton.Click();
            return this;
        }

        public bool AllResultsContain(string term)
        {
            Log.Info($"Checking if all results contain the term: {term} ...");

            var allResults = Wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(Results));
            if (allResults.Count == 0)
            {
                Log.Warn("No results found.");
                return false;
            }
            if (string.IsNullOrWhiteSpace(term))
            {
                Log.Warn("Search term is empty or null.");
                return false;
            }
            Log.Info($"Number of results found: {allResults.Count}");
            Log.Info("Verifying if all results contain the search term...");

            foreach (var result in allResults)
            {
                if (result == null)
                {
                    Log.Error("A result is null, skipping verification.");
                    throw new NullReferenceException("A result element is null.");
                }

                var text = result.Text.Trim().ToLower();
                if (!text.Contains(term.ToLower()))
                {
                    Log.Warn($"Result '{text}' does not contain the term '{term}'.");
                    return false;
                }
            }
            Log.Info("All results contain the search term.");
            return true;
        }
    }
}
