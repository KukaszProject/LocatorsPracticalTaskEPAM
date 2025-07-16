using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace LocatorsPracticalTask.Pages
{
    public class ServicesPage : BasePage
    {
        public ServicesPage(IWebDriver driver) : base(driver) { }

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
