using OpenQA.Selenium;
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
            var searchInput = Wait.Until(ExpectedConditions.ElementIsVisible(SearchInput));
            searchInput.SendKeys(term);
            return this;
        }
        public GlobalSearchPage ClickFindButton()
        {
            FindButton.Click();
            return this;
        }

        public bool AllResultsContain(string term)
        {

            var allResults = Wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(Results));
            if (allResults.Count == 0)
            {
                return false;
            }
            if (string.IsNullOrWhiteSpace(term))
            {
                return false;
            }

            foreach (var result in allResults)
            {
                var text = result.Text.Trim().ToLower();
                if (!text.Contains(term.ToLower()))
                {
                    return false;
                }
            }
            return true;
        }
    }
}