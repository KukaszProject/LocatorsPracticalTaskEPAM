using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace LocatorsPracticalTask.Pages
{
    public class HomePage : BasePage
    {
        private IWebElement CareersLink => Driver.FindElement(By.LinkText("Careers"));
        private IWebElement AboutLink => Driver.FindElement(By.LinkText("About"));
        private IWebElement InsightsLink => Driver.FindElement(By.LinkText("Insights"));
        private IWebElement ServicesLink => Driver.FindElement(By.LinkText("Services"));
        private IWebElement SearchIcon => Driver.FindElement(By.ClassName("header-search__button"));

        public HomePage(IWebDriver driver) : base(driver) { }

        public HomePage AcceptCookies()
        {
            var acceptBtnBy = By.Id("onetrust-accept-btn-handler");

            try
            {
                Wait.Until(ExpectedConditions.ElementIsVisible(acceptBtnBy));
                Wait.Until(ExpectedConditions.ElementToBeClickable(acceptBtnBy));

                var cookieButton = Driver.FindElement(acceptBtnBy);

                try
                {
                    cookieButton.Click();
                }
                catch (ElementClickInterceptedException)
                {
                    ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].click();", cookieButton);
                }
            }
            catch (WebDriverTimeoutException)
            {
                throw new Exception("Accept cookies button not found or not clickable within the timeout period.");
            }
            return this;
        }

        public GlobalSearchPage ClickSearchIcon()
        {
            SearchIcon.Click();
            return new GlobalSearchPage(Driver);
        }
        public CareersPage GoToCareers()
        {
            CareersLink.Click();
            return new CareersPage(Driver);
        }
        public AboutPage GoToAbout()
        {
            AboutLink.Click();
            return new AboutPage(Driver);
        }
        public InsightsPage GoToInsights()
        {
            InsightsLink.Click();
            return new InsightsPage(Driver);
        }
        public ServicesPage GoToServices()
        {
            ServicesLink.Click();
            return new ServicesPage(Driver);
        }
    }
}