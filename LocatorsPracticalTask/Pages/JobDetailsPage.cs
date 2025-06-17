using OpenQA.Selenium;

public class JobDetailsPage
{
    private readonly IWebDriver driver;

    public JobDetailsPage(IWebDriver driver) => this.driver = driver;

    public bool ContainsKeyword(string keyword)
    {
        return driver.PageSource.ToLower().Contains(keyword.ToLower());
    }
}


