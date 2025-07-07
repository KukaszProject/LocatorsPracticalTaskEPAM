using log4net;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace LocatorsPracticalTask.Pages
{
    public class AboutPage
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;
        private ILog Log => LogManager.GetLogger(GetType());
        public AboutPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        private IWebElement DownloadButton => driver.FindElement(By.LinkText("DOWNLOAD"));

        public void DownloadButtonClicked()
        {
            Log.Info("Clicking the Download button on the About page...");
            wait.Until(ExpectedConditions.ElementToBeClickable(DownloadButton)).Click();
        }
    }
}
