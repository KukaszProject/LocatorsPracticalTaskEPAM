using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Business.Pages
{
    public class HomePage : BasePage
    {
        private IWebElement CareersLink => Driver.FindElement(By.LinkText("Careers"));
        private IWebElement AboutLink => Driver.FindElement(By.LinkText("About"));
        private IWebElement InsightsLink => Driver.FindElement(By.LinkText("Insights"));
        private IWebElement SearchIcon => Driver.FindElement(By.ClassName("header-search__button"));

        public IWebElement ServicesLink => Driver.FindElement(By.LinkText("Services"));
        public IWebElement ArtificialIntelligenceLink => Driver.FindElement(By.CssSelector("a.top-navigation__main-link[href='/services/artificial-intelligence']"));

        public HomePage(IWebDriver driver) : base(driver) { }

        public HomePage AcceptCookies()
        {
            Log.Info("Trying to accept cookies...");
            var acceptBtnBy = By.Id("onetrust-accept-btn-handler");

            try
            {
                Wait.Until(ExpectedConditions.ElementIsVisible(acceptBtnBy));
                Wait.Until(ExpectedConditions.ElementToBeClickable(acceptBtnBy));

                var cookieButton = Driver.FindElement(acceptBtnBy);
                Log.Info("Clicking accept cookies normally...");
                cookieButton.Click();
            }
            catch (ElementClickInterceptedException)
            {
                Log.Warn("Normal click failed. Trying JavaScript click...");
                var cookieButton = Driver.FindElement(acceptBtnBy);
                ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].click();", cookieButton);
                Log.Info("Clicked accept cookies via JS.");
            }
            catch (WebDriverTimeoutException)
            {
                Log.Warn("Cookie button did not appear or was not clickable in time.");
            }
            return this;
        }

        public HomePage NavigateToCategory(string serviceName)
        {

            var serviceNameFormatted = string.Join("-", serviceName
                .ToLower().Split([' '], StringSplitOptions.RemoveEmptyEntries));

            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            var subMenu = wait.Until(ExpectedConditions.ElementToBeClickable(
                By.CssSelector($"a.top-navigation__sub-link[href='/services/artificial-intelligence/{serviceNameFormatted}']")));

            subMenu.Click();
            return this;
        }

        public GlobalSearchPage ClickSearchIcon()
        {
            Log.Info("Clicking the search icon on the HomePage...");
            SearchIcon.Click();
            return new GlobalSearchPage(Driver);
        }
        public CareersPage GoToCareers()
        {
            Log.Info("Navigating to the Careers page...");
            CareersLink.Click();
            return new CareersPage(Driver);
        }
        public AboutPage GoToAbout()
        {
            Log.Info("Navigating to the About page...");
            AboutLink.Click();
            return new AboutPage(Driver);
        }
        public InsightsPage GoToInsights()
        {
            Log.Info("Navigating to the Insights page...");
            InsightsLink.Click();
            return new InsightsPage(Driver);
        }
    }
}
