using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using log4net;

namespace LocatorsPracticalTask.Pages
{
    public class HomePage : BasePage
    {
        private IWebElement CareersLink => Driver.FindElement(By.LinkText("Careers"));
        private IWebElement AboutLink => Driver.FindElement(By.LinkText("About"));
        private IWebElement InsightsLink => Driver.FindElement(By.LinkText("Insights"));
        private IWebElement SearchIcon => Driver.FindElement(By.ClassName("header-search__button"));

        public HomePage(IWebDriver driver) : base(driver) { }

        public HomePage AcceptCookies()
        {
            LogAction("Trying to accept cookies...");
            var acceptBtnBy = By.Id("onetrust-accept-btn-handler");

            try
            {
                Wait.Until(ExpectedConditions.ElementIsVisible(acceptBtnBy));
                Wait.Until(ExpectedConditions.ElementToBeClickable(acceptBtnBy));

                var cookieButton = Driver.FindElement(acceptBtnBy);

                try
                {
                    LogAction("Clicking accept cookies normally...");
                    cookieButton.Click();
                }
                catch (ElementClickInterceptedException)
                {
                    LogWarning("Normal click failed. Trying JavaScript click...");
                    ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].click();", cookieButton);
                    Log.Info("Clicked accept cookies via JS.");
                }
            }
            catch (WebDriverTimeoutException)
            {
                LogWarning("Cookie button did not appear or was not clickable in time.");
            }
            return this;
        }

        public GlobalSearchPage ClickSearchIcon()
        {
            LogAction("Clicking the search icon on the HomePage...");
            SearchIcon.Click();
            return new GlobalSearchPage(Driver);
        }
        public CareersPage GoToCareers()
        {
            LogAction("Navigating to the Careers page...");
            CareersLink.Click();
            return new CareersPage(Driver);
        }
        public AboutPage GoToAbout()
        {
            LogAction("Navigating to the About page...");
            AboutLink.Click();
            return new AboutPage(Driver);
        }
        public InsightsPage GoToInsights()
        {
            LogAction("Navigating to the Insights page...");
            InsightsLink.Click();
            return new InsightsPage(Driver);
        }
    }
}
