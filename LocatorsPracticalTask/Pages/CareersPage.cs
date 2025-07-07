using log4net;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace LocatorsPracticalTask.Pages
{
    public class CareersPage
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;
        private ILog Log => LogManager.GetLogger(GetType());

        private IWebElement KeywordInput => driver.FindElement(By.Id("new_form_job_search-keyword"));
        private IWebElement LocationDropdown => driver.FindElement(By.ClassName("select2-selection--single"));
        private IWebElement RemoteInput => driver.FindElement(By.Name("remote"));
        private IWebElement RemoteLabel => RemoteInput.FindElement(By.XPath("following-sibling::label"));
        private IWebElement FindButton => driver.FindElement(By.XPath("//form[@id='jobSearchFilterForm']//descendant::button[@type='submit']"));
        private IWebElement SortingList =>  driver.FindElement(By.ClassName("search-result__sorting-list"));
        private IWebElement SortByDateButton => SortingList.FindElement(By.XPath(".//label[@for='sort-time']"));
        private IWebElement LatestJobResult => driver.FindElement(By.PartialLinkText("APPLY"));

        public CareersPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }
        public void SearchJobs(string keyword)
        {
            SelectRemoteWorkOption();
            KeywordInput.SendKeys(keyword);
            SelectLocation("All Locations");
            FindButton.Click();
        }
        public void SelectRemoteWorkOption()
        {
            Log.Info("Selecting remote work option on the Careers page...");
            RemoteLabel.Click();
        }
        public void SelectLocation(string location)
        {
            Log.Info($"Selecting location: {location} on the Careers page...");
            LocationDropdown.Click();
            var optionToSelect = wait.Until(driver =>
                driver.FindElement(By.XPath($"//li[contains(@class, 'select2-results__option') and contains(text(),'{location}')]")));

            optionToSelect.Click();
        }
        public void SortByDate()
        {
            Log.Info("Sorting job results by date on the Careers page...");
            wait.Until(ExpectedConditions.ElementToBeClickable(SortByDateButton)).Click();
        }
        public void OpenLastJob()
        {
            Log.Info("Opening the latest job result on the Careers page...");
            wait.Until(ExpectedConditions.ElementToBeClickable(LatestJobResult)).Click();
        }
    }
}
