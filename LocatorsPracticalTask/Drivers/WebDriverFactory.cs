using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace LocatorsPracticalTask.Drivers
{
    public static class DriverFactory
    {
        public static IWebDriver GetDriver()
        {

            string downloadPath = Path.Combine(Directory.GetCurrentDirectory(), "Downloads");

            if (!Directory.Exists(downloadPath))
            {
                Directory.CreateDirectory(downloadPath);
            }

            var options = new ChromeOptions();

            options.AddArgument("--start-maximized");
            options.AddUserProfilePreference("download.default_directory", downloadPath);
            options.AddUserProfilePreference("download.prompt_for_download", false);
            options.AddUserProfilePreference("disable-popup-blocking", true);

            return new ChromeDriver(options);
        }
    }
}
