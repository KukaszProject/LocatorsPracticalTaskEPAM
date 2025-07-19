using Core.Drivers;
using OpenQA.Selenium;

public class DriverContext
{
    public IWebDriver Driver { get; }

    public DriverContext()
    {
        Driver = DriverFactory.GetDriver();
    }
}
