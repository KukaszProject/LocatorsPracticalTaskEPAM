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
            for (int i = 0; i < numberOfClicks; i++)
            {
                var waitForArrow = Wait.Until(ExpectedConditions.ElementToBeClickable(RightArrowButton));
                RightArrowButton.Click();
            }

            return this;
        }
        public ArticleDetailsPage ClickOnReadMore()
        {
            var waitForReadMore = Wait.Until(ExpectedConditions.ElementToBeClickable(ReadMoreButton));
            ReadMoreButton.Click();

            return new ArticleDetailsPage(Driver);
        }
        public string GetTitleOnCarousel()
        {
            return TitleOnCarousel.Text.Trim();
        }
    }
}