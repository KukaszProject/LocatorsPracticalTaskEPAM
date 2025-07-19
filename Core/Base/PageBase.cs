using log4net;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

public abstract class BasePage
{
    protected readonly IWebDriver Driver;
    protected readonly WebDriverWait Wait;
    protected ILog Log => Logger.Instance;

    protected BasePage(IWebDriver driver)
    {
        Driver = driver;
        Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
    }
}

