using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace LocatorsPracticalTask.Pages
{
    public class CareersPage
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;

        public CareersPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        private IWebElement KeywordInput => driver.FindElement(By.Id("new_form_job_search-keyword"));
        private IWebElement LocationDropdown =>     driver.FindElement(By.ClassName("select2-selection--single"));
        private IWebElement RemoteInput => driver.FindElement(By.Name("remote"));
        private IWebElement RemoteLabel => RemoteInput.FindElement(By.XPath("following-sibling::label"));
        private IWebElement FindButton => driver.FindElement(By.XPath("//form[@id='jobSearchFilterForm']//descendant::button[@type='submit']"));
        private IWebElement SortingList =>  driver.FindElement(By.ClassName("search-result__sorting-list"));
        private IWebElement SortByDateButton => SortingList.FindElement(By.XPath(".//label[@for='sort-time']"));
        private IWebElement LatestJobResult => wait.Until(d => d.FindElement(By.PartialLinkText("APPLY")));

        public void SearchJobs(string keyword)
        {
            CheckRemote();
            KeywordInput.SendKeys(keyword);
            SelectLocation("All Locations");
            FindButton.Click();
        }

        public void CheckRemote() => RemoteLabel.Click();
        public void SelectLocation(string location)
        {
            LocationDropdown.Click();
            var optionToSelect = wait.Until(driver =>
                driver.FindElement(By.XPath($"//li[contains(@class, 'select2-results__option') and contains(text(),'{location}')]")));

            optionToSelect.Click();
        }

        public void SortByDate() => wait.Until(ExpectedConditions.ElementToBeClickable(SortByDateButton)).Click();

        public void OpenLastJob() => wait.Until(ExpectedConditions.ElementToBeClickable(LatestJobResult)).Click();
    }
}
