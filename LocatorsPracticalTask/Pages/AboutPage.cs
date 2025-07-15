using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
namespace LocatorsPracticalTask.Pages
{
    public class AboutPage : BasePage
    {
        private IWebElement DownloadButton => Driver.FindElement(By.LinkText("DOWNLOAD"));

        public AboutPage(IWebDriver driver) : base(driver) { }

        public AboutPage DownloadButtonClicked()
        {
            Wait.Until(ExpectedConditions.ElementToBeClickable(DownloadButton)).Click();
            return this;
        }
    }
}