//using OpenQA.Selenium;
//using OpenQA.Selenium.Support.UI;

//namespace LocatorsPracticalTask.Pages
//{
//    public class HomePage
//    {
//        private readonly IWebDriver driver;
//        private readonly WebDriverWait wait;

//        public HomePage(IWebDriver driver) 
//        {
//            this.driver = driver;
//            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
//        }

//        private IWebElement CareersLink => driver.FindElement(By.LinkText("Careers"));

//        public void GoTo() => driver.Navigate().GoToUrl("https://www.epam.com/");

//        public void AcceptCookies()
//        {
//            var cookieButton = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("onetrust-accept-btn-handler")));
//            if (cookieButton.Displayed && cookieButton.Enabled)
//            {
//                cookieButton.Click();
//            }
//        }

//        public void ClickCareers() => CareersLink.Click();
//    }
//}

//using OpenQA.Selenium;
//using OpenQA.Selenium.Support.UI;

//namespace LocatorsPracticalTask.Pages
//{
//    public class HomePage
//    {
//        private IWebDriver _driver;
//        private WebDriverWait _wait;

//        public HomePage(IWebDriver driver)
//        {
//            _driver = driver;
//            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
//        }

//        private IWebElement CareersLink => _driver.FindElement(By.LinkText("Careers"));
//        private IWebElement SearchIcon => _driver.FindElement(By.CssSelector("button.header-search__button"));

//        public void GoTo() => _driver.Navigate().GoToUrl("https://www.epam.com/");

//        public void ClickCareers() => CareersLink.Click();

//        public void ClickSearchIcon() => SearchIcon.Click();

//        public void AcceptCookies()
//        {
//            try
//            {
//                var cookieButton = _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions
//                    .ElementExists(By.Id("onetrust-accept-btn-handler")));

//                if (cookieButton.Displayed && cookieButton.Enabled)
//                {
//                    // Scroll into view in case it's off-screen or overlapped
//                    ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView(true);", cookieButton);

//                    // Small delay for any animation
//                    Thread.Sleep(300);

//                    // Click using JavaScript to avoid intercept issues
//                    //((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].click();", cookieButton);
//                    cookieButton.Click();
//                }
//            }
//            catch (WebDriverTimeoutException)
//            {
//                // The cookie banner might not be shown, which is fine
//                Console.WriteLine("Cookie consent banner not found within timeout.");
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine($"Unexpected error in AcceptCookies: {ex.Message}");
//            }
//        }

//    }
//}


using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace LocatorsPracticalTask.Pages
{
    public class HomePage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        public HomePage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }
        private IWebElement AcceptCookiesBtn => _wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("onetrust-accept-btn-handler")));
        private IWebElement CareersLink => _driver.FindElement(By.LinkText("Careers"));
        private IWebElement SearchIcon => _driver.FindElement(By.ClassName("header-search__button"));

        public void AcceptCookies()
        {
            var cookieButton = _wait.Until(ExpectedConditions.ElementToBeClickable(AcceptCookiesBtn));
            if (cookieButton.Displayed && cookieButton.Enabled)
            {
                Thread.Sleep(300);
                cookieButton.Click();
            }
        }
        public void GoToCareers() => CareersLink.Click();
        public void ClickSearchIcon() => SearchIcon.Click();
    }
}
