using log4net;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace LocatorsPracticalTask.Pages
{
    public class InsightsPage
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;
        private ILog Log => LogManager.GetLogger(GetType());

        public InsightsPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }
        private IWebElement RightArrowButton => driver.FindElement(By.ClassName("slider__right-arrow"));
        private IWebElement TitleOnCarousel => driver.FindElement(By.CssSelector("p.scaling-of-text-wrapper"));

        private IWebElement ReadMoreButton => wait.Until(ExpectedConditions.ElementIsVisible(By.PartialLinkText("Read")));

        public void ClickOnArrow(int numberOfClicks = 1)
        {
            Log.Info($"Clicking on the right arrow {numberOfClicks} times on the Insights page...");
            for (int i = 0; i < numberOfClicks; i++)
            {
                var waitForArrow = wait.Until(ExpectedConditions.ElementToBeClickable(RightArrowButton));
                RightArrowButton.Click();
            }
        }
        public string GetTitleOnCarousel()
        {
            Log.Info("Retrieving the title on the carousel on the Insights page...");
            return TitleOnCarousel.Text.Trim();
        }
        public void ClickOnReadMore()
        {
            Log.Info("Clicking on the Read More button on the Insights page...");
            ReadMoreButton.Click();
        }
    }
}
