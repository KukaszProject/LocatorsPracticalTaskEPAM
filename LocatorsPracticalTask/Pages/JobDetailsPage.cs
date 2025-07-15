using OpenQA.Selenium;

namespace LocatorsPracticalTask.Pages
{
    public class JobDetailsPage : BasePage
    {
        public JobDetailsPage(IWebDriver driver) : base(driver) { }

        public bool ContainsKeyword(string keyword)
        {
            return Driver.PageSource.ToLower().Contains(keyword.ToLower());
        }
    }
}


