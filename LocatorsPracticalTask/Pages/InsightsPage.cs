using log4net;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace LocatorsPracticalTask.Pages
{
    public class InsightsPage : BasePage
    {
        public InsightsPage(IWebDriver driver) : base(driver) { }
        private IWebElement RightArrowButton => Driver.FindElement(By.ClassName("slider__right-arrow"));
        private IWebElement TitleOnCarousel => Driver.FindElement(By.CssSelector("p.scaling-of-text-wrapper"));

        private IWebElement ReadMoreButton => Wait.Until(ExpectedConditions.ElementIsVisible(By.PartialLinkText("Read")));

        public InsightsPage ClickOnArrow(int numberOfClicks = 1)
        {
            LogAction($"Clicking on the right arrow {numberOfClicks} times on the Insights page...");
            for (int i = 0; i < numberOfClicks; i++)
            {
                var waitForArrow = Wait.Until(ExpectedConditions.ElementToBeClickable(RightArrowButton));
                RightArrowButton.Click();
            }

            return this;
        }
        public ArticleDetailsPage ClickOnReadMore()
        {
            LogAction("Clicking on the Read More button on the Insights page...");
            var waitForReadMore = Wait.Until(ExpectedConditions.ElementToBeClickable(ReadMoreButton));
            ReadMoreButton.Click();

            return new ArticleDetailsPage(Driver);
        }
        public string GetTitleOnCarousel()
        {
            LogAction("Retrieving the title on the carousel on the Insights page...");
            return TitleOnCarousel.Text.Trim();
        }
    }
}
