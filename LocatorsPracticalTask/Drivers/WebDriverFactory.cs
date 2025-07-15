using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Drivers
{
    public class DriverFactory
    {
        private static IWebDriver? driver;

        public static IWebDriver GetDriver()
        {
            if (driver == null)
            {
                var options = new ChromeOptions();
                var downloadPath = Path.Combine(Directory.GetCurrentDirectory(), "Downloads");
                Directory.CreateDirectory(downloadPath);

                options.AddArgument("--start-maximized");
                options.AddUserProfilePreference("download.default_directory", downloadPath);
                options.AddUserProfilePreference("download.prompt_for_download", false);
                options.AddUserProfilePreference("disable-popup-blocking", true);

                driver = new ChromeDriver(options);
            }
            return driver;
        }

        public static void QuitDriver()
        {
            driver?.Quit();
            driver?.Dispose();
            driver = null;
        }
    }
}
