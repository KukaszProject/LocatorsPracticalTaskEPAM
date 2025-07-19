using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace LocatorsPracticalTask.Pages
{
    public class AboutPage : BasePage
    {
        private IWebElement DownloadButton => Driver.FindElement(By.LinkText("DOWNLOAD"));

        public AboutPage(IWebDriver driver) : base(driver) { }

        public AboutPage DownloadButtonClicked()
        {
            Log.Info("Clicking the Download button on the About page...");
            Wait.Until(ExpectedConditions.ElementToBeClickable(DownloadButton)).Click();
            return this;
        }
    }
}
