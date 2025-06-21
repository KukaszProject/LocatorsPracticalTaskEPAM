using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocatorsPracticalTask.Pages
{
    public class InsightsPage
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;

        public InsightsPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }
        private IWebElement RightArrowButton => wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("slider__right-arrow")));
        private IWebElement TitleOnCarousel => driver.FindElement(By.CssSelector("p.scaling-of-text-wrapper"));

        private IWebElement ReadMoreButton => wait.Until(ExpectedConditions.ElementIsVisible(By.PartialLinkText("Read")));

        public void ClickOnArrow(int numberOfClicks)
        {
            for (int i = 0; i < numberOfClicks; i++)
            {
                var waitForArrow = wait.Until(ExpectedConditions.ElementToBeClickable(RightArrowButton));
                RightArrowButton.Click();
            }
        }
        public string GetTitleOnCarousel() => TitleOnCarousel.Text.Trim();
        public void ClickOnReadMore() => ReadMoreButton.Click();
    }
}
