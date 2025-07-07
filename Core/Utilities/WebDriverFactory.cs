using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Core.Utilities
{
    public class DriverFactory
    {
        private static IWebDriver? _driver;

        public static IWebDriver GetDriver()
        {
            if (_driver == null)
            {
                var options = new ChromeOptions();
                var downloadPath = Path.Combine(Directory.GetCurrentDirectory(), "Downloads");
                Directory.CreateDirectory(downloadPath);

                options.AddArgument("--start-maximized");
                options.AddUserProfilePreference("download.default_directory", downloadPath);
                options.AddUserProfilePreference("download.prompt_for_download", false);
                options.AddUserProfilePreference("disable-popup-blocking", true);

                _driver = new ChromeDriver(options);
            }
            return _driver;
        }

        public static void QuitDriver()
        {
            _driver?.Quit();
            _driver?.Dispose();
            _driver = null;
        }
    }
}