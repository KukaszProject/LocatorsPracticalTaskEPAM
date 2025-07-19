using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace Business.Pages
{
    public class ServicesPage : BasePage
    {
        public ServicesPage(IWebDriver driver) : base(driver) { }

        public bool IsTitleMatchingCategory(string category)
        {
            Log.Info($"Checking if the page title contains the category: {category} ...");
            return Driver.Title.Contains(category);
        }

        public bool IsRelatedExpertiseSectionVisible()
        {
            Log.Info("Checking if the 'Our Related Expertise' section is visible on the Services page...");
            return Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//section[contains(.,'Our Related Expertise')]"))).Displayed;
        }
    }
}