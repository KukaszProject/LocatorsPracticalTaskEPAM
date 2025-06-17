using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace LocatorsPracticalTask.Drivers
{
    public static class DriverFactory
    {
        public static IWebDriver GetDriver()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            return new ChromeDriver(options);
        }
    }
}
