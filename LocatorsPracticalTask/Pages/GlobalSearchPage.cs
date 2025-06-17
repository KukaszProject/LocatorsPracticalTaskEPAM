using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

public class GlobalSearchPage
{
    private readonly IWebDriver driver;
    private readonly WebDriverWait wait;

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
        SearchInput.SendKeys(term);
        FindButton.Click();
    }

    public bool AllResultsContain(string term) => Results.All(x => x.Text.Trim().ToLower().Contains(term.ToLower()));
}

