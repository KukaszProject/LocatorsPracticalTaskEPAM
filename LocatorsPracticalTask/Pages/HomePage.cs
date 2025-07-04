using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace LocatorsPracticalTask.Pages
{
    public class HomePage
    {
        private readonly IWebDriver driver = null!;
        private readonly WebDriverWait wait;

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }
        private IWebElement AcceptCookiesBtn => wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("onetrust-accept-btn-handler")));
        private IWebElement CareersLink => driver.FindElement(By.LinkText("Careers"));

        private IWebElement AboutLink => driver.FindElement(By.LinkText("About"));
        private IWebElement InsightsLink => driver.FindElement(By.LinkText("Insights"));
        private IWebElement SearchIcon => driver.FindElement(By.ClassName("header-search__button"));

        public void AcceptCookies()
        {
            var cookieButton = wait.Until(ExpectedConditions.ElementToBeClickable(AcceptCookiesBtn));
            if (cookieButton.Displayed && cookieButton.Enabled)
            {
                Thread.Sleep(300);
                cookieButton.Click();
            }
        }
        public void GoToCareers() => CareersLink.Click();
        public void GoToAbout() => AboutLink.Click();
        public void GoToInsights() => InsightsLink.Click();
        public void ClickSearchIcon() => SearchIcon.Click();
    }
}
