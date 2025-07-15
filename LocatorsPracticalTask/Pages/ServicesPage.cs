using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace LocatorsPracticalTask.Pages
{
    public class ServicesPage : BasePage
    {
        public ServicesPage(IWebDriver driver) : base(driver) { }
            
        private By ArtificialInteligenceSection => By.XPath($"//span[contains(text(),'Artificial Intelligence')]");

        public ServicesPage ClickOnArtificialIntelligence()
        {
            Wait.Until(ExpectedConditions.ElementToBeClickable(ArtificialInteligenceSection)).Click();
            return this;
        }

        public ServicesPage NavigateToCategory(string category)
        {
            var categoryLink = Driver.FindElement(By.XPath($"//span[contains(text(),'{category}')]"));
            Wait.Until(ExpectedConditions.ElementToBeClickable(categoryLink)).Click();
            return this;
        }

        public bool IsTitleMatchingCategory(string category)
        {
            return Driver.Title.Contains(category);
        }

        public bool IsRelatedExpertiseSectionVisible()
        {
            return Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//section[contains(.,'Our Related Expertise')]"))).Displayed;
        }

    }
}
