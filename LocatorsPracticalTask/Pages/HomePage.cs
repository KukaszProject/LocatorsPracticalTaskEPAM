using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using log4net;

namespace LocatorsPracticalTask.Pages
{
    public class HomePage
    {
        private readonly IWebDriver driver = null!;
        private readonly WebDriverWait wait;
        private ILog Log => LogManager.GetLogger(GetType());

        private IWebElement AcceptCookiesBtn => driver.FindElement(By.Id("onetrust-accept-btn-handler"));
        private IWebElement CareersLink => driver.FindElement(By.LinkText("Careers"));
        private IWebElement AboutLink => driver.FindElement(By.LinkText("About"));
        private IWebElement InsightsLink => driver.FindElement(By.LinkText("Insights"));
        private IWebElement SearchIcon => driver.FindElement(By.ClassName("header-search__button"));

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        public void AcceptCookies()
        {
            Log.Info("Accepting cookies on the HomePage...");
            var cookieButton = wait.Until(ExpectedConditions.ElementToBeClickable(AcceptCookiesBtn));
            if (cookieButton.Displayed && cookieButton.Enabled)
            {
                var readyCookieBtn = wait.Until(ExpectedConditions.ElementToBeClickable(cookieButton));
                readyCookieBtn.Click();
            }
        }
        public void ClickSearchIcon()
        {
            Log.Info("Clicking the search icon on the HomePage...");
            SearchIcon.Click();
        }
        public void GoToCareers()
        {
            Log.Info("Navigating to the Careers page...");
            CareersLink.Click();
        }
        public void GoToAbout()
        {
            Log.Info("Navigating to the About page...");
            AboutLink.Click();
        }
        public void GoToInsights()
        {
            Log.Info("Navigating to the Insights page...");
            InsightsLink.Click();
        }
    }
}
