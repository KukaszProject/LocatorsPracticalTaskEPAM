using log4net;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace LocatorsPracticalTask.Pages
{
    public class GlobalSearchPage
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;
        private ILog Log => LogManager.GetLogger(GetType());

        public GlobalSearchPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        private IWebElement SearchInput => wait.Until(ExpectedConditions.ElementIsVisible(By.TagName("input")));
        private IWebElement FindButton => driver.FindElement(By.XPath("//button[.//span[contains(text(),'Find')]]"));
        private IReadOnlyCollection<IWebElement> Results => driver.FindElements(By.CssSelector(".search-results__item a"));

        public void Search(string term)
        {
            Log.Info($"Searching for term: {term} on the Global Search page...");
            SearchInput.SendKeys(term);
        }
        public void ClickFindButton()
        {
            Log.Info("Clicking the Find button on the Global Search page...");
            FindButton.Click();
        }

        public bool AllResultsContain(string term)
        {
            Log.Info($"Checking if all results contain the term: {term} ...");

            var allResults = Results.ToList();
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
