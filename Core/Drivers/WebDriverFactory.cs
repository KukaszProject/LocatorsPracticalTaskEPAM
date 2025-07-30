using Core.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;

namespace Core.Drivers
{
    public class DriverFactory
    {
        private static IWebDriver? driver;

        public static IWebDriver GetDriver()
        {
            if (driver != null) return driver;

            var browser = ConfigHelper.Get("Browser").ToLower();
            string downloadPath = Path.Combine(Directory.GetCurrentDirectory(), ConfigHelper.Get("DownloadFolder"));

            Directory.CreateDirectory(downloadPath);

            switch (browser)
            {
                case "chrome":
                    driver = CreateChromeDriver(downloadPath);
                    break;

                case "firefox":
                    driver = CreateFirefoxDriver(downloadPath);
                    break;

                case "edge":
                    driver = CreateEdgeDriver(downloadPath);
                    break;

                default:
                    throw new ArgumentException($"Unsupported browser: {browser}");
            }

            return driver;
        }

        private static IWebDriver CreateChromeDriver(string downloadPath)
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            options.AddUserProfilePreference("download.default_directory", downloadPath);
            options.AddUserProfilePreference("download.prompt_for_download", false);
            options.AddUserProfilePreference("disable-popup-blocking", true);
            return new ChromeDriver(options);
        }

        private static IWebDriver CreateFirefoxDriver(string downloadPath)
        {
            var profile = new FirefoxProfile();
            profile.SetPreference("browser.download.dir", downloadPath);
            profile.SetPreference("browser.download.folderList", 2);
            profile.SetPreference("browser.helperApps.neverAsk.saveToDisk", "application/pdf");
            profile.SetPreference("pdfjs.disabled", true);

            var options = new FirefoxOptions
            {
                Profile = profile
            };

            return new FirefoxDriver(options);
        }

        private static IWebDriver CreateEdgeDriver(string downloadPath)
        {
            var options = new EdgeOptions();
            options.AddArgument("start-maximized");
            return new EdgeDriver(options);
        }

        public static void QuitDriver()
        {
            driver?.Quit();
            driver?.Dispose();
            driver = null;
        }
    }
}