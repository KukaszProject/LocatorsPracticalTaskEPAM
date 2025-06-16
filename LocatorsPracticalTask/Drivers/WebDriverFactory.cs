//using OpenQA.Selenium.Chrome;
//using OpenQA.Selenium;

//namespace LocatorsPracticalTask.Drivers
//{
//    public static class WebDriverFactory
//    {
//        public static IWebDriver CreateDriver()
//        {
//            var options = new ChromeOptions();
//            options.AddArgument("start-maximized");
//            return new ChromeDriver(options);
//        }
//    }
//}

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
