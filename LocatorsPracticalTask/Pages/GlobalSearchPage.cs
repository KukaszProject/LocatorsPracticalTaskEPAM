//using OpenQA.Selenium;
//using OpenQA.Selenium.Support.UI;
//using SeleniumExtras.WaitHelpers;

//namespace LocatorsPracticalTask.Pages
//{
//    public class GlobalSearchPage
//    {
//        private IWebDriver _driver;
//        private WebDriverWait _wait;

//        public GlobalSearchPage(IWebDriver driver)
//        {
//            _driver = driver;
//            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
//        }

//        private IWebElement SearchIcon => _wait.Until(d =>
//            d.FindElement(By.ClassName("header-search__button")));

//        private IWebElement InputField => _wait.Until(d => d.FindElement(By.XPath("//input[contains(@placeholder, 'looking')]")));

//        private IWebElement FindButton => _driver.FindElement(By.XPath("//button[.='Find']"));

//        private IReadOnlyCollection<IWebElement> Results => _wait.Until(d =>
//            d.FindElements(By.XPath("//div[contains(@class, 'search-results__items')]//a")));

//        public void ClickSearchIcon() => SearchIcon.Click();


//        public void Search(string keyword)
//        {
//            InputField.SendKeys(keyword);
//            FindButton.Click();
//        }

//        public bool AllResultsContain(string keyword)
//        {
//            return Results.All(r => r.Text.ToLower().Contains(keyword.ToLower()));
//        }
//    }
//}

using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Collections.Generic;
using System.Linq;

public class GlobalSearchPage
{
    private readonly IWebDriver _driver;
    private readonly WebDriverWait _wait;

    public GlobalSearchPage(IWebDriver driver)
    {
        _driver = driver;
        _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
    }

    private IWebElement SearchInput => _wait.Until(ExpectedConditions.ElementIsVisible(By.TagName("input")));
    private IWebElement FindButton => _driver.FindElement(By.XPath("//button[.//span[contains(text(),'Find')]]"));
    private IReadOnlyCollection<IWebElement> Results => _driver.FindElements(By.CssSelector(".search-results__item a"));

    public void Search(string term)
    {
        SearchInput.SendKeys(term);
        FindButton.Click();
    }

    public bool AllResultsContain(string term)
    {
        return Results.All(x => x.Text.ToLower().Contains(term.ToLower()));
    }
}

